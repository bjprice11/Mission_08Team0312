using SQLitePCL;

namespace Mission_08.Models;

public class EFTasksRepository : ITasksRepository
{
    private TaskItemsContext _context;
    
    public EFTasksRepository(TaskItemsContext temp)
    {
        _context = temp;
    }

    public List<TaskItem> TaskItems =>_context.TaskItems.ToList();
}