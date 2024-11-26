using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _scripts.TaskSystem.NewTaskSystem
{
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
                Debug.LogError("Una o m�s referencias en TaskView no est�n asignadas.");
                return;
            }

            foreach (var task in taskController.tasks)
            {
                if (task == null)
                {
                    Debug.LogWarning("Se encontr� una tarea nula en la lista de tareas.");
                    continue;
                }

                if (taskTextElements.ContainsKey(task.idTask))
                {
                    Debug.LogWarning($"La tarea con ID {task.idTask} ya est� registrada en el diccionario.");
                    continue;
                } 
            
                GameObject taskUI = Instantiate(taskUIPrefab, taskPanelParent);
                TextMeshProUGUI taskText = taskUI.GetComponentInChildren<TextMeshProUGUI>();

           
                if (taskText != null)
                {
                    taskText.text = $"{task.description}";
                    taskTextElements.Add(task.idTask, taskText);
                    Debug.Log($"UI para tarea {task.idTask} registrada correctamente.");
                    task.onReachedTask += () => OnTaskCompleted(task);
                    Debug.Log("OnTaskCompleted se ha llamado en el initialize");
                
                
                }
                else
                {
                    Debug.LogError("El prefab taskUIPrefab no tiene un componente TextMeshProUGUI en su jerarqu�a.");
                }
            }
        }

    
        public void UpdateTaskText(Tasks tasks_)
        {
            if (taskTextElements.TryGetValue(tasks_.idTask, out var taskText))
            {
                if (tasks_.isReached)
                {
                    // Texto de victoria, utilizando la variable 'reachedTask' de cada tarea si la tarea fue completada
                    taskText.text = $"¡{tasks_.reachedTask}";
                }
                else
                {
                    // Texto de progreso
                    taskText.text = $"{tasks_.description}";
                }
            }
            else
            {
                Debug.LogWarning($"No se encontró UI para la tarea {tasks_.idTask}. Verifique que la tarea esté correctamente registrada en InitializeUI.");
            }
        }                                  
   
        public void OnTaskCompleted(Tasks completedTask)
        {
            completedTask.isReached = true;
        
            UpdateTaskText(completedTask);
        
        
        }

  
    }
}


