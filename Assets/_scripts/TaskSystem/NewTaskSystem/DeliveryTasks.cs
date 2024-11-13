using System;
using UnityEngine;

namespace _scripts.TaskSystem.NewTaskSystem
{
    [CreateAssetMenu(menuName = "TaskScriptable/DeliveryTask", fileName = "DeliveryTasks", order = 0)]
    public class DeliveryTasks : Tasks
    {
        [Header("Delivery Atributes")]
        public int requiredAmount;
        public int currentAmount = 0;
        public string objectTag;
        public event Action<DeliveryTasks> OnProgressUpdate;

        public void ProgressUpdate()
        {
            currentAmount++;
            OnProgressUpdate?.Invoke(this);
            Debug.Log($"Verifying task: {idTask} - Progress: {currentAmount}/{requiredAmount}");
            if (!isReached && currentAmount >= requiredAmount)
            {
                isReached = true;
                InvokeReachedEvent();
            }
        }
     
    }
}
