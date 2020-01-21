using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text scorePoint;
    public int score;

    public Text highScoreTXT;
    public int highScore;

    public AudioSource bonus;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore_jtor", 0);
        highScoreTXT.text = PlayerPrefs.GetInt("highscore_jtor", 0).ToString();

        score = 0;
        scorePoint.text = "0";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "coin")
        {
            bonus.Play();
            score += 5;
            scorePoint.text = score.ToString();
        }
    }

    private void Update()
    {
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore_jtor", highScore);
            highScoreTXT.text = highScore.ToString();
        }
    }

}
