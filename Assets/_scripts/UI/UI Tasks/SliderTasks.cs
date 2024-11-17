using _scripts.TaskSystem;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "TaskScriptable/UITask", fileName = "SliderTasks", order = 2)]
public class SliderTasks : UITasks
{
    [Header("Task Settings")]
    public List<Slider> sliders; // Lista de sliders en la tarea.
    public List<float> targetValues; // Valores objetivo para los sliders.
    public float tolerance = 0.1f; // Margen de error permitido.
    

    public void CheckSliders()
    {
        if (!isActive || isCompleted) return;

        for (int i = 0; i < sliders.Count; i++)
        {
            // Verifica si los sliders están dentro del rango permitido.
            if (Mathf.Abs(sliders[i].value - targetValues[i]) > tolerance)
            {
                Debug.Log("Sliders are not in the correct positions.");
                return;
            }
        }

        CompleteTask();
    }
       
    public void CompleteTask()
    {        
      base.CompleteUITask();
    }

   
}

    

