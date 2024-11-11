using System;
using _scripts.Interfaces;
using UnityEngine;

namespace _scripts.Objects.Interactable
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class InteractableObject : MonoBehaviour, IObjectsInteract
    {
        [HideInInspector] public Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnInteract()
        {
            rb.useGravity = false;
        }

        public void OnRelease()
        {
            rb.useGravity = true;
        }
    
    
    // public void Interact(IPlayerContext context)
    // {
    //     Debug.Log("Interactuaste conmigo");
    //     //Destroy(gameObject);
    // }
    }
}
