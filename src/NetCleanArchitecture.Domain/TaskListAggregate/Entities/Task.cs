namespace NetCleanArchitecture.Domain;

public sealed class Task : Entity<TaskId>
{
    public string Name { get; }
    public string Description { get; }
    public bool IsCompleted { get; }
    public TaskListId TaskListId { get; }

    private Task(
        string name,
        string description,
        bool isCompleted,
        TaskListId taskListId,
        TaskId? id = null) : base(id ?? TaskId.CreateUnique())
    {
        Name = name;
        Description = description;
        TaskListId = taskListId;
        IsCompleted = isCompleted;
    }

    public static Task Create(
        string name,
        string description,
        TaskListId taskListId)
    {
        return new Task(name, description, false, taskListId);
    }
}
