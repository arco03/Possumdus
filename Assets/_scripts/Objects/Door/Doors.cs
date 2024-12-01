using UnityEngine;

namespace _scripts.Objects.Door
{
    public class Doors : MonoBehaviour
    {
        [SerializeField] public Animator animator;
        [SerializeField] private string animationName;
        public void AnimationDoor()
        {  
            animator.SetTrigger(animationName);
        }
    }
}