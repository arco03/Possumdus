using System.Collections.Generic;
using _scripts.Objects.Interactable;
using UnityEngine;

namespace _scripts.TaskSystem.NewTaskSystem
{
    [CreateAssetMenu(menuName = "TaskScriptable/InteractionTask", fileName = "InteractionTask", order = 1)]
    public class InteractionTask : Tasks
    {    

        [Header("Interaction Task Settings")]
        public string value1;
        public string value2;
        public string value3;
        public string value4;

        public List<string> currentCombination = new();
        public List<InteractionButton> buttons = new();
        
        public List<string> correctCombination = new() { };
        
#if UNITY_EDITOR
        private void OnEnable()
        {
            buttons.Clear();
            currentCombination.Clear();
            base.isReached = false;
        }
#endif
        public void Awake()
        {
            correctCombination = new List<string>() { value1, value2, value3, value4 };
        }
    }
}
