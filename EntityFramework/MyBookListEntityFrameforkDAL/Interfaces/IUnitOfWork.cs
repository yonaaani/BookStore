using MyBookListEntityFrameforkDAL.Interfaces.Repositories;

namespace MyBookListEntityFrameforkDAL.Interfaces;

public interface IUnitOfWork
{
    IEventRepository EventRepository { get; }
    Task SaveChangesAsync();
}