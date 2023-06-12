using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyBookListEntityFrameforkDAL.Entities;
using MyBookListEntityFrameworkBLL.DTO;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Реєстрація служби IMapper
        services.AddAutoMapper(typeof(Startup));

        // ...
    }

    // ...
}

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Events, EventsDTO>();
    }
}
