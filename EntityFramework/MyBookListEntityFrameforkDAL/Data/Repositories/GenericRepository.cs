using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameforkDAL.Exceptions;
using MyBookListEntityFrameforkDAL.Interfaces.Repositories;
using MyBookListEntityFrameworkDAL;

namespace MyBookListEntityFrameforkDAL.Data.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    // properties
    protected readonly EventsContext databaseContext;
    protected readonly DbSet<TEntity> table;

    // constructor
    public GenericRepository(EventsContext databaseContext)
    {
        this.databaseContext = databaseContext;
        table = this.databaseContext.Set<TEntity>();
    }

    // CRUD methods
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await table.ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await table.FindAsync(id)
            ?? throw new EntityNotFoundException(
                GetEntityNotFoundErrorMessage(id));
    }

    public virtual async Task AddAsync(TEntity entity) =>
        await table.AddAsync(entity);

    public virtual async Task UpdateAsync(TEntity entity) =>
        await Task.Run(() => table.Update(entity));

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        await Task.Run(() => table.Remove(entity));
    }


    // get full entity with all objects
    public abstract Task<TEntity> GetCompleteEntityAsync(int id);

    // message
    protected static string GetEntityNotFoundErrorMessage(int id) =>
        $"{typeof(TEntity).Name} with id {id} not found.";
}