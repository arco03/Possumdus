using System.Collections.Generic;
using UnityEngine;

namespace _scripts.Task_System
{
    public class TaskSystemTracker : MonoBehaviour
    {
        public TaskSystemController Tsc;
        public List<TaskSystemController> ActiveTasks = new List<TaskSystemController>();
        
    }
}
