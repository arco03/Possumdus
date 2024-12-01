using System;
using UnityEngine;

namespace _scripts.Objects.Door
{
    public class Doors : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float closeDelay = 3f;
        private bool isPlayerNear = false;

        private void Start()
        {
            animator.SetTrigger("CloseDoor");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Npc"))
            {
                isPlayerNear = true;
                animator.SetTrigger("OpenDoor");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Npc"))
            {
                isPlayerNear = false;
                Invoke(nameof(CloseDoor), closeDelay);
            }
        }

        private void CloseDoor()
        {
            if (!isPlayerNear)
            {
                animator.SetTrigger("CloseDoor");
            }
        }
    }
}