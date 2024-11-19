using System;
using _scripts.Interfaces;
using _scripts.NPCs.States;
using _scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _scripts.NPCs.NPC_Types
{
    public class NpcChef : Npc
    {
        private INpcState walkingState;
        private INpcState talkingState;
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            walkingState = new WalkingState(Agent, waypoints);
            talkingState = new TalkingState(npcConversation, this);
            NpcStateMachine = new NpcStateMachine(walkingState);
        }
        
        public override void Interact()
        {
            Debug.Log("El NPC Chef está interactuando con el jugador");
            NpcStateMachine.ChangeState(talkingState);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Agent.isStopped = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Agent.isStopped = false;
            }
        }
    }
}