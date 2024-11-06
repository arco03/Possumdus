using System;
using System.Collections.Generic;
using UnityEngine;

namespace _scripts.Task_System
{
   public class TaskController: MonoBehaviour
   {
       private TaskModel _taskModel;
       public event Action OnTaskCompleted; 
       public event Action OnAllTasksCompleted;
       
        public void CompleteTask(string taskName){
           
            TaskStruct task = _taskModel.TasksList.Find(t => t.TaskName == taskName); 
            if (!task.IsCompleted)
            {
              task.IsCompleted = true;
              OnTaskCompleted?.Invoke();
              CheckAllTasksCompleted();
            }
        }
        
        private void CheckAllTasksCompleted()
        {
            if (_taskModel.TasksList.TrueForAll(t => t.IsCompleted))
            {
                OnAllTasksCompleted?.Invoke();
            }
        }
      
    }

    
   
}
  
