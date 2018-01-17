using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeTest : MonoBehaviour {

    public List<GameObject> bodyParts = new List<GameObject>(); //public List<Transform> bodyParts = new List<Transform>();

    public float minDistance = .25f;
    public float speed = 1;
    public float rotationSpeed = 50;

    public int beginSize;

    public GameObject bodyPrefab;

    private float dist;
    private Transform prevBodyPart;
    private Transform curBodyPart;

    private int dir;

    public bool growTwo = false;
    public bool growFive = false;

    public int points;

    public Text scoreText;

    public Rigidbody rb;

    private int move = 0;

    public float creationTimer = 1f;

    public float xtraSpeed = 16;
    public float xtraSpeed2 = 24;
    public float xtraSpeed3 = 32;
    public float normalValue;

    public float noSrslyFuku = 0;

    // Use this for initialization
    void Start ()
    {
        points = 0;
        SetScoreText();

        AddBodyPart();
        AddBodyPart();
        AddBodyPart();
        AddBodyPart();
        AddBodyPart();

        Rigidbody rb = new Rigidbody(); //The head's Rigidbody

        normalValue = speed;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Movement();

        creationTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        MissingParts();

        //For debug purposes:
//        if (bodyParts.Count >= 6)
  //      {
            if (Input.GetKeyDown(KeyCode.Q))
            {
            //AddBodyPart();
                noSrslyFuku = 1;
                noSrslyFuku -= Time.deltaTime;
                if (noSrslyFuku <= 0)
                {
                    if (gameObject.tag == "P2" && gameObject.activeInHierarchy == true)
                    {
                        gameObject.SetActive(false);
                    }
                    if (gameObject.tag == "P2" && gameObject.activeInHierarchy == false)
                    {
                        gameObject.SetActive(true);
                    //noSrslyFuku = 1;
                    //noSrslyFuku -= Time.deltaTime;
                    }
                }
            }
    //    }

        /*if (bodyParts.Count >= 4)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                //AddBodyPart();
                bodyParts.Remove(bodyParts[3]);
            }
        }

        if (bodyParts.Count >= 6)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                //AddBodyPart();
                bodyParts.Remove(bodyParts[5]);
            }
        }*/

        if (growTwo == true)
        {
            AddBodyPart();
            AddBodyPart();
            growTwo = false;
        }

        if (growFive == true)
        {
            AddBodyPart();
            AddBodyPart();
            AddBodyPart();
            AddBodyPart();
            AddBodyPart();
            growFive = false;
        }
    }

    public void Movement()
    {
        float curSpeed = speed;

        var dir = bodyParts[0].transform;

        //rb.MovePosition(bodyParts[0].transform.position + dir.up * curSpeed * Time.smoothDeltaTime);
        //rb.MovePosition(bodyParts[0].transform.position + bodyParts[0].up * curSpeed * Time.smoothDeltaTime);   //This one didn't work; one too many things inside the brackets , Space.World
        //bodyParts[0].transform.Translate(bodyParts[0].transform.up * curSpeed * Time.smoothDeltaTime, Space.World);
        //bodyParts[0].Translate(bodyParts[0].up * curSpeed * Time.smoothDeltaTime, Space.World);

        if (gameObject.tag == "P1")
        {
            if (Input.GetKey(KeyCode.W) && move != 2)
            {
                move = 0;
            }

            else if (Input.GetKey(KeyCode.D) && move != 3)
            {
                move = 1;
            }

            else if (Input.GetKey(KeyCode.S) && move != 0)
            {
                move = 2;
            }

            else if (Input.GetKey(KeyCode.A) && move != 1)
            {
                move = 3;
            }
        }

        if (gameObject.tag == "P2")
        {
            if (Input.GetKey(KeyCode.UpArrow) && move != 2)
            {
                move = 0;
            }

            else if (Input.GetKey(KeyCode.RightArrow) && move != 3)
            {
                move = 1;
            }

            else if (Input.GetKey(KeyCode.DownArrow) && move != 0)
            {
                move = 2;
            }

            else if (Input.GetKey(KeyCode.LeftArrow) && move != 1)
            {
                move = 3;
            }
        }

        if (move == 0)
        {
            rb.MovePosition(bodyParts[0].transform.position + dir.up * curSpeed * Time.smoothDeltaTime);
            //rb.angularVelocity = new Vector3(90, 0, 0);
            //bodyParts[0].transform.localEulerAngles = new Vector3(90, 0, 0);
            //bodyParts[0].localEulerAngles = new Vector3(90, 0, 0);
        }
        else if (move == 1)
        {
            rb.MovePosition(bodyParts[0].transform.position + dir.right * curSpeed * Time.smoothDeltaTime);
            //rb.angularVelocity = new Vector3(90, 90, 0);
            //bodyParts[0].transform.localEulerAngles = new Vector3(90, 90, 0);
            //bodyParts[0].localEulerAngles = new Vector3(90, 90, 0);
        }
        else if (move == 2)
        {
            rb.MovePosition(bodyParts[0].transform.position - dir.up * curSpeed * Time.smoothDeltaTime);
            //rb.angularVelocity = new Vector3(90, 180, 0);
            //bodyParts[0].transform.localEulerAngles = new Vector3(90, 180, 0);
            //bodyParts[0].localEulerAngles = new Vector3(90, 180, 0);
        }
        else if (move == 3)
        {
            rb.MovePosition(bodyParts[0].transform.position - dir.right * curSpeed * Time.smoothDeltaTime);
            //rb.angularVelocity = new Vector3(90, -90, 0);
            //bodyParts[0].transform.localEulerAngles = new Vector3(90, -90, 0);
            //bodyParts[0].localEulerAngles = new Vector3(90, -90, 0);
        }

        for (int i = 1; i < bodyParts.Count; i++)
        {
            curBodyPart = bodyParts[i].transform;   
            //curBodyPart = bodyParts[i]
            prevBodyPart = bodyParts[i - 1].transform;    
            //prevBodyPart = bodyParts[i - 1];

            dist = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newPos = prevBodyPart.position;

            newPos.y = bodyParts[0].transform.position.y;     
            //newPos.y = bodyParts[0].position.y;

            float T = Time.deltaTime * dist / minDistance * curSpeed;

            if (T > .5f)
            {
                T = .5f;
            }

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }
        //MissingParts();
    }

    public void AddBodyPart()
    {
        GameObject newPart = Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].transform.position, bodyParts[bodyParts.Count - 1].transform.rotation);
        //Transform newPart = (Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;

        newPart.transform.SetParent(transform);
        //newPart.SetParent(transform);

        bodyParts.Add(newPart);

        if (creationTimer <= 0)
        //if (bodyParts.Count >= 7)
        {
            points += 1;
            SetScoreText();
        }
    }

    public void SetScoreText()
    {

        if (gameObject.tag == "P1")
        {
            scoreText.text = "P1: " + points.ToString();
        }

        if (gameObject.tag == "P2")
        {
            scoreText.text = "P2: " + points.ToString();
        }
    }

    public void MissingParts()
    {
        if (bodyParts.Count >= 2)
        {
            if (bodyParts[1].tag == "Null")
            {
                bodyParts.Remove(bodyParts[1]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }

        if (bodyParts.Count >= 3)
        {
            if (bodyParts[2].tag == "Null")
            {
                bodyParts.Remove(bodyParts[2]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }

        if (bodyParts.Count >= 4)
        {
            if (bodyParts[3].tag == "Null")
            {
                bodyParts.Remove(bodyParts[3]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }

        if (bodyParts.Count >= 5)
        {
            if (bodyParts[4].tag == "Null")
            {
                bodyParts.Remove(bodyParts[4]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }

        if (bodyParts.Count >= 6)
        {
            if (bodyParts[5].tag == "Null")
            {
                bodyParts.Remove(bodyParts[5]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }

        if (bodyParts.Count >= 7)
        {
            if (bodyParts[6].tag == "Null")
            {
                bodyParts.Remove(bodyParts[6]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }

        if (bodyParts.Count >= 8)
        {
            if (bodyParts[7].tag == "Null")
            {
                bodyParts.Remove(bodyParts[7]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }

        if (bodyParts.Count >= 9)
        {
            if (bodyParts[8].tag == "Null")
            {
                bodyParts.Remove(bodyParts[8]);
                if (points > 0)
                {
                    points -= 1;
                    SetScoreText();
                }
                //Destroy(bodyParts[1]);
            }
        }
    }
}
