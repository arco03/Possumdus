using _scripts.Interfaces;
using UnityEngine;

namespace _scripts.NPCs.States
{
    public class TalkingState : INpcState
    {
        public void StartState()
        {
            Debug.Log("Entró al estado de Talking");
        }

        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}