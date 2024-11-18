using UnityEngine;
using UnityEngine.UI;

public class ButtonLeds : MonoBehaviour
{
    public Image ledImage;
    public Sprite ledOnSprite;
    public Sprite ledOffSprite;
    public int state;

    public delegate void ButtonStateChanged(ButtonLeds button);
    public event ButtonStateChanged OnStateChanged;

    public void ToggleState()
    {
        state = state == 0 ? 1 : 0;
        ledImage.sprite = state == 1 ? ledOnSprite : ledOffSprite;     
        OnStateChanged?.Invoke(this);
    }
}
