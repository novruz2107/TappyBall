using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public int score;
    public Text highScoreText;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void incrementScore()
    {
        score++;
        PlayerPrefs.SetInt("score", score);
    }

    public void StopScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        ScoreManager.instance.highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }
}

