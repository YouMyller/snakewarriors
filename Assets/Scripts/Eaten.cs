using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eaten : MonoBehaviour {

    private SnakeTest st;

	// Use this for initialization
	void Start ()
    {
        st = GetComponent<SnakeTest>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("P1") || (collision.gameObject.CompareTag("P2")))
        {
            Destroy(gameObject);
        }
    }
}
