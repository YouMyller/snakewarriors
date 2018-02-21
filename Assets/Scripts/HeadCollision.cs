using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour {

    public GameObject spawnPosition;
    private int colorOne;
    private int colorTwo;
    private bool timeToColor;
    public HeadCollision playerOneHead;
    private float time;

    public SnakeTest st;
    public List<GameObject> bodyPartsNew = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        timeToColor = true;

        if (gameObject.tag == "P1")
        {
            colorOne = Random.Range(0, 4);
            if (colorOne == 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            if (colorOne == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            if (colorOne == 2)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (colorOne == 3)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (colorOne == 4)
            {
                Color32 pink = new Color32(221, 153, 214, 255);
                gameObject.GetComponent<Renderer>().material.color = pink;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        TimeToColor();
    }

    public void TimeToColor()
    {
        if (gameObject.tag == "P2" && timeToColor == true)
        {
            colorTwo = Random.Range(0, 4);
            if (colorTwo == 0)
            {
                //Green
                if (playerOneHead.colorOne == 0)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    timeToColor = false;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    timeToColor = false;
                }
            }
            if (colorTwo == 1)
            {
                //Red
                if (playerOneHead.colorOne == 1)
                {
                    Color32 cyan = new Color32(115, 255, 255, 255);
                    gameObject.GetComponent<Renderer>().material.color = cyan;
                    timeToColor = false;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    timeToColor = false;
                }
            }
            if (colorTwo == 2)
            {
                //Blue
                if (playerOneHead.colorOne == 2)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    timeToColor = false;
                }
                else
                {
                    Color32 cyan = new Color32(146, 255, 255, 255);
                    gameObject.GetComponent<Renderer>().material.color = cyan;
                    timeToColor = false;
                }
            }
            if (colorTwo == 3)
            {
                //Yellow
                if (playerOneHead.colorOne == 3)
                {
                    Color32 pink = new Color32(221, 153, 214, 255);
                    gameObject.GetComponent<Renderer>().material.color = pink;
                    timeToColor = false;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    timeToColor = false;
                }
            }
            if (colorTwo == 4)
            {
                //Pink
                if (playerOneHead.colorOne == 4)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    timeToColor = false;
                }
                else
                {
                    Color32 pink = new Color32(221, 153, 214, 255);
                    gameObject.GetComponent<Renderer>().material.color = pink;
                    timeToColor = false;
                }
            }
        }
        bodyPartsNew = st.bodyParts;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = spawnPosition.transform.position;
            if (bodyPartsNew.Count > 1)
            {
                bodyPartsNew[bodyPartsNew.Count - 1].tag = "Null";
            }
        }
    }
}
