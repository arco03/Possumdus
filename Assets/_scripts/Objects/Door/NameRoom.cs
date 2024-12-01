using System.Collections;
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
            textName.text = roomName;
            textName.gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                textName.gameObject.SetActive(true);
                StartCoroutine(EnableName());
            }
        }

        private IEnumerator EnableName()
        {
            yield return new WaitForSeconds(3f);
            textName.gameObject.SetActive(false);
        }
    }
}