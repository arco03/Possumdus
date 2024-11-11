using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public List<DeliveryTasks> tasks = new List<DeliveryTasks>(); // Lista de DeliveryTasks, agregados manualmente
    public TaskView taskView;  // Referencia al script TaskView para actualizar la UI

    // Este método se llama cuando se inicia el juego
    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Buscar el TaskView en la escena si no está asignado en el Inspector
        if (taskView == null)
        {
            taskView = FindObjectOfType<TaskView>();
        }
                
        // Suscribir al evento de cada tarea para actualizar la UI cuando se complete
        foreach (var task in tasks)
        {
            task.onReachedTask += () => OnTaskCompleted(task);
            task.onProgressUpdate += UpdateTaskProgress;
        }
    }


    // Este método se usa para añadir tareas manualmente en el Inspector
    public void AddTask(DeliveryTasks task)
    {
        if (tasks != null && !tasks.Contains(task))
        {
            tasks.Add(task);
            task.onReachedTask += () => OnTaskCompleted(task); // Suscribir al evento de la tarea
        }
    }
       
    public void UpdateTaskProgress(int taskId, int currentAmount, int requiredAmount)
    {
        // Llama a UpdateTaskProgress de TaskView para actualizar la UI
        taskView.UpdateTaskProgress(taskId, currentAmount, requiredAmount);
    }
    

    // Este método se llama cuando una tarea se completa
    private void OnTaskCompleted(DeliveryTasks completedTask)
    {
        Debug.Log($"Task {completedTask.idTask} completed!");

        // Actualizar la vista cuando una tarea se complete
        if (taskView != null)
        {
            taskView.OnTaskCompleted(completedTask);
        }
    }

    public void VerifyAllTasks()
    {
        foreach (var task in tasks)
        {
            if (task != null && !task.isReached)  // Solo verifica tareas no completadas
            {
                task.TaskVerification();  // Llama a la verificación solo si la tarea no está completada
            }
        }
    }
        
}


