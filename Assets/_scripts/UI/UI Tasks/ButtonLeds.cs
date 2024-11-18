using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ButtonLeds : MonoBehaviour
{
    public Image ledImage;
    public Sprite ledOnSprite;
    public Sprite ledOffSprite;
    public int state;
    public int targetState;

    public delegate void ButtonStateChanged(ButtonLeds button);
    public event ButtonStateChanged OnStateChanged;

    public void ToggleState()
    {
        state = state == 0 ? 1 : 0;
        OnStateChanged?.Invoke(this);
        UpdateLED();
    }
    public void UpdateLED()
    {
    
    ledImage.sprite = (state == targetState) ? ledOnSprite : ledOffSprite;
    }
}
