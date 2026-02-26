using SQLitePCL;
using Microsoft.EntityFrameworkCore;

namespace Mission_08.Models;

public class EFTasksRepository : ITasksRepository
{
    private TaskItemsContext _context;
    
    public EFTasksRepository(TaskItemsContext temp)
    {
        _context = temp;
    }

    public List<TaskItem> TaskItems =>_context.TaskItems.Include(t => t.Category).ToList();
    public List<Category> Categories => _context.Categories.ToList();
    public void AddTask(TaskItem taskItem)
    {
        _context.Add(taskItem);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskItem taskItem)
    {
        _context.Update(taskItem);
        _context.SaveChanges();
    }

    public void DeleteTask(TaskItem taskItem)
    {
        _context.Remove(taskItem);
        _context.SaveChanges();
    }
}