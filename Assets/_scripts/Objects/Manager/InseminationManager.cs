using System.Collections.Generic;
using System.Linq;
using _scripts.Objects.Interactable;
using _scripts.TaskSystem;
using UnityEngine;

namespace _scripts.Objects.Manager
{
    
    public class InseminationManager : MonoBehaviour
    {
        public InteractionTask intTask;

        
        public void SelectButton(InteractionButton button)
        {
            if (!intTask.currentCombination.Contains(button.value))
            {
                intTask.currentCombination.Add(button.value);
            }

            if (intTask.currentCombination.Count > 4)
            {
                ResetCombination();
            }

            if (intTask.currentCombination.Count == 4)
            {
                ValidateCombination();
                intTask.InvokeReachedEvent();
            }
        }

        private bool ValidateCombination()
        {
            intTask.currentCombination.Sort();
            intTask.correctCombination.Sort();

           bool isValid = intTask.currentCombination.Count == intTask.correctCombination.Count &&
                           intTask.currentCombination.SequenceEqual(intTask.correctCombination);

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
            intTask.currentCombination.Clear();
        }

        private void DisableButtonInteractions()
        {
            foreach (var button in intTask.buttons)
            {
                if (intTask.currentCombination.Contains(button.value))
                {
                    button.OnRelease();
                }
            }
        }
    }
}