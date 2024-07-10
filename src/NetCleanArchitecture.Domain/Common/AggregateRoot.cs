namespace NetCleanArchitecture.Domain;

public class AggregateRoot<TEntityId> : Entity<TEntityId>
    where TEntityId : class
{
    protected AggregateRoot(TEntityId id) : base(id)
    {

    }
}
