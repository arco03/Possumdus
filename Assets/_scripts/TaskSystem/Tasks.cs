using System;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public int requiredAmount;
    public int currentAmount = 0;
    public string objectTag;
    public int idTask;
    public bool isReached = false;

    public event Action onReachedTask;
    public event Action<int, int, int,bool> onProgressUpdate;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            currentAmount++;
            TaskVerification();
            onProgressUpdate?.Invoke(idTask, requiredAmount, currentAmount, isReached);
            Destroy(other.gameObject);
        }
    }

    public virtual void TaskVerification()
    {
        Debug.Log($"Verifying task: {idTask} - Progress: {currentAmount}/{requiredAmount}");

        if (!isReached && currentAmount >= requiredAmount)
        {
            onReachedTask?.Invoke();
            isReached = true;
            Debug.Log($"Quest {idTask} - Completed!");

        }

    }



}
