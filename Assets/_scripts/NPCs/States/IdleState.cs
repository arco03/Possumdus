using UnityEngine;

namespace _scripts.NPCs.States
{
    public class IdleState : INpcState
    {
        private const float TimerDuration = 3f;
        private float _timer;
        
        public void EnterState(Npc npc)
        {
            Debug.Log("Entró al estado de Idle");
            _timer = TimerDuration;
            //animation
        }

        public void UpdateState(Npc npc)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0) npc.ChangeState(new WalkingState());
        }

        public void ExitState()
        {
            Debug.Log("Salió del estado Idle");
        }
    }
}