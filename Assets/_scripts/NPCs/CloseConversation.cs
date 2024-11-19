using System.Collections;
using DialogueEditor;
using UnityEngine;

namespace _scripts.NPCs
{
    public class CloseConversation : MonoBehaviour
    {
        public void Close()
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(20);
        }
    }
}