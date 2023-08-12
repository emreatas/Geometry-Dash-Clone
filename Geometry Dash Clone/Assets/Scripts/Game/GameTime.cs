using GDClone.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnGameStart += GameManager_OnGameStart;
        GameManager.OnGameLose += GameManager_OnGameLose;
        GameManager.OnGameWin += GameManager_OnGameWin;
    }

    private void GameManager_OnGameWin()
    {
        TimeStop();
    }
    private void GameManager_OnGameStart()
    {
        TimeStart();
    }
    private void GameManager_OnGameLose()
    {
        TimeStop();
    }
    private void OnDisable()
    {
        GameManager.OnGameStart -= GameManager_OnGameStart;
        GameManager.OnGameLose -= GameManager_OnGameLose;
        GameManager.OnGameWin -= GameManager_OnGameWin;
    }
    void TimeStart()
    {
        Time.timeScale = 1;
    }
    void TimeStop()
    {
        Time.timeScale = 0;
    }
}
