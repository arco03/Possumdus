using UnityEngine;
using UnityEngine.UI;

namespace _scripts.Task_System
{
    /*
    public class TaskSystemView : MonoBehaviour
    {
       // [SerializeField] private TaskList taskListData; // ScriptableObject con las tareas
       // private TaskSystemController _taskSystem; //Referencia al controlador

        [SerializeField] private Transform taskListUI; // Contenedor UI
        [SerializeField] private GameObject taskPrefab; // Prefab UI para tareas

        void Start()
        {
           // _taskSystem = new TaskSystemController(taskListData);

            foreach (var task in _taskSystem.GetTasks())
            {
                var taskUI = Instantiate(taskPrefab, taskListUI);
                var taskText = taskUI.GetComponentInChildren<Text>();
                taskText.text = task.TaskName;

                task.OnTaskCompleted += () =>
                {
                    taskText.color = Color.green;
                };
            }

            _taskSystem.OnAllTasksCompleted += () => Debug.Log("All tasks completed!");
        }

        public void CompleteTask(string taskName)
        {
            _taskSystem.CompleteTask(taskName);
        }

    }
    */
}
