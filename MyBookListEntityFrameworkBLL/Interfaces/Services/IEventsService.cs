using MyBookListEntityFrameworkBLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBookListEntityFrameworkBLL.Interfaces.Services
{
    public interface IEventsService
    {
        Task<IEnumerable<EventsDTO>> GetAllAsync();
        Task<EventsDTO> GetByIdAsync(int eventId);
        Task AddAsync(EventsDTO eventDto);
        Task UpdateAsync(EventsDTO eventDto);
        Task DeleteAsync(int eventId);
    }
}
