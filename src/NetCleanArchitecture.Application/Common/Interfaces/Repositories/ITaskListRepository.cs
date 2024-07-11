using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Application;

public interface ITaskListRepository : IGenericRepository<TaskList, TaskListId>
{

}
