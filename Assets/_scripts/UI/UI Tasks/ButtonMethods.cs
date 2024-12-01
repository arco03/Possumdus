using System.Collections.Generic;
using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;

namespace _scripts.UI.UI_Tasks
{
    public class ButtonMethods : UIPlayerVerification
    {
        [Header("Button Task Settings")]
        public List<ButtonLeds> buttons;
        public List<int> targetValues;
        public List<int> currentValues = new();

        #region TaskVerificationMethods
        protected override void Start()
        {
            base.Start();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            if (buttons.Count != targetValues.Count)
            {
                Debug.Log("El numero de botones no coincide con el numero de valores objetivo");
                    return;
            }
            currentValues.Clear();
            for (int i = 0; i < buttons.Count; i++)
            {
                int index = i;
                buttons[i].targetState = targetValues[index];
                buttons[i].InitializeState();
                currentValues.Add(buttons[i].state);
                buttons[i].OnStateChanged += (button) =>
                {
                    currentValues[index] = button.state;
                    CheckButtons();
                };
            }
        }

        private void CheckButtons()
        {
            if (!uiTasks.isActive || uiTasks.isCompleted) return;
            if (currentValues.Count != targetValues.Count)
            {
                Debug.Log("Not all buttons are set yet.");
                return;
            }

            for (int i = 0; i < targetValues.Count; i++)
            {
                if (currentValues[i] != targetValues[i])
                {
                    Debug.Log($"Button {i} is not in the current state");
                    return;
                }
            }

            CompleteTask();
        }

        private void CompleteTask()
        {
            uiTasks.CompleteUITask();
        }
        #endregion
    }
}
