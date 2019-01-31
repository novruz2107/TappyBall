using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float upForce;
    Rigidbody2D rb;
    bool started;
    bool gameOver;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.isKinematic = false;
                started = true;
                rb.mass = 1.5f;
            }
        }
        else
        {
            transform.Rotate(0, 0, 2);
            if (Input.GetMouseButtonDown(0) && !gameOver) 
            {
                rb.velocity=(new Vector2(0, 0));
                rb.AddForce(new Vector2(0, upForce));
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManager.instance.incrementScore();
        }

        if(collision.gameObject.tag == "Pipe")
        {
            gameOver = true;
            ScoreManager.instance.StopScore();
            UIManager2.instance.GameOver();
            
        }
    }
}
