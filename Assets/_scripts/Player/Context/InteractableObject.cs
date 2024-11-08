using System;
using UnityEngine;

namespace _scripts.Player.Context
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class InteractableObject : MonoBehaviour, IInteract
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
