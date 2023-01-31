using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public enum GameState
    {
        Starting,
        Playing,
        Paused,
        GameOver
    }
    public class GameManager : MonoBehaviour
    {
        #region Properties
        public static GameManager Instance;

        #region Public
        public GameState State { get; private set; } = GameState.Starting;
        public float PlayTime { get; private set; } = 0;
        #endregion

        #region Private
        private float timerLimit = 0;
        #endregion

        #region Events
        public delegate void GameStateChanged();
        public event GameStateChanged OnGameStarted;
        public event GameStateChanged OnGamePaused;
        public event GameStateChanged OnGameResumed;
        public event GameStateChanged OnGameEnding;

        public delegate void GameTimeChanged(int m, int s);
        public event GameTimeChanged OnSurvivedTimeChanged;
        #endregion

        #endregion
        #region Methods

        #region Unity
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            StartCoroutine(StartGameRoutine());
        }

        private void Update()
        {
            if (State == GameState.Playing)
                UpdateTimer();
        }
        #endregion

        #region Public
        /// <summary>
        /// Start game
        /// </summary>
        public void StartGame()
        {
            SetGameState(GameState.Playing);
        }
        /// <summary>
        /// Game over
        /// </summary>
        public void GameOver()
        {
            SetGameState(GameState.GameOver);
        }
        /// <summary>
        /// Pause game
        /// </summary>
        public void PauseGame()
        {
            SetGameState(GameState.Paused);
        }
        /// <summary>
        /// Resume game after pause
        /// </summary>
        public void ResumeGame()
        {
            if (State == GameState.Paused)
                SetGameState(GameState.Playing);
            else
                Debug.LogWarning("Game was not paused");
        }
        #endregion

        #region Private
        private void SetGameState(GameState state)
        {
            if (State == state || state == GameState.Starting)
                return;

            GameState previous = State;
            State = state;

            if (State == GameState.Paused)
                Time.timeScale = 0f; // Pausing
            else if (State == GameState.Playing && previous == GameState.Paused)
                Time.timeScale = 1f; // Resume

            switch (state)
            {
                case GameState.Playing:
                    if (previous == GameState.Paused) OnGameResumed?.Invoke();
                    else if (previous == GameState.Starting) OnGameStarted?.Invoke();
                    break;
                case GameState.Paused:
                    OnGamePaused?.Invoke();
                    break;
                case GameState.GameOver:
                    OnGameEnding?.Invoke();
                    break;
            }
        }

        private void UpdateTimer()
        {
            PlayTime += Time.deltaTime;
            if (PlayTime >= timerLimit + 1)
            {
                timerLimit = PlayTime;
                int minutes = (int)PlayTime / 60;
                int seconds = (int)PlayTime % 60;
                OnSurvivedTimeChanged?.Invoke(minutes, seconds);
            }
        }

        private IEnumerator StartGameRoutine()
        {
            yield return new WaitForEndOfFrame();
            StartGame();
        }
        #endregion

        #endregion
    }
}
