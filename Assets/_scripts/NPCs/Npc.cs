using _scripts.Interfaces;
using _scripts.NPCs.States;
using DialogueEditor;
using UnityEngine;
using UnityEngine.AI;

namespace _scripts.NPCs
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class Npc : MonoBehaviour, IObjectsInteract
    {
        protected internal NpcStateMachine NpcStateMachine;
        [SerializeField] protected Transform[] waypoints;
        protected NavMeshAgent Agent;
        [SerializeField] protected NPCConversation npcConversation;
        
        private bool isTalking = false;
        private bool isPlayerInRange = false;
        private WalkingState walkingState;
        private TalkingState talkingState;
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            walkingState = new WalkingState(Agent, waypoints);
            talkingState = new TalkingState(npcConversation);
            NpcStateMachine = new NpcStateMachine(walkingState);
        }

        public virtual void Start()
        {
            NpcStateMachine.StartStateMachine();
        }

        public virtual void Update()
        {
            NpcStateMachine.UpdateStateMachine();
        }

        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = true;
                Agent.isStopped = true;
            }
        }

        public virtual void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
                Agent.isStopped = false;
            }
        }

        public virtual void OnInteract()
        {
            if (!isPlayerInRange) return;
            
            if (!isTalking)
            {
                isTalking = true;
                NpcStateMachine.ChangeState(talkingState);
            }
            else
            {
                isTalking = false;
                NpcStateMachine.ChangeState(walkingState);
            }
        }

        public virtual void OnRelease()
        {
            
        }
    }
}
