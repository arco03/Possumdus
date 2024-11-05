using _scripts.NPCs.States;
using UnityEngine;

namespace _scripts.NPCs
{
    public abstract class Npc : MonoBehaviour
    {
        public WalkingState _walkingState;
        public IdleState _idleState;
        
        private INpcState _currentState;
        public Transform[] waypoints;

        // Update the state
        private void Update()
        {
            _currentState?.UpdateState(this);
        }
        
        // Method for change the state
        public void ChangeState(INpcState newState)
        {
            _currentState = newState;
            _currentState.EnterState(this);
        }

        // Interact with character
        public abstract void Interact();
    }
}
