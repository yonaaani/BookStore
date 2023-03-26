using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyEventsAdoNetDB.Repositories.Contracts;

//using MyEventsEntityFrameworkDb.DbContexts;
//using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
//using MyEventsEntityFrameworkDb.EFRepositories;
using System.Data;
using System.Data.SqlClient;
using MyEventsAdoNetDb.Repositories.Contracts;
using MyEventsAdoNetDB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
//builder.Configuration.AddJsonFile("appsetings.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile($"appsetings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


// Connection/Transaction for ADO.NET/DAPPER database
builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("MSSQLConnection")));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});
//Connection for EF database + DbContext
//builder.Services.AddDbContext<MyEventsDbContext>(options =>
//{
//    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
//options.UseSqlServer(connectionString);
//});

// Dependendency Injection for Repositories/UOW from ADO.NET DAL
builder.Services.AddScoped<IBookListRepository, BookListRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Dependendency Injection for Repositories/UOW from EF DAL
/*builder.Services.AddScoped<IEFEventRepository, EFEventRepository>();
builder.Services.AddScoped<IEFCategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<IEFUserProfileRepository, EFUserProfileRepository>();
builder.Services.AddScoped<IEFGalleryRepository, EFGalleryRepository>();
builder.Services.AddScoped<IEFMessageRepository, EFMessageRepository>();
builder.Services.AddScoped<IEFImageRepository, EFImageRepository>();
builder.Services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();*/


var app = builder.Build();


//////////////////////////////////////////
// MIDDLEWARE - ����Ū� ������� ������
// Configure the HTTP request pipeline.
//////////////////////////////////////////


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
