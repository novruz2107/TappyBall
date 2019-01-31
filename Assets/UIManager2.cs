using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager2 : MonoBehaviour {


    public static UIManager2 instance;
    public Text scoreText;
    public GameObject gameOverPanel;
    public Animator anim;
    int score;
  

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
       
        if (score < PlayerPrefs.GetInt("score"))
        {
            score = PlayerPrefs.GetInt("score");
            StartCoroutine("AnimCont");
        }
	}

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        PlayerPrefs.SetInt("score", 0);

    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator AnimCont()
    {
        anim.SetTrigger("flag");
        yield return new WaitForSeconds(0.5f);
        scoreText.text = ScoreManager.instance.score.ToString();
    }
}
