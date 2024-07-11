using ErrorOr;
using MediatR;
using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Application;

public record FindTaskListByIdQuery(
    Guid TaskListId) : IRequest<ErrorOr<TaskList>>;
