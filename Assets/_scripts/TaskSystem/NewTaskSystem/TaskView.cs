using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskView : MonoBehaviour
{
    public TaskController taskController; // Referencia al controlador de tareas.
    public Transform taskPanelParent; // Contenedor de los elementos de UI para cada tarea.
    public GameObject taskUIPrefab; // Prefab para mostrar cada tarea en la UI.

    private Dictionary<int, TextMeshProUGUI> taskTextElements = new Dictionary<int, TextMeshProUGUI>();

    private void Start()
    {
        InitializeUI();
    }

    // Inicializa la UI y crea un elemento visual por cada tarea.
    private void InitializeUI()
    {
        if (taskController == null || taskUIPrefab == null || taskPanelParent == null)
        {
            Debug.LogError("Una o más referencias en TaskView no están asignadas.");
            return;
        }

        foreach (var task in taskController.tasks)
        {
            if (task != null)
            {
                GameObject taskUI = Instantiate(taskUIPrefab, taskPanelParent);
                TextMeshProUGUI taskText = taskUI.GetComponentInChildren<TextMeshProUGUI>();

                if (taskText != null)
                {
                    taskText.text = $"Tarea {task.idTask}: {task.currentAmount}/{task.requiredAmount}";
                    taskTextElements.Add(task.idTask, taskText);
                    Debug.Log($"UI para tarea {task.idTask} registrada correctamente.");

                    
                    task.onReachedTask += () => OnTaskCompleted(task);
                    task.onProgressUpdate += (idTask,currentAmount, requiredAmount, isReached) => UpdateTaskText(task.idTask, task.currentAmount, task.requiredAmount, task.isReached);
                }
                else
                {
                    Debug.LogError("El prefab taskUIPrefab no tiene un componente TextMeshProUGUI en su jerarquía.");
                }
            }
            else
            {
                Debug.LogWarning("Se encontró una tarea nula en la lista de tareas.");
            }
        }
    }

    // Actualiza el texto de una tarea específica.
    public void UpdateTaskText(int taskId, int currentAmount, int requiredAmount, bool isReached)
    {
        if (taskTextElements.TryGetValue(taskId, out var taskText))
        {
            taskText.text = isReached ? $"Tarea {taskId} completada!" : $"Tarea {taskId}: {currentAmount}/{requiredAmount}";
        }
        else
        {
            Debug.LogWarning($"No se encontró UI para la tarea {taskId}. Verifique que la tarea esté correctamente registrada en InitializeUI.");
        }
    }

    // Método para actualizar el texto de la tarea cuando esté completada.
    public void OnTaskCompleted(Tasks completedTask)
    {
        UpdateTaskText(completedTask.idTask, completedTask.currentAmount, completedTask.requiredAmount, true);
    }
}


