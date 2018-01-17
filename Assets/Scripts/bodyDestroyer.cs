using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyDestroyer : MonoBehaviour {

    public float destWait = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    //THIS ONE IS FOR THE BULLETS (doesn't actually do anything atm)

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BodyPart"))
        {
            //Debug.Log("Collidaa");
            collision.gameObject.tag = "Null";

            destWait -= Time.deltaTime;

            if (destWait <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BodyPart"))
        {
            //Debug.Log("Collidaa");
            collision.gameObject.tag = "Null";

            if (destWait <= 0)
            {
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Head"))
        {
            Debug.Log("I mean, this is colliding just fine.");
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("BodyPart"))
        {
            //Debug.Log("Collidaa");
            collision.gameObject.tag = "Null";

            if (destWait <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
