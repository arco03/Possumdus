using TMPro;
using UnityEngine;

namespace _scripts.Objects.Door
{
    public class NameRoom : MonoBehaviour
    {
        [SerializeField] private TMP_Text textName;
        [SerializeField] private string roomName;

        private void Start()
        {
            textName = GameObject.FindWithTag("RoomTextName")?.GetComponent<TMP_Text>();
            if (textName != null) textName.text = " ";
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                textName.text = roomName;
            }
        }
    }
}