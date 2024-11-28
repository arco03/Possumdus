using UnityEngine;

namespace _scripts.UI.GameState
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private GameStateView stateView;

        public void GameOver()
        {
            stateView.ShowGameOver();
        }

        public void Win()
        {
            stateView.ShowWin();
        }
    }
}