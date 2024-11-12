using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static Tasks;

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
            if (task == null)
            {
                Debug.LogWarning("Se encontró una tarea nula en la lista de tareas.");
                continue;
            }

            if (taskTextElements.ContainsKey(task.idTask))
            {
                Debug.LogWarning($"La tarea con ID {task.idTask} ya está registrada en el diccionario.");
                continue;
            }

            DeliveryTasks deliveryTask = task.GetComponent<DeliveryTasks>();

            GameObject taskUI = Instantiate(taskUIPrefab, taskPanelParent);
            TextMeshProUGUI taskText = taskUI.GetComponentInChildren<TextMeshProUGUI>();

            if (deliveryTask != null)
            {
                Debug.Log($"La tarea con ID {deliveryTask.idTask} tiene el componente DeliveryTasks.");
                deliveryTask.onProgressUpdate += (idTask, currentAmount, requiredAmount, isReached) => UpdateTaskText(deliveryTask.names, deliveryTask.idTask, deliveryTask.currentAmount, deliveryTask.requiredAmount, deliveryTask.isReached);
                task.onReachedTask += () => OnDeliveryCompleted(deliveryTask);

                if (taskText != null)
                {
                    
                    taskTextElements.Add(task.idTask, taskText);
                    Debug.Log($"UI para tarea {task.idTask} registrada correctamente.");
                }
            }
            else if (taskText != null)
            {
                taskText.text = $"Tarea {task.names} No ha sido completada";
                taskTextElements.Add(task.idTask, taskText);
                Debug.Log($"UI para tarea {task.idTask} registrada correctamente.");

                task.onReachedTask += () => OnTaskCompleted(task);
            }
            else
            {
                Debug.LogError("El prefab taskUIPrefab no tiene un componente TextMeshProUGUI en su jerarquía.");
            }
        }
    }

    
    public void UpdateTaskText(string name = null, int taskId = 0, int currentAmount = 0, int requiredAmount = 0, bool isReached = false, TaskType taskType = TaskType.General)
    {
        if (taskTextElements.TryGetValue(taskId, out var taskText))
        {
            if (taskType == TaskType.Delivery)
            {
                taskText.text = isReached ? $"{name} completada!" : $"{name}: {currentAmount}/{requiredAmount}";
            }
            else if (taskType == TaskType.Interaction)
            {
                taskText.text = isReached ? $"{name} completada!" : $"{name}";
            }

        }
        else
        {
            Debug.LogWarning($"No se encontró UI para la tarea {taskId}. Verifique que la tarea esté correctamente registrada en InitializeUI.");
        }
    }                                  
   
    public void OnTaskCompleted(Tasks completedTask)
    {
        UpdateTaskText(completedTask.names, completedTask.idTask,0,0,false, TaskType.Interaction);
    }

    public void OnDeliveryCompleted(DeliveryTasks deliveryTasks)
    {
      UpdateTaskText(deliveryTasks.names,deliveryTasks.idTask, deliveryTasks.currentAmount, deliveryTasks.requiredAmount, true, TaskType.Delivery);
    }
}


