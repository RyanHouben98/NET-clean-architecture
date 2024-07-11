using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Application;

public interface IGenericRepository<TEntity, TEntityId>
    where TEntityId : ValueObject
    where TEntity : AggregateRoot<TEntityId>
{
    Task<List<TEntity>> ListAsync();
    Task<TEntity?> FindByIdAsync(TEntityId id);
    Task<TEntityId> InsertAsync(TEntity entity);
    void Delete(TEntity entity);
}
