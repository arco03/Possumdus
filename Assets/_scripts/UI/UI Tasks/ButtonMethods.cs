using System.Collections.Generic;
using _scripts.Managers;
using _scripts.Player;
using _scripts.TaskSystem;
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
            for (int i = 0; i < buttons.Count; i++)
            {
                int index = i; // Evitar problemas de closures.
                buttons[i].OnStateChanged += (button) =>
                {
                    CheckButtons();
                };
            }
        }

        private void CheckButtons()
        {
            if (!uiTasks.isActive || uiTasks.isCompleted) return;

            // Comparar el orden actual con el establecido.
            if (currentValues.Count != targetValues.Count)
            {
                Debug.Log("Not all buttons are set yet.");
                return;
            }

            for (int i = 0; i < targetValues.Count; i++)
            {
                if (buttons[i].state != targetValues[i])
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
