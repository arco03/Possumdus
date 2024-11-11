using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskView : MonoBehaviour
{
    public TaskController taskController; // Referencia al controlador de tareas.
    public Transform taskPanelParent; // El contenedor de los elementos de UI para cada tarea.
    public GameObject taskUIPrefab; // Prefab para mostrar cada tarea en la UI.

    private Dictionary<int, TextMeshProUGUI> taskTextElements = new Dictionary<int, TextMeshProUGUI>(); // Almacena cada tarea con su elemento UI.

    private void Start()
    {
        InitializeUI();
    }

    // Método para inicializar la UI y crear un elemento visual por cada tarea.
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
                // Instanciamos el prefab para cada tarea.
                GameObject taskUI = Instantiate(taskUIPrefab, taskPanelParent);
                TextMeshProUGUI taskText = taskUI.GetComponentInChildren<TextMeshProUGUI>();

                if (taskText != null)
                {
                    // Inicializamos el texto en base al progreso de la tarea.
                    taskText.text = $"Tarea {task.idTask}: {task.currentAmount}/{task.requiredAmount}";
                    taskTextElements.Add(task.idTask, taskText);

                    // Registramos los eventos para el progreso de la tarea y la finalización.
                    task.onProgressUpdate += (taskId, currentAmount, requiredAmount) => UpdateTaskProgress(taskId, currentAmount, requiredAmount);
                    task.onReachedTask += () => OnTaskCompleted(task);
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

    // Método para actualizar el texto de la tarea cuando está completada
    public void OnTaskCompleted(Tasks completedTask)
    {
        if (taskTextElements.ContainsKey(completedTask.idTask))
        {
            // Obtener el texto de la tarea
            TextMeshProUGUI taskText = taskTextElements[completedTask.idTask];

            // Cambiar el texto de la tarea a "completada"
            taskText.text = $"Tarea {completedTask.idTask} completada!";
        }
        else
        {
            Debug.LogWarning($"No se encontró UI para la tarea {completedTask.idTask}. Verifique que la tarea esté correctamente asignada.");
        }
    }

    // Método para actualizar el progreso de la tarea
    public void UpdateTaskProgress(int taskId, int currentAmount, int requiredAmount)
    {
        if (taskTextElements.ContainsKey(taskId))
        {
            TextMeshProUGUI taskText = taskTextElements[taskId];
            // Actualizamos el texto del progreso de la tarea.
            taskText.text = $"Tarea {taskId}: {currentAmount}/{requiredAmount}";

            // Si la tarea se ha completado, actualizamos su estado.
            if (currentAmount >= requiredAmount)
            {
                // Esto asegura que el mensaje de tarea completada se muestre una vez alcanzado el progreso.
             //   OnTaskCompleted(taskController.GetTaskById(taskId));
            }
        }
        else
        {
            Debug.LogWarning($"No se encontró UI para la tarea {taskId}. Verifique que la tarea esté correctamente asignada.");
        }
    }
}


