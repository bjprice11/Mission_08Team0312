namespace Mission_08.Models;

public interface ITasksRepository
{
    List<TaskItem> TaskItems { get; }
}