using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace _scripts.TaskSystem
{
    [CreateAssetMenu(fileName = "Tasks", menuName = "TaskData", order = 1)]
    public class TaskData : ScriptableObject
    {
        [System.Serializable]
        public struct Task
        {
            public string name;
            public string description;
            public int id;
            public TaskType taskType;

            [System.Serializable]
            public enum TaskType
            {
                Delivery,
                Interaction,
                Collect
                
            }

            [Header("Delivery Tasks")] 
            public List<CollectItems> Items;

            [System.Serializable]
            public struct CollectItems
            {
                public string name;
                public int amount;
                public int id;
            }
            
        }

        public Task[] Tasks;

    }
}
