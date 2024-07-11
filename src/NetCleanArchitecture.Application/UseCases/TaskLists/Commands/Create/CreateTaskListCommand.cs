using ErrorOr;

using MediatR;

namespace NetCleanArchitecture.Application;

public record CreateTaskListCommand(
    string Name) : IRequest<ErrorOr<Guid>>;
