using UnityEngine;

public class DeliveryTasks : Tasks
{

    public override void TaskVerification()
    {
        base.TaskVerification();
        Debug.Log("Delivery Quest Completed!");
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

}
