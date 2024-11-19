using _scripts.Interfaces;
using _scripts.NPCs.States;
using UnityEngine;
using UnityEngine.AI;

namespace _scripts.NPCs.NPC_Types
{
    public class NpcHydraulic : Npc
    {
        private INpcState walkingState;
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            walkingState = new WalkingState(Agent, waypoints);
            NpcStateMachine = new NpcStateMachine(walkingState);
        }
        
        public override void Interact()
        {
            //TODO:
            // Lógica de interacción específica con el jugador
            Debug.Log("El NPC Chef está interactuando con el jugador");
            // Cambiar a otro estado si es necesario (ej. ChangeState(new TalkingState());)
        }
    }
}