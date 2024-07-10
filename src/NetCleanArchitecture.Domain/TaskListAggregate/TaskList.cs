namespace NetCleanArchitecture.Domain;

public sealed class TaskList : AggregateRoot<TaskListId>
{
    public string Name { get; }

    private TaskList(
        string name,
        TaskListId? id = null) : base(id ?? TaskListId.CreateUnique())
    {
        Name = name;
    }

    public static TaskList Create(string name)
    {
        return new TaskList(name);
    }
}
