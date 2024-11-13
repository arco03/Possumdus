using _scripts.TaskSystem;
using UnityEngine;
using UnityEngine.UI;

public class SliderTasks : MonoBehaviour
{
   public UITasks uiTasks;

    public Slider[] sliders; // Asigna los sliders correspondientes desde el inspector
    public float[] targetValues; // Valores específicos que cada slider debe alcanzar
    private bool isActivated = false;

    public void InitializeTask()
    {
        if (sliders.Length != targetValues.Length)
        {
            Debug.LogError("La cantidad de sliders no coincide con los valores objetivo.");
            return;
        }
        // Configura el evento que escuchará la colisión con el trigger en escena.
    }

    private void ActivateTask()
    {
        isActivated = true;
        foreach (Slider slider in sliders)
        {
            slider.onValueChanged.AddListener(CheckSliderValues); // Verifica valores al mover sliders
        }
    }

    private void CheckSliderValues(float value)
    {
        if (!isActivated) return;

        for (int i = 0; i < sliders.Length; i++)
        {
            if (Mathf.Abs(sliders[i].value - targetValues[i]) > 0.1f) // Tolerancia ajustable
            {
                return; // Sale si algún slider no está en el valor objetivo
            }
        }

        CompleteTask(); // Completa la tarea si todos los sliders están en sus valores objetivo
    }

    public void CompleteTask()
    {
        uiTasks.InvokeReachedEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Cambia el tag si es necesario
        {
            ActivateTask(); // Activa la tarea cuando el jugador colisiona con el objeto en escena
        }
    }
}

