using UnityEngine;

namespace _scripts.Objects.Door
{
    public class DoorAnimation : MonoBehaviour
    {
        [SerializeField] private Doors door1;
        [SerializeField] private Doors door2;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Npc"))
            {
                Debug.Log("Entro al animator puerta");
                door1.AnimationDoor();
                door2.AnimationDoor();
            }
        }
        
    }
}