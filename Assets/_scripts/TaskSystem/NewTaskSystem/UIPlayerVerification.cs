using _scripts.Managers;
using _scripts.Player;
using UnityEngine;

namespace _scripts.TaskSystem.NewTaskSystem
{
    public class UIPlayerVerification : MonoBehaviour
    {
        [Header("General UI Task Settings")]
        public UITasks uiTasks;
        public Character character;
        public GameObject interactablePanel;
        public GameObject interactableText;
        public GameObject reticle;
        public bool isPlayerInRanges;
        public bool toggle;

        #region PlayerDetectionMethods
        protected virtual void Start()
        {
            character = FindObjectOfType<Character>();
            if (character == null)
                Debug.LogError("Character script not found in the scene.");
        }

        protected virtual void Update()
        {
            if (isPlayerInRanges && Input.GetKeyDown(KeyCode.E))
            {
                OpenCloseTask();
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

        public void OpenCloseTask()
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

        #endregion
    }
}
