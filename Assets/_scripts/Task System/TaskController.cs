using System;
using UnityEngine;

namespace _scripts.Task_System
{
   public class TaskController: MonoBehaviour
   {
       private TaskModel _taskModel;
       public event Action OnTaskCompleted; 
       public event Action OnAllTasksCompleted;
       
        public void CompleteTask(string taskName){
           
            var task = _taskModel.tasksList.Find(t => t.taskName == taskName);
            if (!task.isCompleted) return;
            task.isCompleted = true;
            OnTaskCompleted?.Invoke();
            CheckAllTasksCompleted();
        }
        
        private void CheckAllTasksCompleted()
        {
            if (_taskModel.tasksList.TrueForAll(t => t.isCompleted))
            {
                OnAllTasksCompleted?.Invoke();
            }
        }
      
    }

    
   
}
  
