using System;
using _scripts.Objects.Oxygen;
using _scripts.UI.GameState;
using UnityEngine;

namespace _scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Game, 
            Win,
            GameOver
        }
        public GameState CurrentState { get; private set; }
        [SerializeField] private GameStateController gameStateController;

        private void OnEnable()
        {
            //Oxygen.OnOxygenOver += HandleGameOver;
            TimeManager.OnTimeOver += HandleEndGameValidation;
        }
        
        private void Start()
        {
           ChangeState(GameState.Game);
           Time.timeScale = 1;
        }
        
        private void HandleEndGameValidation()
        {
            //TODO:
            if (true)
            {
                ChangeState(GameState.Win);
                gameStateController.Win();
            }
            else
            {
                ChangeState(GameState.GameOver);
                gameStateController.GameOver();
                //llamar pantalla gameOver
            }
        }
        private void ChangeState(GameState newState)
        {
            CurrentState = newState;
            Debug.Log($"Game State change to: {newState}");
        }
        
        private void OnDisable()
        {
            //Oxygen.OnOxygenOver -= HandleGameOver;
            TimeManager.OnTimeOver -= HandleEndGameValidation;
        }
    }
}