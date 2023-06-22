using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    running,
    player1Won,
    player2Won,
    draw
}

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance { get; private set; }

    bool gameWon = false;
    GameState gameState = GameState.running;


    private void Awake()
    {
        StartTheGame();
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnPlayerDied(PlayerBodyBehaviour playerBodyThatLost)
    {
        if(playerBodyThatLost.GetTeam() == Teams.Team1)
        {
            gameState = GameState.player2Won;
        }
        else if(playerBodyThatLost.GetTeam() == Teams.Team2)
        {
            gameState = GameState.player1Won;
        }
        OnGameFinished();
    }

    public void OnBothPlayerDied()
    {
        gameState = GameState.draw;
        OnGameFinished();
    }

    void OnGameFinished()
    {
        PauseTheGame();
        Debug.Log(gameState.ToString());
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0;
    }

    public void StartTheGame()
    {
        Time.timeScale = 1;
    }

    public GameState GetGameState()
    {
        return gameState;
    }
}
