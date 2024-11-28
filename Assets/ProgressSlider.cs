using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{   
    [SerializeField] private float currentValue = 0f;
    [SerializeField] private float maxValue = 1f;
    [SerializeField] private Slider progressSlider;

    private void Awake()
    {

        progressSlider = GetComponent<Slider>();
        if (progressSlider == null)
        {
            Debug.Log("ProgressSlider: No se encontró un componente Slider en este GameObject.");
        }
    }

    public void InitializeSlider(float duration)
    {
        maxValue = duration > 0? duration : 1f;
        currentValue = 0;
        UpdateSliderUI();
    }

    public bool IncrementProgress(float delta)
    {
        currentValue += delta;
        UpdateSliderUI();

        if (currentValue >= maxValue)
        {
            currentValue = maxValue;
            return true; // Indica que el progreso está completo
        }
        return false; // Progreso en curso
    }

    public void ResetProgress()
    {
        currentValue = 0;
        UpdateSliderUI();
    }

    public void UpdateSliderUI()
    {
        if(progressSlider != null)
        {
            progressSlider.value = currentValue/maxValue;
        }
    }

    public bool IsComplete()
    {
        return currentValue >= maxValue;
    }
}
