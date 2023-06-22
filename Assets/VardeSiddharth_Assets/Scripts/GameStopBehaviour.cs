using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameStopBehaviour : MonoBehaviour
{
    public static GameStopBehaviour Instance { get; private set; }

    [SerializeField]
    Button pauseButton, restartbutton, mainMenuButton, resumeButton;
    [SerializeField]
    TextMeshProUGUI gameStateText;
    [SerializeField]
    GameObject gameStopPanel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(GameStoped);
        restartbutton.onClick.AddListener(RestartPressed);
        mainMenuButton.onClick.AddListener(MainMenuPressed);
        resumeButton.onClick.AddListener(GameResumed);
    }

    public void GameStoped()
    {
        gameStopPanel.SetActive(true);
        switch(GamePlayManager.Instance.GetGameState())
        {
            case GameState.running:
                gameStateText.text = "Game is paused";
                break;
            case GameState.player1Won:
                gameStateText.text = "Player 1 Won";
                resumeButton.interactable = false;
                break;
            case GameState.player2Won:
                gameStateText.text = "Player 2 Won";
                resumeButton.interactable = false;
                break;
            case GameState.draw:
                gameStateText.text = "Draw";
                resumeButton.interactable = false;
                break;
        }
    }

    public void GameResumed()
    {
        gameStopPanel.SetActive(false);
        GamePlayManager.Instance.StartTheGame();
    }

    public void RestartPressed()
    {
        GamePlayManager.Instance.StartTheGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuPressed()
    {
        GamePlayManager.Instance.StartTheGame();
        SceneManager.LoadScene(0);
    }
}
