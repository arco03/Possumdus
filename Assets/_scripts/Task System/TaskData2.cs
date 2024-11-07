using UnityEngine;

namespace _scripts.Task_System
{
    public class TaskData2 
    {
        public string taskName;
        public string description;
        public int id;
        public TaskTypes taskTypes;
        public bool isCompleted; 
        //Delivery tasks
        public GameObject targetPoint;
        //Interaction tasks
        public InteractionPoints[] interPoints;
   
        [System.Serializable]
        public struct InteractionPoints
        {
            public Transform interactionTasks;
        } 
    }
    
    public enum TaskTypes
    {
        Delivery,     
        Interaction   
    }
 
}

