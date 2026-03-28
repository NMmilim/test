using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeLeft = 60f;
    public TMP_Text timerText;

    private bool isGameOver = false;
    public RestartGame restartGame;


    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 10)
        {
            timerText.color = Color.red;
        }

        if (timeLeft <= 0)
        {
            timeLeft = 0;

            GameOver();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;


        if (restartGame != null)
            restartGame.Restart();
    }
}