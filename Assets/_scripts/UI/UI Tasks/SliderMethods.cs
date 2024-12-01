using System.Collections.Generic;
using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _scripts.UI.UI_Tasks
{
    public class SliderMethods : UIPlayerVerification
    {
        [Header("Slider Task Settings")]
        public List<Slider> sliders;
        public List<Image> sliderBorders;
        public List<float> targetValues;
        public float tolerance;
        public Color correctColor = Color.green;
        public Color incorrectColor = Color.red;

        #region TaskVerificationMethods

        private void OnEnable()
        {
            foreach (var slider in sliders)
            {
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

        #endregion
    }
}
             
          
       



