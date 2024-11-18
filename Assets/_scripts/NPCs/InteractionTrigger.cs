using DialogueEditor;
using UnityEngine;

namespace _scripts.NPCs
{
    public class InteractionTrigger : MonoBehaviour
    {
        [SerializeField] private NPCConversation npcConversation;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ConversationManager.Instance.StartConversation(npcConversation);
                }
            }
        }
    }
}