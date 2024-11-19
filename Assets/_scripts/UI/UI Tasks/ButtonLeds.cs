using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLeds : MonoBehaviour
{
    public Image ledImage;
    public Image buttonImage;
    public Sprite ledOnSprite;
    public Sprite ledOffSprite;
    public Sprite buttonOffSprite;
    public Sprite buttonOnSprite;
    public int state;
    public int targetState;

    public delegate void ButtonStateChanged(ButtonLeds button);
    public event ButtonStateChanged OnStateChanged;

    private void Start()
    {
        state = ( targetState == 0) ? 1 : 0;
                UpdateLed();
                UpdateButton();
    }

    public void ToggleState()
    {
        state = state == 0 ? 1 : 0;
                OnStateChanged?.Invoke(this);
                UpdateLed();
                UpdateButton();
    }
   public void UpdateLed()
    {
    
    ledImage.sprite = (state == targetState) ? ledOnSprite : ledOffSprite;
    }

    public void UpdateButton()
    {
        buttonImage.sprite = (state == targetState) ? buttonOnSprite : buttonOffSprite;
    }
}
