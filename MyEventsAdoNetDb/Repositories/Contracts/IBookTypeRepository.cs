using Dapper_Example.DAL;

namespace MyEventsAdoNetDB.Repositories.Contracts
{
    public interface IBookTypeRepository : IGenericRepository<BookList>
    {
        Task<IEnumerable<BookList>> GetAsync();
    }
}
