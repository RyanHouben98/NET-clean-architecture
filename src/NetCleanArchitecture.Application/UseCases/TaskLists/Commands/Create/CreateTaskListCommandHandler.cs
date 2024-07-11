
using ErrorOr;

using MediatR;

using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Application;

public class CreateTaskListCommandHandler(
    ITaskListRepository taskListRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateTaskListCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        var taskListCreateResult = TaskList.Create(request.Name);

        if (taskListCreateResult.IsError) 
        {
            return taskListCreateResult.Errors;
        }

        var result = await taskListRepository.InsertAsync(taskListCreateResult.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value;
    }
}
