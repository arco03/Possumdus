using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UITasksImages
{
    public class ButtonInteraction : MonoBehaviour
    {
        public Image on;
        public Image up;
        public bool isOn;
        public bool isUp;

        public void IsUp()
        {
            isUp = !isUp;
            up.enabled = isUp;
        }

        public void IsOn()
        {
            isOn = !isOn;
            on.enabled = isOn;
        }






    }
}
