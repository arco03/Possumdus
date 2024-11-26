using System.Collections.Generic;
using UnityEngine;

namespace _scripts.TaskSystem.NewTaskSystem
{
    public class TaskController : MonoBehaviour
    {
        public List<Tasks> tasks;
        public TaskView taskView;  // Referencia al script TaskView para actualizar la UI

        // Este m�todo se llama cuando se inicia el juego
        private void Start()
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            // Buscar el TaskView en la escena si no est� asignado en el Inspector
            if (taskView == null)
            {
                taskView = FindObjectOfType<TaskView>();
            }
                
            // Suscribir al evento de cada tarea para actualizar la UI cuando se complete
            foreach (var task in tasks)
            {
                task.onReachedTask += () => OnTaskCompleted(task);
            
            }
        }


        // Este m�todo se usa para a�adir tareas manualmente en el Inspector
        public void AddTask(Tasks task)
        {
            if (tasks != null && !tasks.Contains(task))
            {
                tasks.Add(task);
                task.onReachedTask += () => OnTaskCompleted(task); // Suscribir al evento de la tarea
            }
        }

        // Este m�todo se llama cuando una tarea se completa
        private void OnTaskCompleted(Tasks completedTask)
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
                    task.TaskVerification();  // Llama a la verificaci�n solo si la tarea no est� completada
                }
            }
        }
        
    }
}


