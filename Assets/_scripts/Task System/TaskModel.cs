using System;
using System.Collections.Generic;
using UnityEngine;

namespace _scripts.Task_System
{
    [CreateAssetMenu(fileName = "TaskList", menuName = "Task System/TaskList")]
    public class TaskList : ScriptableObject //Objeto para crear las tareas
    {
        public List<TaskModel> tasks;
    }

    [System.Serializable]
    public class TaskModel //Estas son las definiciones publicas de la tarea
    {      
        public string TaskName { get; private set; }
        public string Description { get; private set; }
        public TaskType TaskType { get; private set; }
                
        public bool IsCompleted { get; private set; }
        
        public event Action OnTaskCompleted; //Evento propio de las tareas que indica su estado de completado
        
        public TaskModel(TaskData taskData) //Un constructor para la clase TaskModel
        {
            TaskName = taskData.taskName;
            Description = taskData.description;
            TaskType = taskData.taskType;
            IsCompleted = false;
        }
              
        public void CompleteTask() //Metodo con la logica para el estado de completado
        {
            if (IsCompleted) return;
            IsCompleted = true;
            OnTaskCompleted?.Invoke();
        }
      /*  public bool IsTargetReached(int currentCount)
        {
            return currentCount >= targetCount;
        }

        public bool IsAtTargetPoint(Transform playerPosition)
        {
            return playerPosition.position == targetPoint.position;
        }


        // Método general para verificar si la tarea se completa
        public bool CheckTaskCompletion(int currentCount, Transform playerPosition, float elapsedTime)
        {
            switch (taskType)
            {
                case TaskType.Collection:
                    return IsTargetReached(currentCount);

                case TaskType.Delivery:
                    return IsTargetReached(currentCount) && IsAtTargetPoint(playerPosition);

                case TaskType.Interaction:
                    return IsAtTargetPoint(playerPosition);

                default:
                    return false;
            }
        }*/
    }
}
  
