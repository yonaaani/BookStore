
using MyEventsAdoNetDb.Repositories.Contracts;

namespace MyEventsAdoNetDB.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IBookListRepository _booklistRepository { get; }

        void Commit();
        void Dispose();
    }
}
