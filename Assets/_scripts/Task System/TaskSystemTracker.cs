using System.Collections.Generic;
using System;
using UnityEngine;

namespace _scripts.Task_System
{
    public class TaskSystemTracker : MonoBehaviour
    {
        private TaskSystemController taskSystem;

        public void Initialize(TaskSystemController system)
        {
            taskSystem = system;

            // Suscribirse al evento OnTaskCompleted de cada tarea
            foreach (var task in taskSystem.GetTasks())
            {
                task.OnTaskCompleted += OnTaskCompleted;
            }
        }

        // Método para agregar un objeto a la misión de recolección
        public void Collect(string taskName)
        {
            TaskModel task = taskSystem.GetTasks().Find(t => t.TaskName == taskName);
            if (task != null && !task.IsCompleted)
            {
                //task.CollectItem();
                return;
            }
        }

        // Verificar si la tarea se completa en el punto de entrega
        public void CheckCompletionAtDeliveryPoint(string taskName, Transform playerPosition)
        {
            TaskModel task = taskSystem.GetTasks().Find(t => t.TaskName == taskName);
            if (task != null && !task.IsCompleted)
            {
                //task.CompleteTaskAtPoint(playerPosition);
                return;
            }
        }

        private void OnTaskCompleted()
        {
            Debug.Log("Task completed!!!");
        }
    }
}
