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
    private bool kill = false;

    private Color myColor;

    private float startSize = 1;
    private float minSize = 0;
    public float currScale;

    private Vector3 targetScale;
    private Vector3 baseScale;

    public float shrinkSpeed = .1f;

    // Use this for initialization
    void Start ()
    {
        if (transform.parent.tag == "P1")
        {
            myColor = snakeTestp1.newColor;
        }
        if (transform.parent.tag == "P2")
        {
            myColor = snakeTestp2.newColor;
        }

        baseScale = transform.localScale;
        transform.localScale = baseScale * startSize;
        currScale = startSize;
        targetScale = baseScale * startSize;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Distance();

        creationWait -= Time.deltaTime;

        if (gameObject.tag == "Null")
        {
            destWait -= Time.deltaTime;

            if (destWait <= 0)
            {
                //Ennen kuin objekti kuolee / kun koskettaa päätä, antaa päälle muistiin oman materiaalin värinsä. Seuraava objekti, jonka pää luo, on tämän värinen.
                kill = true;    //WATCH OUT, tää saattaa rikkoa jotain

                if (transform.parent.tag == "P1" && kill == true)
                {
                    Debug.Log("Beginning of the end, MY END");
                    snakeTestp2.AddBodyPart();  
                    snakeTestp2.SetScoreText();
                    snakeTestp2.newColor = myColor;

                    /*Debug.Log("Got through that part!");
                    transform.localScale = Vector3.Lerp(transform.localScale, targetScale, shrinkSpeed * Time.deltaTime);
                    currScale--;
                    Debug.Log(currScale);
                    currScale = Mathf.Clamp(currScale, minSize, startSize + 1);
                    targetScale = baseScale * currScale;*/
                }
                if (transform.parent.tag == "P2" && kill == true)
                {
                    snakeTestp1.AddBodyPart();
                    snakeTestp1.SetScoreText();
                    snakeTestp1.newColor = myColor;

                    /*transform.localScale = Vector3.Lerp(transform.localScale, targetScale, shrinkSpeed * Time.deltaTime);
                    currScale -= .01f;
                    currScale = Mathf.Clamp(currScale, minSize, startSize + 1);
                    targetScale = baseScale * currScale;*/
                }
                Debug.Log("AUUGH I'M DYING, GOOD");
                Destroy(gameObject);
            }
        }
	}


    public void Distance()
    {
        distanceP1 = Vector3.Distance(p1.transform.position, thisBodyPart.transform.position);

        distanceP2 = Vector3.Distance(p2.transform.position, thisBodyPart.transform.position);

        /*if (testBoolean == true)
        {
            Debug.Log(distanceP2);
        }*/

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        foreach (GameObject target in bullets)
        {
            float distanceB = Vector3.Distance(target.transform.position, transform.position);

            if(distanceB < 1)
            {
                gameObject.tag = "Null";
                kill = true;
            }
        }

        if (transform.parent.tag == "P2")
        {
            if (distanceP1 <= 1 && p1.tag == "P1")
            {
                gameObject.tag = "Null";
                kill = true;
            }
        }

        if (transform.parent.tag == "P1")
        {
            if (distanceP2 <= 1 && p2.tag == "P2")
            {
                gameObject.tag = "Null";
                kill = true;
            }
        }
    }
}
