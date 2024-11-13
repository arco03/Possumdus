using _scripts.Objects.Interactable;
using _scripts.Objects.Manager;
using _scripts.TaskSystem;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TaskScriptable/InteractionTask", fileName = "InteractionTask", order = 1)]
public class InteractionTask : Tasks
{    
    public string value1;
    public string value2;
    public string value3;
    public string value4;

    public List<string> currentCombination = new();
    public List<string> correctCombination = new() { };

    [SerializeField] public List<InteractionButton> buttons = new();

    public void Awake()
    {
        correctCombination = new List<string>() { value1, value2, value3, value4 };
    }
}
