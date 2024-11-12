using System;
using UnityEngine;

namespace _scripts.TaskSystem
{
  public class Tasks : ScriptableObject
    {
   
        public string names;
        public string description;
        public int idTask;
        public bool isReached = false;
        public TaskType taskType;
        public string reachedTask = "Task Completed!";
        public event Action onReachedTask;

        public virtual void TaskVerification()
        {
        
            if (!isReached)
            {
                InvokeReachedEvent();
                isReached = true;
            }

        }

        protected void InvokeReachedEvent()
        {
            onReachedTask?.Invoke();
        }

        [System.Serializable]
        public enum TaskType
        {
            Interaction,
            Delivery,
            General
        }

    



    }
}
