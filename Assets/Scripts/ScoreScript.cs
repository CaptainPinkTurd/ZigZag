using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] CanvasGroup scoreUI;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    internal static int score;
    private float scoreTime;

    private void Start()
    {
        scoreTime = Time.time;
        scoreUI.alpha = 0f;
        score = 0;
        scoreText.text = score.ToString();
        highScoreText.text = "Best: " + GetHighScore().ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (CharacterMovementScript.animator.GetBool("gameStarted"))
        {
            if (score >= GetHighScore())
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScoreText.text = "Best: " + score.ToString();
            }
            scoreText.text = score.ToString();
            if(scoreUI.alpha == 0f)
            {
                scoreUI.alpha = 1f;
            }
            if(Time.time >= scoreTime)
            {
                score++;
                scoreTime += 1.75f;
            }
        }
    }
    private int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }
}
