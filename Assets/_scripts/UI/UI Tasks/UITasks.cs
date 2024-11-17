using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _scripts.TaskSystem
{
    public class UITasks : Tasks
    {
        public bool isActive = false;
        public bool isCompleted = false;
        

#if UNITY_EDITOR
        private void OnEnable()
        {
            isCompleted = false;
            isActive = false;
            base.isReached = false;
        }
#endif

        public void ActivateUITask()
        {
            isActive = true;                    
            Debug.Log($"Task {names} activated!");
        }

        public void CompleteUITask()
        {            
            base.InvokeReachedEvent();
            isCompleted = true;
            isActive = false;
         }

       

     }
}


