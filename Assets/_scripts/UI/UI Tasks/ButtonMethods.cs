using _scripts.Player;
using _scripts.TaskSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonMethods : MonoBehaviour
{
    [Header("General UI Task Settings")]
    public UITasks uiTasks;
    public Character character;
    public GameObject InteractablePanel;
    public GameObject interactableText;
    public GameObject reticle;
    public bool isPlayerInRanges;
    public bool toggle;

    [Header("Button Task Settings")]
    public List<Button> buttons;
    public List<Image> buttonImages;
    public List<Image> ledImages;
    public Sprite ledOnSprite;
    public Sprite ledOffSprite;
    public Sprite buttonOnSprite;
    public Sprite buttonOffSprite;
    public List<int> targetValues;
    public List<int> currentValues;

   /* private void OnEnable()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(delegate { ButtonChange(); });
        }
    }

    private void OnDisable()
    {
        foreach (var button in buttons)
        {
            button.onClick.RemoveListener(delegate { ButtonChange(); });
        }
    }*/



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

    #region TaskVerificationMethods
   

    public void InitializeButtonTask()
    {        
        // Asocia la acción de cada botón con la función que maneja su estado
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;  // Necesario para capturar el índice correctamente
            buttons[i].onClick.AddListener(() => ToggleButtonState(index));
            ButtonChange(i);  // Inicializa el estado del botón y LED
        }
    }
    public void ButtonChange(int buttonIndex)
    {
        if (currentValues[buttonIndex] == 1)
        {
            ledImages[buttonIndex].sprite = ledOnSprite;  // Cambia al sprite de encendido
            buttons[buttonIndex].image.sprite = buttonOnSprite; // Cambia al sprite del botón "on"
        }
        else
        {
            ledImages[buttonIndex].sprite = ledOffSprite;  // Cambia al sprite de apagado
            buttons[buttonIndex].image.sprite = buttonOffSprite; // Cambia al sprite del botón "off"
        }
    }

    private void ToggleButtonState(int buttonIndex)
    {
        // Cambia el estado del botón y el LED
        currentValues[buttonIndex] = 1 - currentValues[buttonIndex];  // Alterna entre 0 y 1
        ButtonChange(buttonIndex);

        // Verifica si la tarea está completa
        CheckSliders();
    }

    public void CheckSliders()
    {        
        for (int i = 0; i < currentValues.Count; i++)
        {            
            if (currentValues[i] != targetValues[i])
            {
                Debug.Log("Sliders are not in the correct positions.");
                return;
            }
        }

        CompleteTask();
        Debug.Log($"Task {uiTasks.names} completed!");
    }

    
    public void CompleteTask()
    {
        uiTasks.CompleteUITask();
    }

    #endregion


}
