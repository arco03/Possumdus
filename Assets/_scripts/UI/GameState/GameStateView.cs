using UnityEngine;

namespace _scripts.UI.GameState
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private GameObject firstEndPanel;
        [SerializeField] private GameObject secondEndPanel;
        [SerializeField] private GameObject thirdEndPanel;
                
        public void ShowEnd1()
        {
            UnityEngine.Time.timeScale = 0f;
            firstEndPanel.SetActive(true);
        }

        public void ShowEnd2()
        {
            UnityEngine.Time.timeScale = 0f;
            secondEndPanel.SetActive(true);
        }
        public void ShowEnd3()
        {
            UnityEngine.Time.timeScale = 0f;
            thirdEndPanel.SetActive(true);
        }
    }
}