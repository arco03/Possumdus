using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _scripts.Task_System
{     [CreateAssetMenu(fileName = "TaskList", menuName = "Task System/TaskList")]
    public class TaskModel : ScriptableObject //Objeto para crear las tareas
    {
        public List<TaskStruct> tasksList;
        
    }
    public enum TaskType
    {
        Delivery,     //  entregar objetos a un punto
        Interaction   //  interactuar con un objeto
    }
 
        
    [System.Serializable] public struct TaskStruct  //Parametros del scriptable object 
    {        
        public string taskName;
        public string description;
        public TaskType taskType;
        public bool isCompleted;
        public Transform targetPoint;   //  punto de entrega o interacción
        
    }
}