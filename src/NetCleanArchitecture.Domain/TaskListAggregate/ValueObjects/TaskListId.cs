
namespace NetCleanArchitecture.Domain;

public sealed class TaskListId : ValueObject
{
    public Guid Value { get; }

    private TaskListId(Guid value) 
    {
        Value = value;
    }

    public static TaskListId CreateUnique()
    {
        return new TaskListId(Guid.NewGuid());
    }

    public static TaskListId Create(Guid value)
    {
        return new TaskListId(value);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
