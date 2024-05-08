using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public float remainingtime;
    public CharacterMovement charactermovement;
    public GemFallScript gemfallscript;
    public GemFallScript greengemfallscript;
    public GemFallScript blackgemfallscript;
    public GemFallScript coinspeedupscript;
    public AudioSource backgroundmusic;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

  
    public static void AddSccore(int amount)
    {
        score += amount;
    }
    public static void MultipleScore(int amount)
    {
        score *= amount;
    }
    public static void DivideScore(int amount)
    {
        score /= amount;
    }

    private void Start()
    {
        remainingtime = 20f;
        StartCoroutine(CountDownTimer());
    }

    private void Update()
    {
        scoreText.text = "score: " + score + " | Time:" + remainingtime;
    }

    private IEnumerator CountDownTimer()
    {
        while (remainingtime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingtime--;
        }
        if (remainingtime <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverText.text = "Game Over!\nScore: " + score;
        gameOverPanel.SetActive(true);
        charactermovement.isGameOver = true;
        gemfallscript.isGameOver = true;
        greengemfallscript.isGameOver = true;
        blackgemfallscript.isGameOver = true;
        coinspeedupscript.isGameOver = true;
        backgroundmusic.Stop();
    }
}