using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {

    public float speed;
    public float upDownSpeed;
    Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        MovePipe();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void MovePipe()
    {
        rb.velocity = new Vector2(-speed, upDownSpeed);
        InvokeRepeating("SwitchUpDown", 1f, 2f);
    }

    void SwitchUpDown()
    {
        upDownSpeed = -upDownSpeed;
        rb.velocity = new Vector2(-speed, upDownSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PipeRemover")
        {
            Destroy(gameObject);
        }
    }


}
