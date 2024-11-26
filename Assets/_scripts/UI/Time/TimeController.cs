using UnityEngine;

namespace _scripts.UI.Time
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private TimeView timeView;

        public void Initialize()
        {
            timeView.Initialize();
        }

        public void Close()
        {
            timeView.Close();
        }

        public void UpdateTime(float time)
        {
            timeView.SetTime(time);
        }
    }
}