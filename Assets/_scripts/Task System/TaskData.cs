using System.Collections.Generic;
using UnityEngine;

namespace _scripts.Task_System
{    
    public enum TaskType
    {
        Collection,   //  recolectar objetos
        Delivery,     //  entregar objetos a un punto
        Interaction   //  interactuar con un objeto
    }
        
    public class TaskData  //Parametros del scriptable object que construyen la TaskDataModel
    {        
        public string taskName;
        public string description;
        public TaskType taskType;
                
        public int objectCount;         //  cantidad de objetos a recolectar o entregar
        public Transform targetPoint;   //  punto de entrega o interacción

    }
}