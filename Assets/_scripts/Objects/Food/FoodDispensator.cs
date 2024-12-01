using _scripts.Player;
using System.Collections;
using UnityEngine;

public class FoodDispensator : MonoBehaviour
{
    public HungerManager hungerManager;
    public GameObject hungryText;
    
    void Start()
    {
        hungerManager = FindObjectOfType<HungerManager>();
        if (hungerManager == null)
            Debug.LogError("Hunger Manager script not found in the scene.");
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (hungerManager != null)
            {
                if (hungerManager._isHungry == true)
                {
                    hungerManager.Eat();
                }
                if (hungerManager._isHungry == false)
                {
                    hungryText.gameObject.SetActive(true);
                    Debug.Log("youre not hungry!!");
                    StartCoroutine(WaitToDeactivateHungryText());
                }
            }
        }
    }
    private IEnumerator WaitToDeactivateHungryText()
    {
        yield return new WaitForSecondsRealtime(3);
        hungryText.gameObject.SetActive(false);

    }

}
