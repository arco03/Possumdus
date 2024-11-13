using System.Collections;
using System.Collections.Generic;
using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseMethods : MonoBehaviour
{
    public DeliveryTasks delTask;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(delTask.objectTag))
        {
            delTask.ProgressUpdate();
            Destroy(other.gameObject);
        }
    }
}
