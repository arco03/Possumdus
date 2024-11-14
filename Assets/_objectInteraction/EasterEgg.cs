using System;
using _scripts.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace _objectInteraction
{
    public class EasterEgg : MonoBehaviour
    {
        public GameObject easterUI;
        public bool toggle;
        public bool isPlayerInRange;
        public Renderer objectMesh;
        public GameObject interactableText;
        public GameObject reticle;
  

        public void OpenCloseEaster()
        {
            toggle = !toggle; 
            if (toggle)
            {
                easterUI.SetActive(true);
                objectMesh.enabled = false;
                Debug.Log("Easter Egg opened");
            }
            else
            {
                easterUI.SetActive(false);
                objectMesh.enabled = true;
                Debug.Log("Easter Egg closed");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = true;
                interactableText.SetActive(true);
                reticle.SetActive(false);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
                interactableText.SetActive(false);
                reticle.SetActive(true);
            }
        }

        private void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
                OpenCloseEaster(); 
            }
        }
    }
}











    