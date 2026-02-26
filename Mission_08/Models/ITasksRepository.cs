namespace Mission_08.Models;

public interface ITasksRepository
{
    List<TaskItem> TaskItems { get; }
    List<Category> Categories { get; }

    public void AddTask(TaskItem taskItem);
    
    public void UpdateTask(TaskItem taskItem);
    
    public void DeleteTask(TaskItem taskItem);
}