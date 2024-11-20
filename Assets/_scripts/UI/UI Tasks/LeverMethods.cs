using _scripts.Player;
using _scripts.TaskSystem;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeverMethods : MonoBehaviour
{
    [Header("General UI Task Settings")]
    public UITasks uiTasks;
    public Character character;
    public GameObject InteractablePanel;
    public GameObject interactableText;
    public GameObject reticle;
    public bool isPlayerInRanges;
    public bool toggle;

    [Header("LeverTask Settings")]
    public List<Slider> levers; // Lista de sliders que actúan como palancas.
    public float resetSpeed = 2f; // Velocidad de reinicio si el orden no es correcto.
    public float resistanceFactor = 2f; // Factor de resistencia para simular pesadez.

    private int currentLeverIndex = 0; // Índice del slider que debe moverse.
    private bool isTaskFailed = false; // Flag para saber si el jugador falló el orden.
    private bool isDragging = false;

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

        if (isTaskFailed)
        {
            ResetLevers(); // Resetea los sliders si falló la tarea.
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
            InteractablePanel.SetActive(true);
            uiTasks.isActive = true;
            character.EnableInteractionMode();
            Debug.Log($"{uiTasks.names} Task opened");
        }
        else
        {
            InteractablePanel.SetActive(false);
            uiTasks.isActive = false;
            character.DisableInteractionMode();
            Debug.Log($"{uiTasks.names} Task closed");
        }
    }

    #endregion

    #region VerificationTask
    public void OnPointerDown(Slider lever)
    {
        if(lever == levers[currentLeverIndex])
        {
            isDragging = true;
        }
    }

    public void OnPointerUp(Slider lever)
    {
        if (lever == levers[currentLeverIndex])
        {
            isDragging = false;

            if (lever.value <= 0.1f)
            {
                lever.value = 0;
                currentLeverIndex++;

                if (currentLeverIndex >= levers.Count)
                {
                    CompleteTask();
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
        if(lever == levers[currentLeverIndex] && isDragging)
        {
            float mouseInput = Input.GetAxis("Mouse Y");
            float resistance = Mathf.Lerp(1f, resistanceFactor, 1f - lever.value);
            lever.value -= mouseInput / resistance * Time.deltaTime;
        }
        
    }

    public void ResetLevers()
    {
       foreach(Slider lever in levers)
        {
            lever.value += resetSpeed * Time.deltaTime;
            if(lever.value >= lever.maxValue)
            {
                lever.value = lever.maxValue;
            }
        }

        if (levers[0].value == levers[0].maxValue)
        {
            isTaskFailed = false;
            currentLeverIndex = 0;
        }
    }
    private void CompleteTask()
    {
        uiTasks.CompleteUITask();
    }

    public void FailTask()
    {
        Debug.Log("Task Failed!");
        isTaskFailed = true;
    }

    #endregion
}
