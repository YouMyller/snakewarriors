using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myDeath : MonoBehaviour {

    private float destWait = .5f;
    public float creationWait = 1f;

    public float distanceP1;
    public float distanceP2;

    public GameObject p1;
    public GameObject p2;
    public GameObject thisBodyPart;

    public bool testBoolean = false;

    public SnakeTest snakeTestp1;
    public SnakeTest snakeTestp2;

    private bool eaten = false;

    /*public Transform p1;
    public Transform p2;
    public Transform thisBodyPart;*/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Distance();

        creationWait -= Time.deltaTime;

        if (gameObject.tag == "Null")
        {
            destWait -= Time.deltaTime;

            if (destWait < 0)
            {
                destWait -= Time.deltaTime;
            }

            if (destWait <= 0)
            {
                /*if (transform.parent.tag == "P1" && eaten == false && snakeTestp1.points > 0)
                {
                    snakeTestp1.points -= 1;
                    eaten = true;
                    snakeTestp2.SetScoreText();
                }
                if (transform.parent.tag == "P2" && eaten == false && snakeTestp2.points > 0)
                {
                    snakeTestp2.points -= 1;
                    eaten = true;
                    snakeTestp1.SetScoreText();
                }*/
                Destroy(gameObject);
            }
        }
	}

    public void Distance()
    {
        distanceP1 = Vector3.Distance(p1.transform.position, thisBodyPart.transform.position);

        distanceP2 = Vector3.Distance(p2.transform.position, thisBodyPart.transform.position);

        if (testBoolean == true)
        {
            Debug.Log(distanceP2);
        }

        if (transform.parent.tag == "P2")
        {
            if (distanceP1 <= 1 && p1.tag == "P1")
            {
                gameObject.tag = "Null";
                //Debug.Log("Erikoiskosketus. (Ykkönen söi)");
            }
        }

        if (transform.parent.tag == "P1")
        {
            if (distanceP2 <= 1 && p2.tag == "P2")
            {
                gameObject.tag = "Null";
                //Debug.Log("Erikoiskosketus. (Kakkonen söi)");
            }
        }
    }

    //THIS ONE IS FOR THE BODY PARTS
    /*
    public void OnCollisionEnter(Collision collision)
    {
        if (transform.parent.tag == "P1")
        {
            if (collision.gameObject.CompareTag("P2"))
            {
                Debug.Log("P1 koskettaa P2 (Collision Enter)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }

        if (transform.parent.tag == "P2")
        {
            if (collision.gameObject.CompareTag("P1"))
            {
                Debug.Log("P2 koskettaa P1 (Collision Enter)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (transform.parent.tag == "P1")
        {
            if (collision.gameObject.CompareTag("P2"))
            {
                Debug.Log("P1 koskettaa P2 (Collision Stay)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }

        if (transform.parent.tag == "P2")
        {
            if (collision.gameObject.CompareTag("P1"))
            {
                Debug.Log("P2 koskettaa P1 (Collision Stay)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (transform.parent.tag == "P1")
        {
            if (collision.gameObject.CompareTag("P2"))
            {
                Debug.Log("P1 koskettaa P2 (Collision Exit)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }
        if (transform.parent.tag == "P2")
        {
            if (collision.gameObject.CompareTag("P1"))
            {
                Debug.Log("P2 koskettaa P1 (Collision Exit)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.tag = "Null";
        }

        if (transform.parent.tag == "P1")
        {
            if (collision.gameObject.CompareTag("P2"))
            {
                Debug.Log("P1 koskettaa P2 (Trigger Enter)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";                }
            }
        }

        if (transform.parent.tag == "P2")
        {
            if (collision.gameObject.CompareTag("P1"))
            {
                Debug.Log("P2 koskettaa P1 (Trigger Enter)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.tag = "Null";
        }

        if (transform.parent.tag == "P1")
        {
            if (collision.gameObject.CompareTag("P2"))
            {
                Debug.Log("P1 koskettaa P2 (Trigger Exit)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }

        if (transform.parent.tag == "P2")
        {
            if (collision.gameObject.CompareTag("P1"))
            {
                Debug.Log("P2 koskettaa P1 (Trigger Exit)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }
    }

    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.tag = "Null";
        }

        if (transform.parent.tag == "P1")
        {
            if (collision.gameObject.CompareTag("P2"))
            {
                Debug.Log("P1 koskettaa P2 (Trigger Stay)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }

        if (transform.parent.tag == "P2")
        {
            if (collision.gameObject.CompareTag("P1"))
            {
                Debug.Log("P2 koskettaa P1 (Trigger Stay)");
                if (creationWait <= 0)
                {
                    gameObject.tag = "Null";
                }
            }
        }
    }*/
}
