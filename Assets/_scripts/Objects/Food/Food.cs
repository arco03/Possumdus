using _scripts.Player;
using UnityEngine;

namespace _scripts.Objects.Food
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private HungerManager _hungerManager;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _hungerManager.Eat();
                Destroy(this.gameObject);
            }
        }
    }
}

