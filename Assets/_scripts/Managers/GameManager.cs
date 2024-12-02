using System;
using _scripts.Objects.Oxygen;
using UnityEngine;

namespace _scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Game, 
            GameOver
        }
        public GameState CurrentState { get; private set; }

        private void OnEnable()
        {
            Oxygen.OnOxygenOver += HandleGameOver;
        }
        
        private void Start()
        {
           ChangeState(GameState.Game);
        }
        
        private void HandleGameOver()
        {
            ChangeState(GameState.GameOver);
            //llamar pantalla gameOver
        }
        private void ChangeState(GameState newState)
        {
            CurrentState = newState;
            Debug.Log($"Game State change to: {newState}");
        }
        
        private void OnDisable()
        {
            Oxygen.OnOxygenOver -= HandleGameOver;
        }
    }
}