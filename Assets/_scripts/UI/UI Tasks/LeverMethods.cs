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
        public List<Slider> levers; // Lista de sliders que act�an como palancas.
        public float resetSpeed; // Velocidad de reinicio si el orden no es correcto.
        public float resistanceFactor; // Factor de resistencia para simular pesadez.
        private int _currentLeverIndex = 0; // �ndice del slider que debe moverse.
        private bool _isTaskFailed = false; // Flag para saber si el jugador fall� el orden.
        private bool _isDragging = false;

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
                character.EnableInteractionMode();
                Debug.Log($"{uiTasks.names} Task opened");
            }
            else
            {
                interactablePanel.SetActive(false);
                uiTasks.isActive = false;
                character.DisableInteractionMode();
                Debug.Log($"{uiTasks.names} Task closed");
            }
        }

        #endregion

        #region VerificationTask
        public void OnPointerDown(Slider lever)
        {
            if(lever == levers[_currentLeverIndex] && !_isTaskFailed)
            {
                _isDragging = true;
            }
            else
            {
                FailTask();
            }
        }

        public void OnPointerUp(Slider lever)
        {
            if (lever == levers[_currentLeverIndex] && !_isTaskFailed)
            {
                _isDragging = false;

                if(lever.value >= 0.9f)
                {
                    lever.value = lever.maxValue;
                    _currentLeverIndex++;
                    if (_currentLeverIndex >= levers.Count)
                    {
                        CompleteTask();
                        Debug.Log("lever task completed");
                    }
                }
                else
                {
                    FailTask();
                }
            }
        }

        public void OnDrag( Slider lever)
        {
            if(lever == levers[_currentLeverIndex] && _isDragging)
            {
                float mouseInput = Input.GetAxis("Mouse Y");
                float resistance = Mathf.Lerp(1f, resistanceFactor, lever.value);
                lever.value += (mouseInput / resistance) * Time.deltaTime;
                lever.value = Mathf.Clamp(lever.value, lever.minValue, lever.maxValue);
            }
        
        }

        private void ResetLevers()
        {
            bool AllReset = true;

            foreach(var lever in levers)
            {
                lever.value = Mathf.MoveTowards(lever.value, lever.minValue, resetSpeed * Time.deltaTime);
                if (lever.value > lever.minValue)
                {
                    AllReset = false;
                }
            }
            if(AllReset)
            {
                _isTaskFailed = false;
                _currentLeverIndex = 0; 
            }
         
        }
        private void CompleteTask()
        {
            uiTasks.CompleteUITask();
        }

        private void FailTask()
        {
            Debug.Log("Task Failed!");
            _isTaskFailed = true;
            _currentLeverIndex = 0;
        }

        #endregion
    }
}
