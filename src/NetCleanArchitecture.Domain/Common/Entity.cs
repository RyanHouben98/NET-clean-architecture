namespace NetCleanArchitecture.Domain;

public abstract class Entity<TEntityId> 
    where TEntityId : class
{
    public TEntityId Id { get; }

    protected Entity(TEntityId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) 
        {
            return false;
        }

        return ((Entity<TEntityId>)obj).Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
