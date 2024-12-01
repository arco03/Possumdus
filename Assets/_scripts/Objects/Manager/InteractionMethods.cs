using System.Collections.Generic;
using System.Linq;
using _scripts.Objects.Interactable;
using _scripts.TaskSystem.NewTaskSystem;
using UnityEngine;

namespace _scripts.Objects.Manager
{
    
    public class InteractionMethods : MonoBehaviour
    {
        public InteractionTask intTask;
        public List<InteractionButton> buttons = new();
        private List<string> currentCombination = new();
        private readonly List<string> defaultCombination = new() { "A", "B", "C", "D" };

        private void Start()
        {
            AssignDefaultValuesToButtons();
        }

        public void SelectButton(InteractionButton button)
        {
            if (!currentCombination.Contains(button.value))
            {
                currentCombination.Add(button.value);
            }

            if (currentCombination.Count > intTask.correctCombination.Count)
            {
                ResetCombination();
            }

            if (currentCombination.Count == intTask.correctCombination.Count)
            {
                if (ValidateCombination())
                {
                    Debug.Log("Combinacion Correcta");
                    intTask.InvokeReachedEvent();
                    DisableButtonInteractions();
                }
                else
                {
                    Debug.Log("Combinacion incorrecta, intenta de nuevo");
                    ResetCombination();
                }
            }
        }

        private bool ValidateCombination()
        {
            // Validar contra la combinación correcta y asegurar que no sea igual al orden predeterminado
            if (currentCombination.SequenceEqual(intTask.correctCombination) &&
                !currentCombination.SequenceEqual(defaultCombination))
            {
                return true;
            }

            return false;

        }

        private void ResetCombination()
        {
           currentCombination.Clear();
        }

        private void DisableButtonInteractions()
        {
            foreach (InteractionButton button in buttons)
            {
                button.DisableButton();
            }
        }

        private void AssignDefaultValuesToButtons()
        {
            if (buttons.Count == 4)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].value = defaultCombination[i];
                }
            }
            else
            {
                Debug.LogError("Se requieren 4 botones para la tarea.");
            }
        }
    }
}