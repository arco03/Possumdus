using _scripts.Interfaces;
using DialogueEditor;
using UnityEngine;
using UnityEngine.AI;

namespace _scripts.NPCs
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class Npc : MonoBehaviour, INpcInteract
    {
        protected internal NpcStateMachine NpcStateMachine;
        [SerializeField] protected Transform[] waypoints;
        protected NavMeshAgent Agent;
        [SerializeField] protected NPCConversation npcConversation;

        public virtual void Start()
        {
            NpcStateMachine.StartStateMachine();
        }

        public virtual void Update()
        {
            NpcStateMachine.UpdateStateMachine();
        }
        
        public abstract void Interact();
        
    }
}
