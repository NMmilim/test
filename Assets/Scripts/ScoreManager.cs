using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int winScore = 1000;

    public TMP_Text scoreText;

    private bool hasWon = false;
    IEnumerator LoadEndSceneAfterDelay()
    {
        scoreText.text = "<size=150%><color=yellow>YOU WIN!</color></size>";

        BombShooter shooter = FindFirstObjectByType<BombShooter>();
        if (shooter != null)
            shooter.enabled = false;

        yield return new WaitForSecondsRealtime(2f);

        SceneManager.LoadScene("EndCredits");
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();

        CheckWin();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }

    void CheckWin()
    {
        if (!hasWon && score >= winScore)
        {
            hasWon = true;

            StartCoroutine(LoadEndSceneAfterDelay());
        }
    }


}