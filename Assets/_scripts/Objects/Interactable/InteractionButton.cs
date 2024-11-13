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
        private InseminationManager manager;
        public bool isInteractable = true;

        private void Start()
        {
            manager = FindObjectOfType<InseminationManager>();
        }

        public void OnInteract()
        {
            if (isInteractable)
            { 
                manager.SelectButton(this);
                Debug.Log($"Seleccionó el boton {value}");
            }
        }

        public void OnRelease()
        {
            isInteractable = false;
        }
    }
}