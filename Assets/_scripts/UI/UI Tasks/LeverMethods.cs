using _scripts.Player;
using _scripts.TaskSystem;
using UnityEngine;

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

    #region VerificationTask
    [Header("Task Settings")]
    public Vector2 finalPosition; // La posición objetivo de la palanca en coordenadas locales.
    public float tolerance = 5f; // Margen de error para considerar que la palanca está "abajo".

    public void CheckTask()
    {
        if (!uiTasks.isActive || uiTasks.isCompleted) return;

        // Aquí puedes verificar si la palanca está en la posición correcta desde otro script.
        Debug.Log($"Task {uiTasks.names} checked but needs external validation.");
    }

    public void CompleteLeverTask()
    {
        if (uiTasks.isCompleted) return;

        uiTasks.isCompleted = true;
        Debug.Log($"Task {uiTasks.names} completed!");
       
    }

    #endregion
}
