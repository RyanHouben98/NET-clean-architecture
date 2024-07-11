using ErrorOr;

namespace NetCleanArchitecture.Domain;

public sealed class TaskList : AggregateRoot<TaskListId>
{
    private readonly List<Task> _tasks = [];
    public string Name { get; }
    public IReadOnlyList<Task> Tasks => _tasks.ToList();

    private TaskList(
        string name,
        TaskListId? id = null) : base(id ?? TaskListId.CreateUnique())
    {
        Name = name;
    }

    public static ErrorOr<TaskList> Create(string name)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(name)) 
        {
            errors.Add(Errors.TaskList.NameEmpty);
        }

        if (name.Length > 100) 
        {
            errors.Add(Errors.TaskList.NameTooLong);
        }

        if (errors.Count > 0) {
            return errors;
        }

        return new TaskList(name);
    }

    public void AddTask(string name, string description)
    {
        var task = new Task(name, description, false, Id);

        _tasks.Add(task);
    }
}
