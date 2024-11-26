using System.Collections.Generic;
using _scripts.Player;
using _scripts.TaskSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _scripts.UI.UI_Tasks
{
    public class LeverMethods : MonoBehaviour
    {
        [Header("General UI Task Settings")]
        public UITasks uiTasks;
        public Character character;
        public GameObject interactablePanel;
        public GameObject interactableText;
        public GameObject reticle;
        public bool isPlayerInRanges;
        public bool toggle;

        [Header("LeverTask Settings")]
        public List<Slider> levers; 
        private int _currentLeverIndex = 0; 
        private bool _isTaskFailed = false; 
       

        #region PlayerDetectionMethods
        private void Start()
        {
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

            if (_isTaskFailed)
            {
                ResetLevers(); 
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

        public void OpenCloseButtonTask()
        {
            toggle = !toggle;
            if (toggle)
            {
                interactablePanel.SetActive(true);
                uiTasks.isActive = true;
                //character.EnableInteractionMode();
                Debug.Log($"{uiTasks.names} Task opened");
            }
            else
            {
                interactablePanel.SetActive(false);
                uiTasks.isActive = false;
                //character.DisableInteractionMode();
                Debug.Log($"{uiTasks.names} Task closed");
            }
        }

        #endregion

        #region VerificationTask

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
            if(levers.Count >= _currentLeverIndex) return;
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
