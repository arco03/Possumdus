using System;
using UnityEngine;

public class DeliveryTasks : Tasks
{
    
    public override void TaskVerification()
    {
        base.TaskVerification();
        if (isReached)
        {
            Debug.Log($"Delivery Quest {idTask} Completed!");
        }
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

}
