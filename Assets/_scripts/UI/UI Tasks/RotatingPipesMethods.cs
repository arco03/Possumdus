using System;
using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace _scripts.UI.UI_Tasks
{
    public class RotatingPipesMethods : UIPlayerVerification
    { 
        [Header("Rotating Pipes Task Settings")]
        public GameObject pipeHolder; 
        public GameObject[] pipes;
        [SerializeField]private int totalPipes = 0;
        [SerializeField]private int correctPipes = 0;
        private RotatingPipes _rotPipes;

        #region TaskVerificationMethods
        protected override void Start()
        {
            base.Start();
            totalPipes = pipeHolder.transform.childCount;
            pipes = new GameObject[totalPipes];
            for (int i = 0; i < pipes.Length; i++)
            {
                pipes[i] = pipeHolder.transform.GetChild(i).gameObject;
                _rotPipes = pipes[i].GetComponent<RotatingPipes>();
                if (_rotPipes != null)
                {
                    _rotPipes.OnPipeChanged += CheckPipes;
                }
            }
        }

        private void CheckPipes(RotatingPipes rotPipes)
        {
            if (rotPipes.isPlaced)
            {
                correctPipes++;
                if (correctPipes == totalPipes)
                {
                    CompleteTask();
                }
            }
            else
            {
                correctPipes--;
            }
        }

        private void CompleteTask()
        {
            uiTasks.CompleteUITask();
            Debug.Log("¡Rotating Pipes Task Completed!");
        }
        #endregion
    }
}
