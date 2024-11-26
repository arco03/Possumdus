using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _scripts.UI.UI_Tasks
{
    public class PressButtonMethods : UIPlayerVerification
    {
        [Header("Press Button Task Settings")]
        public Image fillImage;
        public float fillSpeed;
        public float drainSpeed;
        [SerializeField] private bool isHolding = false;

        #region TaskVerificationMethods
        protected override void Start()
        {
            base.Start();
            fillImage = base.interactablePanel.transform.Find("FillImage").GetComponent<Image>();
       
            if (fillImage == null)
            {
                Debug.LogError("No se encontr� una imagen de relleno dentro del panel.");
                return;
            }
        }
        protected override void Update()
        {
            base.Update();
            FillImages();
        }

        public void FillImages()
        {
            if (fillImage == null|| uiTasks.isCompleted) return;

            if (isHolding)
            {
                fillImage.fillAmount += fillSpeed * Time.deltaTime;
                if (fillImage.fillAmount >= 1f)
                {
                    CompleteTask();
                }
            }
            else
            {
                fillImage.fillAmount -= drainSpeed * Time.deltaTime;
                fillImage.fillAmount = Mathf.Clamp(fillImage.fillAmount, 0f, 1f);
            }
        }

        public void OnHoldButtonPress()
        {
            isHolding = true;
            Debug.Log("Boton Presionado");
        }

        public void OnHoldButtonRelease()
        {
            isHolding = false;
            Debug.Log("Boton Suelto");
        }
        private void CompleteTask()
        {
            Debug.Log("�Button Press Task Completed!");
            uiTasks.CompleteUITask();
        }
        #endregion
    }
}
