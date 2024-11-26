using UnityEngine;

namespace _scripts.UI.GameState
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject winPanel;

        public void ShowGameOver()
        {
            UnityEngine.Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }

        public void ShowWin()
        {
            UnityEngine.Time.timeScale = 0f;
            winPanel.SetActive(true);
        }
    }
}