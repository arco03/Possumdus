using UnityEngine;
using UnityEngine.AI;

namespace _scripts.NPCs.States
{
    public class WalkingState : INpcState
    {
        private int _currentWaypoint = 0;
        private NavMeshAgent _agent;
        
        public void EnterState(Npc npc)
        {
            Debug.Log("Entró al estado de Walking"); 
            _agent = npc.GetComponent<NavMeshAgent>();
            //MoveToNextWaypoint(npc)
            //Animation
        }

        public void UpdateState(Npc npc)
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            {
                MoveToNextWaypoint(npc);
                npc.ChangeState(npc._idleState);
                Debug.Log(_currentWaypoint);
            }
        }

        public void ExitState()
        {
            Debug.Log("Salió del estado Walking");
        }
        
        private void MoveToNextWaypoint(Npc npc)
        {
            if (npc.waypoints.Length == 0) return;
            _agent.SetDestination(npc.waypoints[_currentWaypoint].position);
            
            _currentWaypoint = (_currentWaypoint + 1) % npc.waypoints.Length;
        }
    }
}