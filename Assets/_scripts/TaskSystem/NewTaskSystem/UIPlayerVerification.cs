using _scripts.Managers;
using _scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace _scripts.TaskSystem.NewTaskSystem
{
    public class UIPlayerVerification : MonoBehaviour
    {
        [Header("General UI Task Settings")]
        public UITasks uiTasks;
        public ProgressSlider proSlider;
        public Character character;
        public GameObject interactablePanel;
        public GameObject interactableText;
        public GameObject reticle;
        public float requiredHoldTime;
        public bool isPlayerInRanges;
        public bool toggle;

        #region PlayerDetectionMethods
        protected virtual void Start()
        {
            character = FindObjectOfType<Character>();
            if (character == null)
                Debug.LogError("Character script not found in the scene.");
            proSlider.gameObject.SetActive(false);
        }

        protected virtual void Update()
        {
            if (isPlayerInRanges)
            {
                if (!toggle && Input.GetKey(KeyCode.E))
                {
                    if(!proSlider.gameObject.activeSelf)
                    {
                        proSlider.gameObject.SetActive(true);
                        proSlider.InitializeSlider(requiredHoldTime);
                        bool isComplete = proSlider.IncrementProgress(Time.deltaTime);
                        if (isComplete)
                        {
                            OpenTask();
                            proSlider.ResetProgress();
                            proSlider.gameObject.SetActive(false);// Reinicia el Slider al completarse
                        }
                    }
                }
                else if (toggle && Input.GetKeyDown(KeyCode.E))
                {
                    CloseTask();
                }
                else if (Input.GetKeyUp(KeyCode.E))
                {
                    proSlider.ResetProgress(); // Reinicia el Slider si se suelta la tecla
                }

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
                proSlider.ResetProgress();
                proSlider.gameObject.SetActive(false);
                reticle.SetActive(true);
            }
        }

        public void OpenTask()
        {
            toggle = true;
            interactablePanel.SetActive(true);
            uiTasks.isActive = true;
            CursorManager.instance.EnableInteractionMode();
            Debug.Log($"{uiTasks.names} Task opened");
        }
        public void CloseTask()
        {
            toggle = false;
            interactablePanel.SetActive(false);
            uiTasks.isActive = false;
            CursorManager.instance.DisableInteractionMode();
            Debug.Log($"{uiTasks.names} Task closed");
        }
            

       
        #endregion
    }
}
