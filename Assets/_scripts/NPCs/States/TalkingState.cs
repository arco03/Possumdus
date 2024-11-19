using _scripts.Interfaces;
using DialogueEditor;
using UnityEngine;

namespace _scripts.NPCs.States
{
    public class TalkingState : INpcState
    {
        private readonly NPCConversation _myConversation;
        private readonly Npc _npc;

        public TalkingState(NPCConversation myConversation, Npc npc)
        {
            _myConversation = myConversation;
            _npc = npc;
        }
        public void StartState()
        {
            Debug.Log("Entró al estado de Talking");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ConversationManager.OnConversationEnded += HandleConversationEnded;
            ConversationManager.Instance.StartConversation(_myConversation);
        }
        
        public void UpdateState()
        {

        }

        public void ExitState()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ConversationManager.OnConversationEnded -= HandleConversationEnded;
        }
        private void HandleConversationEnded()
        {
            _npc.NpcStateMachine.ReverseState();
        }
    }
}