using System;
using _scripts.NPCs.Interfaces;
using _scripts.NPCs.States;
using UnityEngine;
using UnityEngine.AI;

namespace _scripts.NPCs
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class Npc : MonoBehaviour, IInteract
    {
        protected NpcStateMachine NpcStateMachine;
        [SerializeField] protected Transform[] Waypoints;
        protected NavMeshAgent Agent;

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
