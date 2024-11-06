using System.Collections.Generic;
using System;
using UnityEngine;

namespace _scripts.Task_System
{
    /*
    public class TaskSystemTracker : MonoBehaviour
    {
        private TaskModel _taskModel;
        public void Initialize(TaskController system)
        {
            _taskModel = system;

           
            foreach (var task in _taskModel.GetTasks())
            {
                task.OnTaskCompleted += OnTaskCompleted;
            }
        }

        // M�todo para agregar un objeto a la misi�n de recolecci�n
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
    }*/
}
