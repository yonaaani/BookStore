using AutoMapper;
using MyBookListEntityFrameworkBLL.DTO;
using MyBookListEntityFrameforkDAL.Entities;
using MyBookListEntityFrameforkDAL.Interfaces.Repositories;

namespace MyBookListEntityFrameworkBLL.Services
{
    public class EventsService
    {
        private readonly IEventRepository eventsRepository;
        private readonly IMapper mapper;

        public EventsService(IEventRepository eventsRepository, IMapper mapper)
        {
            this.eventsRepository = eventsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EventsDTO>> GetAllEventsAsync()
        {
            var events = await eventsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<Events>, IEnumerable<EventsDTO>>(events);
        }

        public async Task<EventsDTO> GetEventByIdAsync(int eventId)
        {
            var events = await eventsRepository.GetByIdAsync(eventId);
            return mapper.Map<Events, EventsDTO>(events);
        }

        public async Task CreateEventAsync(EventsDTO eventDto)
        {
            var events = mapper.Map<EventsDTO, Events>(eventDto);
            await eventsRepository.AddAsync(events);
        }

        public async Task UpdateEventAsync(EventsDTO eventDto)
        {
            var events = mapper.Map<EventsDTO, Events>(eventDto);
            await eventsRepository.UpdateAsync(events);
        }

        public async Task DeleteEventAsync(int eventId)
        {
            await eventsRepository.DeleteAsync(eventId);
        }
    }
}
