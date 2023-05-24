using MyBookListEntityFrameforkDAL.Entities;
using MyBookListEntityFrameforkDAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyEventsAdoNetDb.Entities;
using MyBookListEntityFrameworkDAL;

namespace MyBookListEntityFrameforkDAL.Data.Repositories;

public class EventRepository : GenericRepository<Events>, IEventRepository
{
    public EventRepository(EventsContext databaseContext)
        : base(databaseContext)
    {
    }

    //Eager Loading
    public async Task<IEnumerable<Events>> GetEventsSortedByDateAsync()
    {
        return await databaseContext.Set<Events>()
            .Include(e => e.BookList)
            .OrderBy(e => e.EventDate) // Сортування за датою
            .ToListAsync();
    }

    //Explicit Loading
    public override async Task<Events> GetCompleteEntityAsync(int id)
    {
        var eventEntity = await databaseContext.Set<Events>()
            .FindAsync(id);

        if (eventEntity != null)
        {
            await databaseContext.Entry(eventEntity)
                .Collection(e => e.EventOthers)
                .LoadAsync();

            await databaseContext.Entry(eventEntity)
                .Collection(e => e.EventNewBooks)
                .LoadAsync();

            await databaseContext.Entry(eventEntity)
                .Collection(e => e.EventFilms)
                .LoadAsync();

            await databaseContext.Entry(eventEntity)
                .Collection(e => e.EventDiscounts)
                .LoadAsync();

            await databaseContext.Entry(eventEntity)
                .Reference(e => e.BookList)
                .LoadAsync();

            await databaseContext.Entry(eventEntity)
                .Reference(e => e.Users)
                .LoadAsync();
        }

        return eventEntity;
    }
        
        public async Task<IEnumerable<Events>> GetEventsSortedByNameAsync()
    {
        return await databaseContext.Set<Events>()
        .OrderBy(e => e.EventName) // Сортування за EventName
        .ToListAsync();
    }

    //іструментарію  Linq  To  Entities  (багато  до  багатьох  із  використанням проміжної сутності)
    // LINQ to Entities
    public async Task<bool> UserHasEventsAsync(int userId, List<int> eventIds)
    {
        return await databaseContext.Set<Events>()
            .AnyAsync(e => e.Users.IDUser == userId && eventIds.Contains(e.IDEvent));
    }


}