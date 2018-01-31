using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour {

    public List<GameObject> bodylist = new List<GameObject>();

    public SnakeTest st;
    public SnakeTest other;
    public GameObject P1;
    public GameObject P2;

    string[] powerupTable = {/*"Speed", "Swap", "Stun", "Badfood", "Shield",*/ "Reverse"};
    string powerup = "none";
    int number;
    public float timer = 0;
    Vector3 temp;
    public bool newpower = false;
    bool haspower = false;
    public bool timerRunning = false;
    public bool badfood = false;
    public bool reverse = false;

    Random r = new Random();

	// Use this for initialization
	void Start ()
    {
        bodylist = new List<GameObject>(st.bodyParts);
    }
	
	// Update is called once per frame
	void Update ()
    {
        bodylist = st.bodyParts;

        if (newpower == true)
        {
            number = Random.Range(0, powerupTable.Length);
            powerup = powerupTable[number];
            print(powerup);
            newpower = false;
        }
        if (powerup == "Speed")
        {
            st.speed = 16;
            if (timerRunning == false)
            {
                timer = 5;
                timerRunning = true;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    st.speed = 8;
                    timerRunning = false;
                    powerup = ("null");
                }
            }



        }
        else if (powerup == "Swap")
        {
            temp = P1.transform.position;
            P1.transform.position = P2.transform.position;
            P2.transform.position = temp;
            powerup = "Null";
        }

        else if (powerup == "Stun")
        {
            other.speed = 0;
            if (timerRunning == false)
            {
                timer = 3;
                timerRunning = true;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timerRunning = false;
                    other.speed = 8;
                    powerup = ("null");
                }
            }
        }
        else if (powerup == "Badfood")
        {
            badfood = true;
            if (timerRunning == false)
            {
                timer = 5;
                timerRunning = true;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timerRunning = false;
                    badfood = false;
                    powerup = ("null");
                }
            }
        }
        else if (powerup == "Shield")
        {
            for (int i = bodylist.Count - 1; i > 0; i--)
            {
                GameObject shielded = bodylist[i];
                shielded.GetComponent<myDeath>().enabled = false;
                bodylist[i].gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (timerRunning == false)
            {

                timer = 5;
                timerRunning = true;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timerRunning = false;
                    for (int i = bodylist.Count - 1; i > 0; i--)
                    {
                        GameObject shielded = bodylist[i];
                        shielded.GetComponent<myDeath>().enabled = true;
                        bodylist[i].gameObject.GetComponent<Renderer>().material.color = Color.white;
                    }
                    powerup = ("null");
                }
            }
        }
        else if (powerup == "Reverse")
        {
            reverse = true;
            if (timerRunning == false)
            {
                timer = 5;
                timerRunning = true;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timerRunning = false;
                    reverse = false;
                    powerup = ("null");
                }
            }
        }
    }
}
