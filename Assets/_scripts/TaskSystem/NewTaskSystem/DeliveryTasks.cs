using System;
using UnityEngine;

public class DeliveryTasks : Tasks
{    
    public int requiredAmount;
    public int currentAmount = 0;
    public string objectTag;
    public event Action<int, int, int, bool> onProgressUpdate;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            currentAmount++;
            TaskVerification();
            onProgressUpdate?.Invoke(idTask, requiredAmount, currentAmount, isReached);
            Destroy(other.gameObject);
        }
    }

    public override void TaskVerification()
    {
        Debug.Log($"Verifying task: {idTask} - Progress: {currentAmount}/{requiredAmount}");

        if (!isReached && currentAmount >= requiredAmount)
        {
            InvokeReachedEvent();
            isReached = true;
           
        }
    }
}
