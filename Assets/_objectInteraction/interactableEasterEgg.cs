using UnityEngine;

namespace _objectInteraction
{
    public class InteractableEasterEgg : MonoBehaviour
    {
        public float interactionDistance = 5f; // Distancia máxima del raycast
        public GameObject interactionPoint; // Punto de interacción (p. ej. un icono o un marcador)
        public LayerMask interactionLayers; // Capas en las que se puede hacer raycast
        public Color rayColor = Color.red; // Color del rayo para depuración

        private void Update()
        {
            RaycastHit hit;

            // Disparamos un rayo hacia adelante desde la posición del objeto
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayers))
            {
                // Mostrar el rayo en la vista de la escena para depuración
                Debug.DrawRay(transform.position, transform.forward * hit.distance, rayColor);
                Debug.Log("Ray hit: " + hit.collider.name); // Mensaje de depuración

                // Si el objeto golpeado tiene el componente EasterEgg, habilitamos el punto de interacción
                if (hit.collider.gameObject.TryGetComponent<EasterEgg>(out var component))
                {
                    interactionPoint.SetActive(true);
                    Debug.Log("Easter Egg detected");

                    // Detectamos el clic del mouse para interactuar con el Easter Egg
                    if (Input.GetMouseButtonDown(0)) // Cambié a GetMouseButtonDown para evitar múltiples activaciones
                    {
                        Debug.Log("Interacting with Easter Egg");
                        component.OpenCloseEaster(); // Ejecutamos la acción de abrir/cerrar el Easter Egg
                    }
                }
                else
                {
                    interactionPoint.SetActive(false); // Si no es un Easter Egg, desactivamos el punto de interacción
                }
            }
            else
            {
                interactionPoint.SetActive(false); // Si el rayo no golpea nada, desactivamos el punto de interacción
            }
        }
    }
}

