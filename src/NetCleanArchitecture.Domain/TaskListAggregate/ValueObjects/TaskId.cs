
namespace NetCleanArchitecture.Domain;

public sealed class TaskId : ValueObject
{
    public Guid Value { get; }

    private TaskId(Guid value)
    {
        Value = value;
    }

    public static TaskId CreateUnique()
    {
        return new TaskId(Guid.NewGuid());
    }

    public static TaskId Create(Guid value)
    {
        return new TaskId(value);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
