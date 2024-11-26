using System;
using UnityEngine;

namespace _scripts.TaskSystem
{
  public class Tasks : ScriptableObject
    {
        [Header("General Task Atributes")]
        public string names;
        public string description;
        public int idTask;
        public bool isReached = false;
        public string reachedTask;
        public TaskType taskType;
        public event Action onReachedTask;

        public virtual void TaskVerification()
        {
        
            if (!isReached)
            {
                InvokeReachedEvent();
                isReached = true;
            }

        }

        public void InvokeReachedEvent()
        {
            onReachedTask?.Invoke();
        }

        [System.Serializable]
        public enum TaskType
        {
            Interaction,
            Delivery,
            UITask
        }

    



    }
}
