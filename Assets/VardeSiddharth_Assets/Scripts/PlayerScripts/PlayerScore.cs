using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI playerScoreText;
    [SerializeField]
    string playerName;

    private int Score { get; set; }
    int scoreMultiplier = 1;

    private void Start()
    {
        SetScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        Score += (scoreToAdd * scoreMultiplier);
        SetScoreText();
    }

    public void ReduceScore(int scoreToReduce)
    {
        Score -= scoreToReduce;
        if(Score <= 0)
        {
            Score = 0;
        }
        SetScoreText();
    }

    void SetScoreText()
    {
        playerScoreText.text = playerName + ":\n" + Score;
    }

    public void ChangeScoreMultiplier(int value)
    {
        if(value < 1)
        {
            value = 1;
        }

        scoreMultiplier = value;
    }
}
