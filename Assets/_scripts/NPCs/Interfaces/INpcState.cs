namespace _scripts.NPCs.Interfaces
{
    public interface INpcState
    {
        void StartState();
        void UpdateState();
        void ExitState();
    }
}