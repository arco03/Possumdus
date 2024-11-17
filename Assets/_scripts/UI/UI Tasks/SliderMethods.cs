using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Rendering.ShadowCascadeGUI;
using static UnityEngine.Rendering.DebugUI;

public class SliderMethods : MonoBehaviour
{
    public SliderTasks sliderTasks;
    public GameObject InteractablePanel;
    public GameObject interactableText;
    public GameObject reticle;
    public bool isPlayerInRanges;
    public bool toggle;

    public void OpenCloseUITask()
    {
        toggle = !toggle;
        if (toggle)
        {
            InteractablePanel.SetActive(true);
            Debug.Log("Slider Task opened");
        }
        else
        {
            InteractablePanel.SetActive(false);            
            Debug.Log("Easter Egg closed");
        }
    }
    private void Update()
    {
        if (isPlayerInRanges && Input.GetKeyDown(KeyCode.E))
        {
            OpenCloseUITask();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !sliderTasks.isCompleted)
        {            
            isPlayerInRanges = true;
            interactableText.SetActive(true);
            reticle.SetActive(false);
        }
    }      
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRanges = false;
            interactableText.SetActive(false);
            reticle.SetActive(true);
        }
    }
 }



