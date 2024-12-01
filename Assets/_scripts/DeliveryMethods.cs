using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;

namespace _scripts
{
    public class DeliveryMethods : MonoBehaviour
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
}
