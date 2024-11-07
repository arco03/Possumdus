using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _scripts.Task_System
{
    [CreateAssetMenu(fileName = "Tasks", menuName = "Task System/Tasks")]
    public class TaskModel2 : ScriptableObject
    {
        [System.Serializable]
        public struct TasksStruct
        {
            public string taskName;
            public string description;
            public int id;
            public TaskTypes taskTypes;

            public enum TaskTypes
            {
                Delivery,
                Interaction
            }
            
            [Header ("Delivery Tasks")]
            public List<RequiredItems> requiredItems;
            
            [System.Serializable]
            public struct RequiredItems
            {
                public string itemName;
                public int amount;
                public int itemId;
            }
            
        }

        public TasksStruct[] tasks;
    } 
}

    

