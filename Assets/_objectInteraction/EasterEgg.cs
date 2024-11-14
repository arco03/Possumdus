using _scripts.Interfaces;
using UnityEngine;

namespace _objectInteraction
{
    public class EasterEgg : MonoBehaviour
    {
        public GameObject easterUI; 
        public bool toggle; 
        public Renderer objectMesh; 
        public void OpenCloseEaster()
        {
            toggle = !toggle; 

            if (!toggle)
            {
                easterUI.SetActive(false); 
                objectMesh.enabled = true; 
                Debug.Log("Easter Egg closed");
            }
            else
            {
                easterUI.SetActive(true); 
                objectMesh.enabled = false; 
                Debug.Log("Easter Egg opened");
            }
        }
    }
}











    