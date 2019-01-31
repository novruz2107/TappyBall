using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    public GameObject pipeHolder;
    bool started;

	// Use this for initialization
	void Start () {
        started = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InvokeRepeating("SpawnPipes", 0.1f, 2f);
                started = true;
            }
            
        }
        
    }

    void SpawnPipes()
    {
        Instantiate(pipeHolder, new Vector3(transform.position.x, Random.Range(-1.2f, 0.0f), 0), Quaternion.identity);
    }

     
}
