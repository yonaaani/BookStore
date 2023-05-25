using AutoMapper;
using MyBookListEntityFrameforkDAL.Entities;

namespace MyBookListEntityFrameworkBLL.DTO
{
    public class EventsDTO
    {
        public int IDEvent { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventText { get; set; }

        // Налаштування карт перетворення
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Events, EventsDTO>();
        }
    }
}
