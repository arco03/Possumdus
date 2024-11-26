using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _scripts.TaskSystem.NewTaskSystem
{
    [CreateAssetMenu(menuName = "TaskScriptable/DeliveryTask", fileName = "DeliveryTasks", order = 0)]
    public class DeliveryTasks : Tasks
    {
        [Header("Delivery Atributes")]
        public int requiredAmount;
        public int currentAmount;
        public string objectTag;
        public event Action<DeliveryTasks> OnProgressUpdate;

#if UNITY_EDITOR
        private void OnEnable()
        {
            currentAmount = 0;
            base.isReached = false;
        }
#endif
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
