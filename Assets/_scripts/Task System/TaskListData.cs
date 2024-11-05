using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskListData", menuName = "Task System/Task List Data")]
public class TaskListData : ScriptableObject
{
    public List<TaskData> tasks;
}

[System.Serializable]
public class TaskData
{
    public string taskName;
    public string description;
}
