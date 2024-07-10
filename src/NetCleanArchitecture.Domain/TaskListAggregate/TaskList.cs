﻿namespace NetCleanArchitecture.Domain;

public sealed class TaskList : AggregateRoot<TaskListId>
{
    private HashSet<Task> _tasks = [];
    public string Name { get; }
    public IReadOnlyList<Task> Tasks => _tasks.ToList();

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

    public void AddTask(string name, string description)
    {
        var task = new Task(name, description, false, Id);

        _tasks.Add(task);
    }
}