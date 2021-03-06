﻿using UnityEngine;
using Utilities;

namespace Managers
{
    [RequireComponent(typeof(UserInterfaceManager))]
    [RequireComponent(typeof(GameObjectsManager))]
    [RequireComponent(typeof(GameFlowManager))]
    [RequireComponent(typeof(CountdownManager))]
    [RequireComponent(typeof(BrickMovementManager))]
    [RequireComponent(typeof(BrickHealthManager))]
    [RequireComponent(typeof(ScoreManager))]
    public class GameManager : MonoBehaviour, IInitializable, IUninitializable
    {
        // static instance of GameManager which allows it to be accessed by any other script 
        public static GameManager Instance;

        public UserInterfaceManager UserInterfaceManager
        {
            get { return this.gameObject.GetComponent<UserInterfaceManager>(); }
        }

        public GameObjectsManager GameObjectsManager
        {
            get { return this.gameObject.GetComponent<GameObjectsManager>(); }
        }

        public GameFlowManager GameFlowManager
        {
            get { return this.gameObject.GetComponent<GameFlowManager>(); }
        }

        public CountdownManager CountdownManager
        {
            get { return this.gameObject.GetComponent<CountdownManager>(); }
        }

        public BrickMovementManager BrickMovementManager
        {
            get { return this.gameObject.GetComponent<BrickMovementManager>(); }
        }

        public BrickHealthManager BrickHealthManager
        {
            get { return this.gameObject.GetComponent<BrickHealthManager>(); }
        }

        public BrickColorManager BrickColorManager
        {
            get { return this.gameObject.GetComponent<BrickColorManager>(); }
        }

        public ScoreManager ScoreManager
        {
            get { return this.gameObject.GetComponent<ScoreManager>(); }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(this.gameObject); // sets this to not be destroyed when reloading scene 
            }
            else
            {
                if (Instance != this)
                {
                    Instance.Uninitialize();

                    // this enforces our singleton pattern, meaning there can only ever be one instance of a GameManager 
                    Destroy(this.gameObject);
                }
            }

            Instance.Initialize();
        }

        public void Initialize()
        {
            UserInterfaceManager.Initialize();
            GameObjectsManager.Initialize();
            GameFlowManager.Initialize();
            CountdownManager.Initialize();
            BrickMovementManager.Initialize();
            BrickHealthManager.Initialize();
            BrickColorManager.Initialize();
            ScoreManager.Initialize();
        }

        public void Uninitialize()
        {
            UserInterfaceManager.Uninitialize();
            GameObjectsManager.Uninitialize();
            GameFlowManager.Uninitialize();
            CountdownManager.Uninitialize();
            BrickMovementManager.Uninitialize();
            BrickHealthManager.Uninitialize();
            BrickColorManager.Uninitialize();
            ScoreManager.Uninitialize();
        }

        public void Reinitialize()
        {
            Uninitialize();
            Initialize();
        }
    }
}
