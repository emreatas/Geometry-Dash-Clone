using GDClone.CubeCharacter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDClone.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private void Awake()
        {
            instance = this;
        }

        public static event Action<GameMode, SpeedState, bool, States> OnChangeMovement;

        public void ChangeMovement(GameMode gameMode, SpeedState speedState, bool gravityMode, States state)
        {
            if (OnChangeMovement != null)
            {
                OnChangeMovement(gameMode, speedState, gravityMode, state);
            }
        }

        public static event Action OnGameWin;

        public void GameWin()
        {
            if (OnGameWin != null)
            {
                OnGameWin();
            }
        }
        public static event Action OnGameLose;

        public void GameLose()
        {
            if (OnGameLose != null)
            {
                OnGameLose();
            }
        }

        public static event Action OnGameStart;

        public void GameStart()
        {
            if (OnGameStart != null)
            {
                OnGameStart();
            }
        }

    }
}