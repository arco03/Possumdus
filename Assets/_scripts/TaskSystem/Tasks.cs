using System;
using UnityEngine;

public class Tasks : MonoBehaviour
{
   
    public string names;
    public string description;
    public int idTask;
    public bool isReached = false;
    public TaskType taskType;

    public event Action onReachedTask;

    public virtual void TaskVerification()
    {
        
        if (!isReached)
        {
            InvokeReachedEvent();
            isReached = true;
            Debug.Log($"Quest {names} Completed!");

        }

    }

    protected void InvokeReachedEvent()
    {
        onReachedTask?.Invoke();
    }

    [System.Serializable]
    public enum TaskType
    {
        Interaction,
        Delivery,
        General
    }

    



}
