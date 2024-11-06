using _scripts.NPCs.Interfaces;

namespace _scripts.NPCs
{
    public class NpcStateMachine
    {
        private INpcState currentState;

        public NpcStateMachine(INpcState initialState)
        {
            currentState = initialState;
        }
        
        public void StartStateMachine()
        {
            currentState.StartState();
        }
        
        public void UpdateStateMachine()
        {
            currentState.UpdateState();
        }
        
        public void ChangeState(INpcState nextState)
        {
            currentState.ExitState();
            currentState = nextState;
            currentState.StartState();
        }
    }
}