using ErrorOr;
using MediatR;
using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Application;

public class FindTaskListByIdQueryHandler(ITaskListRepository taskListRepository) : IRequestHandler<FindTaskListByIdQuery, ErrorOr<TaskList>>
{
    public async Task<ErrorOr<TaskList>> Handle(FindTaskListByIdQuery request, CancellationToken cancellationToken)
    {
        var taskListId = TaskListId.Create(request.TaskListId);

        var taskList = await taskListRepository.FindByIdAsync(taskListId);

        if (taskList is null) 
        {
            return Errors.TaskList.NotFound;
        }

        return taskList;
    }
}
