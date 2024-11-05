using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Task
{
    public string TaskName { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }

    public event Action OnTaskCompleted;

    public Task(string taskName, string description)
    {
        TaskName = taskName;
        Description = description;
        IsCompleted = false;
    }

    public void CompleteTask()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            OnTaskCompleted?.Invoke();
        }
    }
}
