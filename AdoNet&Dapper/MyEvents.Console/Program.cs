//СТВОРЕННЯ GENERIC HOST
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyEventsAdoNetDb.Repositories.Contracts;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

var host = Host.CreateDefaultBuilder()
         .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
         {
             //Configuration
             hostBuilderContext.HostingEnvironment.EnvironmentName = System.Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
             var env = hostBuilderContext.HostingEnvironment;
             configurationBuilder.AddEnvironmentVariables();
             configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             configurationBuilder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
         })
         .ConfigureServices((hostBuilderContext, serviceCollection) =>
         {
             // Connection/Transaction for ADO.NET/DAPPER database
             serviceCollection.AddScoped((s) => new SqlConnection(hostBuilderContext.Configuration.GetConnectionString("MSSQLConnection")));
             serviceCollection.AddScoped<IDbTransaction>(s =>
             {
                 SqlConnection conn = s.GetRequiredService<SqlConnection>();
                 conn.Open();
                 return conn.BeginTransaction();
             });
             //Connection for EF database + DbContext
             //serviceCollection.AddDbContext<MyEventsDbContext>(options =>
             //{
             //    string connectionString = hostBuilderContext.Configuration.GetConnectionString("MSSQLConnection");
             //    options.UseSqlServer(connectionString);
             //});
             // Dependendency Injection for Repositories/UOW from ADO.NET DAL
             serviceCollection.AddScoped <IBookListRepository, BookListRepository>();
             serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
             // Dependendency Injection for Repositories/UOW from EF DAL
             //serviceCollection.AddScoped<IEFEventRepository, EFEventRepository>();
             //serviceCollection.AddScoped<IEFCategoryRepository, EFCategoryRepository>();
             //serviceCollection.AddScoped<IEFUserProfileRepository, EFUserProfileRepository>();
             //serviceCollection.AddScoped<IEFGalleryRepository, EFGalleryRepository>();
             //serviceCollection.AddScoped<IEFMessageRepository, EFMessageRepository>();
             //serviceCollection.AddScoped<IEFImageRepository, EFImageRepository>();
             //serviceCollection.AddScoped<IEFUnitOfWork, EFUnitOfWork>();
         })
         .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
         {
         })
         .Build();

//var objUOW = host.Services.GetRequiredService<IUnitOfWork>();
//var x = await objUOW._eventRepository.GetAsync(1);
//Console.WriteLine(x.Name);

using (IServiceScope serviceScope = host.Services.CreateScope())
{
    IServiceProvider provider = serviceScope.ServiceProvider;
    var objUOW = provider.GetRequiredService<IUnitOfWork>();
    try
    {
        var x = await objUOW._booklistRepository.GetAsync(1);
        Console.WriteLine(x.BookName);
    }
    catch (Exception ex)
    {
        Console.WriteLine(DateTime.UtcNow + "=>" + "Запит до БД... Щось пішло не так: " + ex.Message);

    }
}




Console.ReadKey();