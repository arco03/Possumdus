using _scripts.Player.Interact;
using UnityEngine;

namespace _scripts.Objects.Documents
{
    public class Documents : MonoBehaviour, IInteract
    {
        public void Interact(IPlayerContext context)
        {
            Debug.Log("Interactuaste conmigo");
            Destroy(gameObject);
        }
    }
}
