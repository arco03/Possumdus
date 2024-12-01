using UnityEngine;

namespace _scripts.NPCs.States
{
    public class TalkingState : INpcState
    {
        public void EnterState(Npc npc)
        {
            Debug.Log("Entró al estado de Talking");
        }

        public void UpdateState(Npc npc)
        {
            throw new System.NotImplementedException();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}