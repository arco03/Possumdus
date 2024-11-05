using System;

namespace _scripts.Task_System
{
    public class TaskDataModel //Estas son las definiciones de la tarea
    {
        public string TaskName { get; private set; }
        public string Description { get; private set; }
        public int ID { get; private set; }
        public bool IsCompleted { get; private set; }
        
        public event Action OnTaskCompleted; //Evento propio de las tareas que indica su estado de completado
        
        public TaskDataModel(string taskName, string description, int id) //Un constructor para la clase Task
        {
            TaskName = taskName;
            Description = description;
            ID = id;
            IsCompleted = false;
        }
        
        public void CompleteTask() //Metodo con la logica para el estado de completado
        {
            if (IsCompleted) return;
            IsCompleted = true;
            OnTaskCompleted?.Invoke();
        }
    }
}
