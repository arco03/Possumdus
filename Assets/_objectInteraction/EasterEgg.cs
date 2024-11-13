using _scripts.Interfaces;
using UnityEngine;

namespace _objectInteraction
{
    public class EasterEgg : MonoBehaviour
    {
        public GameObject easterUI; // Referencia al UI de Easter Egg
        public bool toggle; // Estado de visibilidad del UI
        public Renderer objectMesh; // El mesh del objeto

        // Método para abrir o cerrar el Easter Egg
        public void OpenCloseEaster()
        {
            toggle = !toggle; // Cambia el estado de la UI

            if (!toggle)
            {
                easterUI.SetActive(false); // Desactiva el UI
                objectMesh.enabled = true; // Muestra el mesh
                Debug.Log("Easter Egg closed");
            }
            else
            {
                easterUI.SetActive(true); // Activa el UI
                objectMesh.enabled = false; // Desactiva el mesh
                Debug.Log("Easter Egg opened");
            }
        }
    }
}











    