using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Serialization;

namespace _scripts.TaskSystem
{
  /*  public class TaskTracker : MonoBehaviour
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
                if (val.Destinaiton.GetComponent<DestinationScript>().isReached)
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

        public void VerifyItem(int item_ID)
        {
            Task t = null;
            if(ActiveTasks.Count > 0)
            {
                if(ActiveTasks.Exists(x => x.CollectItems.Exists(a => a.id == item_ID)))
                {
                    t = ActiveTasks.Find(x => x.CollectItems.Exists(a => a.id == item_ID));
                }
                else
                {
                    t = null;
                    return;
                }

                for(int i = 0; i < ActiveTasks.Count; i++)
                {
                    if (t.CollectItems[0].id == item_ID && ActiveTasks[i].ID == t.ID)
                    {
                       // int amount = ItemDiscrimination(td.Tasks[ActiveTasks[i].ID].Items[0].id);
                      //  RefreshQuest(ActiveTasks[i].ID, ActiveTasks[i].TasksType, amount);
                        t = null;
                        break;
                    }
                }
            }
        }

       /* public int ItemDiscrimination(int _id)
        {
            int itemsMatch = 0;

            foreach(var item in GetComponent<DestinationTasks>().getItem)
            {
                 if(item.GetComponent<Object>().ID == _id)
                {
                    itemsMatch++;
                }
            }
            return itemsMatch;
        }
        

    }*/
}
