using System.Collections.Generic;
using UnityEngine;

namespace _scripts.Task_System
{
    [CreateAssetMenu(fileName = "TaskListData", menuName = "Task System/Task List Data")]
    public class TaskListData : ScriptableObject //Objeto para crear las tareas
    {
        public List<TaskData> tasks;
    }

    [System.Serializable]
     public class TaskData //Parametros del scriptable object que construyen la TaskDataModel
    {
        public string taskName;
        public string description;
        public int id;
        
    }
}