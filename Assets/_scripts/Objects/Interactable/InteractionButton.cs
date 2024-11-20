using System;
using System.Collections;
using _scripts.Interfaces;
using _scripts.Objects.Manager;
using UnityEngine;

namespace _scripts.Objects.Interactable
{
    public class InteractionButton : MonoBehaviour, IObjectsInteract
    {
        public string value;
        private InteractionMethods _manager;
        public bool isInteractable = true;

        private void Start()
        {
            _manager = FindObjectOfType<InteractionMethods>();
            _manager.intTask.buttons.Add(this);
        }

        public void OnInteract()
        {
            if (isInteractable)
            {
                _manager.SelectButton(this);
                Debug.Log($"Seleccionó el boton {value}");
            }
        }

        public void OnRelease()
        {
        }

        public void DisableButton()
        {
            isInteractable = false;
        }
    }
}