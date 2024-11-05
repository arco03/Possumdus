using System.Collections.Generic;


public class TaskSystem
{
    private readonly List<Task> tasks;

    public event System.Action OnAllTasksCompleted;

    public TaskSystem(TaskListData taskData)
    {
        tasks = new List<Task>();

        // Inicializar cada tarea a partir del TaskListData
        foreach (var taskInfo in taskData.tasks)
        {
            var task = new Task(taskInfo.taskName, taskInfo.description);
            task.OnTaskCompleted += CheckAllTasksCompleted;
            tasks.Add(task);
        }
    }

    private void CheckAllTasksCompleted()
    {
        if (tasks.TrueForAll(t => t.IsCompleted))
        {
            OnAllTasksCompleted?.Invoke();
        }
    }

    public void CompleteTask(string taskName)
    {
        Task task = tasks.Find(t => t.TaskName == taskName);
        if (task != null && !task.IsCompleted)
        {
            task.CompleteTask();
        }
    }

    public List<Task> GetTasks() => tasks;
}
