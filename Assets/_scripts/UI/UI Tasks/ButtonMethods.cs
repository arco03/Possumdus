using System.Collections.Generic;
using _scripts.Managers;
using _scripts.Player;
using _scripts.TaskSystem;
using UnityEngine;

namespace _scripts.UI.UI_Tasks
{
    public class ButtonMethods : MonoBehaviour
    {
        [Header("General UI Task Settings")]
        public UITasks uiTasks;
        public Character character;
        public GameObject interactablePanel;
        public GameObject interactableText;
        public GameObject reticle;
        public bool isPlayerInRanges;
        public bool toggle;

        [Header("Button Task Settings")]
        public List<ButtonLeds> buttons;

        public List<int> targetValues;
        public List<int> currentValues = new();
         

        #region PlayerDetectionMethods
        private void Start()
        {
            InitializeButtons();
            character = FindObjectOfType<Character>();
            if (character == null)
                Debug.LogError("Character script not found in the scene.");
        }

        private void Update()
        {
            if (isPlayerInRanges && Input.GetKeyDown(KeyCode.E))
            {
                OpenCloseButtonTask();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !uiTasks.isCompleted)
            {
                isPlayerInRanges = true;
                interactableText.SetActive(true);
                reticle.SetActive(false);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRanges = false;
                interactableText.SetActive(false);
                reticle.SetActive(true);
            }
        }

        private void OpenCloseButtonTask()
        {
            toggle = !toggle;
            if (toggle)
            {
                interactablePanel.SetActive(true);
                uiTasks.isActive = true;
                CursorManager.instance.EnableInteractionMode();
                Debug.Log($"{uiTasks.names} Task opened");
            }
            else
            {
                interactablePanel.SetActive(false);
                uiTasks.isActive = false;
                CursorManager.instance.DisableInteractionMode();
                Debug.Log($"{uiTasks.names} Task closed");
            }
        }

        #endregion

        #region TaskVerificationMethods
       
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
    }
}
   #endregion