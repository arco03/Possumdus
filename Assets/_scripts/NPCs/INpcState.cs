namespace _scripts.NPCs
{
    public interface INpcState
    {
        void EnterState(Npc npc);
        void UpdateState(Npc npc);
        void ExitState();
    }
}