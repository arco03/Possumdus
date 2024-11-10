using UnityEngine;

namespace _scripts.Player.Interact
{
    public class Object 
    {
        public int ID;
        public void Interact(IPlayerContext context)
        {
            Debug.Log("Interactuaste conmigo");
            //Destroy(gameObject);
        }
    }
}
