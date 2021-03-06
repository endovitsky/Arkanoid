﻿using System;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameFlowManager : MonoBehaviour, IInitializable, IUninitializable
    {
        public event Action<GameStatus> CurrentGameStatusChanged = delegate { };

        private GameStatus _currentGameStatus;
        public GameStatus CurrentGameStatus
        {
            get
            {
                return _currentGameStatus;
            }
            set
            {
                if (_currentGameStatus == value)
                {
                    return;
                }

                _currentGameStatus = value;

                if (_currentGameStatus == GameStatus.Win ||
                    _currentGameStatus == GameStatus.Loss)
                {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                    Time.timeScale = 0.0f;
                }

                CurrentGameStatusChanged.Invoke(_currentGameStatus);
            }
        }

        public void Initialize()
        {
            CurrentGameStatus = GameStatus.InProgress;

            Time.timeScale = 1.0f;

            GameManager.Instance.GameObjectsManager.AllBrickViewInstancesWasDestroyed += GameObjectsManagerOnAllBrickViewInstancesWasDestroyed;
        }

        public void Uninitialize()
        {
            GameManager.Instance.GameObjectsManager.AllBrickViewInstancesWasDestroyed -= GameObjectsManagerOnAllBrickViewInstancesWasDestroyed;
        }

        private void GameObjectsManagerOnAllBrickViewInstancesWasDestroyed()
        {
            CurrentGameStatus = GameStatus.Win;
        }

        public enum GameStatus
        {
            InProgress,
            Win,
            Loss
        }
    }
}
