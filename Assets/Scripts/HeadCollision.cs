using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour {

    public GameObject spawnPosition;
<<<<<<< HEAD
    private int colorOne;
    private int colorTwo;
    private bool timeToColor;
    public HeadCollision playerOneHead;
    private float time;

	// Use this for initialization
	void Start ()
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
=======
    public SnakeTest st;
    public List<GameObject> bodyPartsNew = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        bodyPartsNew = new List<GameObject>(st.bodyParts);
>>>>>>> c23e222c47b14dd1918404c02f1de7d2c27e7f2c
    }
	
	// Update is called once per frame
	void Update ()
    {
<<<<<<< HEAD
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
=======
        bodyPartsNew = st.bodyParts;
>>>>>>> c23e222c47b14dd1918404c02f1de7d2c27e7f2c
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = spawnPosition.transform.position;
<<<<<<< HEAD
=======
            bodyPartsNew[bodyPartsNew.Count - 1].tag = "Null";
            //
            //Debug.Log("Kamoon, kamoon beibi kamoon");
>>>>>>> c23e222c47b14dd1918404c02f1de7d2c27e7f2c
        }

        /*if (collision.gameObject.tag == "BodyPart")
        {
            if (collision.gameObject.transform.parent.tag == "P1" && gameObject.tag == "P2")
            {
                //st.points += 1;
                //st.SetScoreText();
                //st.scoreText.text = "P1: " + st.points.ToString();
                Debug.Log("P2 got poits");
                collision.gameObject.tag = "Null";
            }
            if (collision.gameObject.transform.parent.tag == "P2" && gameObject.tag == "P1")
            {
                //st.points += 1;
                //st.SetScoreText();
                //st.scoreText.text = "P2: " + st.points.ToString();
                Debug.Log("P2 got poits");
                collision.gameObject.tag = "Null";
            }
        }*/
    }
}
