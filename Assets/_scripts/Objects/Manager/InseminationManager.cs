using System.Collections.Generic;
using System.Linq;
using _scripts.Objects.Interactable;
using _scripts.TaskSystem;
using UnityEngine;

namespace _scripts.Objects.Manager
{
    public class InseminationManager : Tasks
    {
        private readonly List<string> currentCombination = new();
        private readonly List<string> correctCombination = new() {"B", "C"};

        [SerializeField] private List<InseminationButton> buttons = new();
        
        public void SelectButton(InseminationButton button)
        {
            if (!currentCombination.Contains(button.value))
            {
                currentCombination.Add(button.value);
            }

            if (currentCombination.Count > 2)
            {
                ResetCombination();
            }

            if (currentCombination.Count == 2)
            {
                ValidateCombination();
                InvokeReachedEvent();
            }
        }

        private bool ValidateCombination()
        {
            currentCombination.Sort();
            correctCombination.Sort();

           bool isValid = currentCombination.Count == correctCombination.Count &&
                           currentCombination.SequenceEqual(correctCombination);

            if (isValid)
            {
                Debug.Log("Combinación correcta");
                DisableButtonInteractions();
                
            }
            else
            {
                Debug.Log("Combinación incorrecta, intenta de nuevo");
                ResetCombination();
            }

            return isValid;

        }

        private void ResetCombination()
        {
            currentCombination.Clear();
        }

        private void DisableButtonInteractions()
        {
            foreach (var button in buttons)
            {
                if (currentCombination.Contains(button.value))
                {
                    button.OnRelease();
                }
            }
        }
    }
}