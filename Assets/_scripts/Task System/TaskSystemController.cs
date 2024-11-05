using System.Collections.Generic;

namespace _scripts.Task_System
{
    public class TaskSystemController
    {
        private readonly List<TaskDataModel> _tasks; //Lista de tareas "originales" construidas
        public event System.Action OnAllTasksCompleted;

        public TaskSystemController(TaskListData taskData)
        {
            _tasks = new List<TaskDataModel>();
            foreach (var taskInfo in taskData.tasks) 
                // Inicializa cada tarea a partir del scriptable
                // taskInfo es una variable de tipo TaskData que son los parametros del scriptable
                //taskData.task son las tareas que se encuentran enlistadas en el scriptable
            {
                var task = new TaskDataModel(taskInfo.taskName, taskInfo.description, taskInfo.id); //Constructor de TaskDataModel
                task.OnTaskCompleted += CheckAllTasksCompleted; //Verifica la completitud de cada tarea en el scriptable
                _tasks.Add(task); //no se q hace esto xd
            }
        }

        private void CheckAllTasksCompleted()
        {
            if (_tasks.TrueForAll(t => t.IsCompleted))
                //Verifica que todas las tareas q se encuentran en la lista del scriptable esten completadas
            {
                OnAllTasksCompleted?.Invoke();
            }
        }

        public void CompleteTask(string taskName)//Basicamente, este metodo lo q hace es hacer seguimiento de las tareas totales de la lista
        //verifica que no esten completadas con el evento que cada una tiene, si si lo esta, la marca como completada y ejecuta la logica asociada
        {
            TaskDataModel task = _tasks.Find(t => t.TaskName == taskName); 
            //Busca en la lista de tareas las q no esten completadas
            if (task != null && !task.IsCompleted)
            {
                task.CompleteTask(); //Este metodo marca la tarea como completada
            }
        }

        public List<TaskDataModel> GetTasks() => _tasks;
    }
}
