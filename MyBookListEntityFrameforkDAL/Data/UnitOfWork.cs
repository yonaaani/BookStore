using MyBookListEntityFrameforkDAL.Interfaces.Repositories;
using MyBookListEntityFrameforkDAL.Interfaces;
using MyBookListEntityFrameworkDAL;

namespace MyBookListEntityFrameforkDAL.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly EventsContext databaseContext;

    public IEventRepository EventRepository { get; }


    public UnitOfWork(
        EventsContext databaseContext,
        IEventRepository EventRepository)
    {
        this.databaseContext = databaseContext;
        this.EventRepository = EventRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}