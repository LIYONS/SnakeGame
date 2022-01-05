using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] ScoreController player1Score;
    [SerializeField] ScoreController player2Score;

    [SerializeField] TextMeshProUGUI gameOverText;

    int p1Score;
    int p2Score;
    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    public void Kill()
    {
        gameOverCanvas.SetActive(true);
        p1Score = player1Score.GetActiveScore();
        p2Score = player2Score.GetActiveScore();
        if(p1Score>p2Score)
        {
            gameOverText.text = player1Score.gameObject.tag + "  Won";
        }
        else
        {
            gameOverText.text = player2Score.gameObject.tag + "  Won";
        }
        SoundManager soundManager = SoundManager.instance;
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.GameOver);
            soundManager.StopMusic();
        }
    }
}
