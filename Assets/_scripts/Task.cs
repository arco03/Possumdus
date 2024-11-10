using UnityEngine;
using System.Collections.Generic;


namespace _scripts.TaskSystem
{
    public class Task
    {
        public string Name;
        public bool IsComplete = false;
        public int ID;
        public TaskType TasksType;

        [Header("Delivery destination")] 
        public GameObject Destinaiton;

        [Header("CollectionItems")]
        public List<TaskData.Task.CollectItems> CollectItems = new List<TaskData.Task.CollectItems>();

        public enum TaskType
        {
            Delivery,
            Interaction,
            Collect
        }

    }
}
