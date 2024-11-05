using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskSystemController : MonoBehaviour
{
    [SerializeField] private TaskListData taskListData; // ScriptableObject con las tareas
    private TaskSystem taskSystem;

    [SerializeField] private Transform taskListUI; // Contenedor UI
    [SerializeField] private GameObject taskPrefab; // Prefab UI para tareas

    void Start()
    {
        taskSystem = new TaskSystem(taskListData);

        foreach (var task in taskSystem.GetTasks())
        {
            var taskUI = Instantiate(taskPrefab, taskListUI);
            var taskText = taskUI.GetComponentInChildren<Text>();
            taskText.text = task.TaskName;

            task.OnTaskCompleted += () =>
            {
                taskText.color = Color.green;
            };
        }

        taskSystem.OnAllTasksCompleted += () => Debug.Log("All tasks completed!");
    }

    public void CompleteTask(string taskName)
    {
        taskSystem.CompleteTask(taskName);
    }

}
