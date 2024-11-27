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
      
        #region TaskVerificationMethods
        protected override void Start()
        {
            base.Start();
            totalPipes = pipeHolder.transform.childCount;
            pipes = new GameObject[totalPipes];
            for (int i = 0; i < pipes.Length; i++)
            {
                pipes[i] = pipeHolder.transform.GetChild(i).gameObject;
                RotatingPipes rotPipes = pipes[i].GetComponent<RotatingPipes>();
                if (rotPipes != null)
                {
                    rotPipes.OnPipeChanged += CheckPipes;
                    if(rotPipes.isPlaced)
                    {
                        correctPipes++;
                    }
                }
            }
            Debug.Log($"Tuberias totales: {totalPipes}, Correctas Inicialmente:{correctPipes}");
        }

        private void CheckPipes(RotatingPipes rotPipes)
        {
            Debug.Log($"Revisando estado de la tubería: {rotPipes.gameObject.name}, isPlaced: {rotPipes.isPlaced}");
            if (rotPipes.isPlaced && correctPipes < totalPipes)
            {
                correctPipes++;
            }

            else if(!rotPipes.isPlaced && correctPipes > 0)
            {
                correctPipes--;
            }

            Debug.Log($"Tuberías correctas: {correctPipes}/{totalPipes}");

            if (correctPipes == totalPipes)
            {
                CompleteTask();
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
