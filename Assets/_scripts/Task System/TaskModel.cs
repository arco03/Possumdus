using System.Collections.Generic;
using UnityEngine;

namespace _scripts.Task_System
{     [CreateAssetMenu(fileName = "TaskList", menuName = "Task System/TaskList")]
    public class TaskModel : ScriptableObject //Objeto para crear las tareas
    {
        public List<TaskStruct> TasksList;
        
    }
    public enum TaskType
    {
        Delivery,     //  entregar objetos a un punto
        Interaction   //  interactuar con un objeto
    }
 
        
    [System.Serializable] public struct TaskStruct  //Parametros del scriptable object 
    {        
        public string TaskName;
        public string Description;
        public TaskType TaskType;
        public bool IsCompleted;
        public Transform TargetPoint;   //  punto de entrega o interacción
        
    }
}