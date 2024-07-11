
using ErrorOr;

using MediatR;

using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Application;

public class ListTaskListsQueryHandler(ITaskListRepository taskListRepository) : IRequestHandler<ListTaskListsQuery, ErrorOr<List<TaskList>>>
{
    public async Task<ErrorOr<List<TaskList>>> Handle(ListTaskListsQuery request, CancellationToken cancellationToken)
    {
        var result = await taskListRepository.ListAsync();

        return result;
    }
}
