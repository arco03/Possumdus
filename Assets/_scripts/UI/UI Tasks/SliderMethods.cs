using System.Collections.Generic;
using _scripts.Managers;
using _scripts.Player;
using _scripts.TaskSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _scripts.UI.UI_Tasks
{
    public class SliderMethods : MonoBehaviour
    {
        [Header("General UI Task Settings")]
        public UITasks uiTasks;
        public Character character;
        public GameObject interactablePanel;
        public GameObject interactableText;
        public GameObject reticle;
        public bool isPlayerInRanges;
        public bool toggle;

        [Header("Slider Task Settings")]
        public List<Slider> sliders; 
        public List<Image> sliderBorders;
        public List<float> targetValues; 
        public float tolerance = 0.1f; 
        public Color correctColor = Color.green;
        public Color incorrectColor = Color.red;

        private void OnEnable()
        {
            foreach (var slider in sliders) {
                slider.onValueChanged.AddListener(delegate { UpdateSliderColors(); });
                slider.onValueChanged.AddListener(delegate { CheckSliders(); });
            }
        }

        private void OnDisable()
        {
            foreach (var slider in sliders)
            {
                slider.onValueChanged.RemoveListener(delegate { UpdateSliderColors(); });
                slider.onValueChanged.RemoveListener(delegate { CheckSliders(); });
            }
        }

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
                OpenCloseSliderTask();
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

        private void OpenCloseSliderTask()
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


        private void CheckSliders()
        {
            if (!uiTasks.isActive || uiTasks.isCompleted)
            {
                Debug.Log("Task is either inactive or already completed.");
                return;
            }

            for (int i = 0; i < sliders.Count; i++)
            {
                float difference = Mathf.Abs(sliders[i].value - targetValues[i]);
                Debug.Log($"Checking Slider {i}: Value = {sliders[i].value}, Target = {targetValues[i]}, Difference = {difference}");

                if (difference > tolerance)
                {
                    Debug.Log("Sliders are not in the correct positions.");
                    return;
                }
            }
                
            CompleteTask();
            Debug.Log($"Task {uiTasks.names} completed!");
        }

        private void UpdateSliderColors()
        {
            for (int i = 0; i < sliders.Count; i++)
            {
                float difference = Mathf.Abs(sliders[i].value - targetValues[i]);
                sliderBorders[i].color = difference <= tolerance ? correctColor : incorrectColor;
            }
        }

        private void CompleteTask()
        {
            uiTasks.CompleteUITask();
        }

    }
}



