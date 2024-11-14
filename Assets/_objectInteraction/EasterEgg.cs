using _scripts.Interfaces;
using UnityEngine;

namespace _objectInteraction
{
    public class EasterEgg : MonoBehaviour
    {
        public GameObject easterUI; 
        public bool toggle; 
        public Renderer objectMesh;
        public GameObject interactablePoint;
        public void OpenCloseEaster()
        {
            toggle = !toggle;
            if (!toggle)
            {
                easterUI.SetActive(false); 
                objectMesh.enabled = true; 
                Debug.Log("Easter Egg closed");
            }
            if(toggle)
            {
                easterUI.SetActive(true); 
                objectMesh.enabled = false; 
                Debug.Log("Easter Egg opened");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                interactablePoint.SetActive(true);
                if(Input.GetMouseButtonDown(0))
                {
                    
                    OpenCloseEaster();
                    
                }
            }
            else
            {
                interactablePoint.SetActive(false);
                
            }
        }
    }
}











    