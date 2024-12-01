using System.Collections.Generic;
using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _scripts.UI.UI_Tasks
{
    public class LeverMethods : UIPlayerVerification
    {
        [Header("Lever Task Settings")]
        public List<Slider> levers; 
        private int _currentLeverIndex = 0; 
        private bool _isTaskFailed = false;

        #region TaskVerificationMethods
        protected override void Update()
        {
            base.Update();
            if (_isTaskFailed)
            {
                ResetLevers();
            }
        }

        public void OnValueChanged(Slider lever)
        {
           if (lever == levers[_currentLeverIndex])
           { 
               if (lever.value >= lever.maxValue)
               {
                   lever.value = lever.maxValue;
                   _currentLeverIndex++;

                   if (_currentLeverIndex >= levers.Count)
                   {
                       CompleteTask();
                       Debug.Log("lever task done");
                   }
               }
           }
           else
           {
               FailTask();
           }
        }

        public void OnPointUp(Slider lever)
        {
            if (levers.Count <= _currentLeverIndex) return;
            if (lever == levers[_currentLeverIndex])
            {
                if (lever.value < lever.maxValue)
                {
                    FailTask();
                }
            }
            
        }

        private void ResetLevers()
        {
            foreach(var lever in levers)
            {
                lever.value = lever.minValue; 
            }

            _isTaskFailed = false;
            _currentLeverIndex = 0;
        }
        private void CompleteTask()
        {
            uiTasks.CompleteUITask();
        }

        private void FailTask()
        {
            Debug.Log("Task Failed!");
            _isTaskFailed = true;
        }

        #endregion
    }
}
