using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score;
    private void Start()
    {
        score = 0;
        scoreText.text = gameObject.tag + "-" + score;
    }

    [SerializeField] int scoreForGainer;

    public void IncreaseScore()
    {
        score += scoreForGainer;
        scoreText.text = gameObject.tag + "-" + score;
    }

    public void SetScoreForGainer(int score)
    {
        scoreForGainer = score;
    }
    public int GetScoreForGainer()
    {
        return scoreForGainer;
    }

    public int GetActiveScore()
    {
        return score;
    }
}
