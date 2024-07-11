using Microsoft.EntityFrameworkCore;
using NetCleanArchitecture.Application;
using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Infrastructure;

public class GenericRepository<TEntity, TEntityId>(ApplicationDbContext applicationDbContext) : IGenericRepository<TEntity, TEntityId>
    where TEntityId : ValueObject
    where TEntity : AggregateRoot<TEntityId>
{
    public void Delete(TEntity entity)
    {
        applicationDbContext
            .Set<TEntity>()
            .Remove(entity);
    }

    public async Task<TEntity?> FindByIdAsync(TEntityId id)
    {
        return await applicationDbContext
            .Set<TEntity>()
            .FindAsync(id);
    }

    public async Task<TEntityId> InsertAsync(TEntity entity)
    {
        var result = await applicationDbContext
            .Set<TEntity>()
            .AddAsync(entity);
        
        return result.Entity.Id;
    }

    public async Task<List<TEntity>> ListAsync()
    {
        return await applicationDbContext
            .Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }
}
