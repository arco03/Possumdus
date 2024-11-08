using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.Serialization;

namespace _scripts.TaskSystem
{
    public class TaskTracker : MonoBehaviour
    {
        public TaskData td;
        public List<Task> ActiveTasks = new List<Task>();
        public List<Task> FinishedTasks = new List<Task>(); 
        [HideInInspector] public List<TaskGiver> checkIn = new List<TaskGiver>();

        public void RefreshQuest(int questID, Task.TaskType type, int? amountItems = null)
        {
            var val = ActiveTasks.Find(x => x.ID == questID);
            if (type == Task.TaskType.Delivery)
            {
                if (val.Destinaiton.GetComponent<DestinationScript>())//.reached)
                {
                    Debug.LogWarning("Task: " + td.Tasks[val.ID].name + " completed!");
                    val.IsComplete = true;
                }
                else
                {
                    print("you haven't reached the destination");
                }
            } 

            if (type == Task.TaskType.Collect)
            {
                foreach (var item in val.CollectItems)
                {
                    if (amountItems != null)
                    {
                        if (amountItems == item.amount)
                        {
                            Debug.LogWarning("Task: " + td.Tasks[val.ID].name + " completed!");
                            val.IsComplete = true;
                        }
                        else
                        {
                            print("you haven't collected all the items. There is " + (item.amount - amountItems) + " items left!");
                        }
                    } 
                }
                    
            }
        }
        

    }
}
