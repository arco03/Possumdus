using UnityEngine;
using TMPro; // Importa el namespace de TextMesh Pro

public class CountdownTimer : MonoBehaviour
{
    public int startTimeInSeconds = 60; // Tiempo inicial en segundos
    private float timeRemaining;
    private bool isCountingDown = false;

    public TMP_Text timerText; // Cambia a TMP_Text para TextMesh Pro

    void Start()
    {
        timeRemaining = startTimeInSeconds;
        isCountingDown = true;
        UpdateTimerText();
    }

    void Update()
    {
        if (isCountingDown)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                isCountingDown = false;
                UpdateTimerText();
                OnTimerEnd();
            }
        }
    }

    void UpdateTimerText()
    {
        // Convierte los segundos en minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Muestra el tiempo en formato mm:ss
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        // Aquí puedes agregar cualquier acción cuando el temporizador llegue a 0
        Debug.Log("¡El tiempo se ha acabado!");
    }
}
