using System;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public int requiredAmount;
    public int currentAmount;
    public string objectTag;
    public int idTask;
    public bool isReached = false;

    public event Action onReachedTask;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            currentAmount++;
            Destroy(other.gameObject);
        }
    }

    public virtual void TaskVerification()
    { 
        
            isReached = true;
            onReachedTask?.Invoke();
            Debug.Log("Quest Completed!");
        
    }

    private void Update()
    {

        if (!isReached && currentAmount == requiredAmount)
        {
            TaskVerification();
        }
    }


}
