using NetCleanArchitecture.Application;
using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Infrastructure;

public class TaskListRepository : GenericRepository<TaskList, TaskListId>, ITaskListRepository
{
    public TaskListRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {

    }
}
