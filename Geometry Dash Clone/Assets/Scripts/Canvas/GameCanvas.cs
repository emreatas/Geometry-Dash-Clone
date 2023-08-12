using GDClone.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] GameObject _gameWinPanel;
    [SerializeField] GameObject _gameLosePanel;

    private void OnEnable()
    {
        GameManager.OnGameWin += GameManager_OnGameWin;
        GameManager.OnGameLose += GameManager_OnGameLose;
    }

    private void GameManager_OnGameLose()
    {
        _gameLosePanel.SetActive(true);
    }

    private void GameManager_OnGameWin()
    {
        _gameWinPanel.SetActive(true);

    }

    private void OnDisable()
    {
        GameManager.OnGameWin -= GameManager_OnGameWin;
        GameManager.OnGameLose -= GameManager_OnGameLose;


    }


    public void RestartGame()
    {
        GameManager.instance.GameStart();

    }
}
