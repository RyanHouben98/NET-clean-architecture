using ErrorOr;

using MediatR;

using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Application;

public record ListTaskListsQuery() : IRequest<ErrorOr<List<TaskList>>>;
