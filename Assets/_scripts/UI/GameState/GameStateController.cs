using UnityEngine;

namespace _scripts.UI.GameState
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private GameStateView stateView;

        public void End1()
        {
            stateView.ShowEnd1();
        }

        public void End2()
        {
            stateView.ShowEnd2();
        }

        public void End3()
        {
            stateView.ShowEnd3();
        }
    }
}