using UnityEngine;

namespace _scripts.Player.Interact
{
    public class PlayerContext : MonoBehaviour, IPlayerContext
    {
        [SerializeField] private Character character;
        
        public float GetEnergy()
        {
            return character.currentEnergy;
        }

        public void SetEnergy(float amount)
        {
            character.currentEnergy = amount;
        }

        public float GetFood()
        {
            return character.hungerDuration;
        }

        public void SetFood()
        {
            character.Eat();
        }
    }
}
