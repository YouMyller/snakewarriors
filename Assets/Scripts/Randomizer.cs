using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour {

    public List<GameObject> bodylist = new List<GameObject>();

    public SnakeTest st;
    public SnakeTest otherst;
    public GameObject ThisHead;
    public GameObject OtherHead;
    public GameObject Mine;

    string[] powerupTable = {"Speed", "Swap", "Stun", "Badfood", "Shield", "Reverse", "Mine"};
    public string powerup;
    int number;
    public float timer = 0;
    Vector3 temp;
    public bool newpower = false;
    bool haspower = false;
    bool shielding = false;
    public bool timerRunning = false;
    public bool badfood = false;
    public bool reverse = false;

    Random r = new Random();

	// Use this for initialization
	void Start ()
    {
        bodylist = new List<GameObject>(st.bodyParts);
        powerup = "Null";
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

        if (shielding == true)
        {
            for (int i = bodylist.Count - 1; i > 0; i--)
            {
                GameObject shielded = bodylist[i];
                shielded.GetComponent<myDeath>().enabled = false;
                bodylist[i].gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            }
        }
        else
        {
            for (int i = bodylist.Count - 1; i > 0; i--)
            {
                GameObject shielded = bodylist[i];
                shielded.GetComponent<myDeath>().enabled = true;
                bodylist[i].gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        if (timerRunning == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timerRunning = false;
                reverse = false;
                badfood = false;
                powerup = ("Null");
                shielding = false;
                st.speed = 8;
                otherst.speed = 8;
            }
        }

    }
    public void UsePower()
    {
        if (powerup == "Speed")
        {
            st.speed = 16;
            timer = 5;
            timerRunning = true;
        }
        else if (powerup == "Swap")
        {
            temp = ThisHead.transform.position;
            ThisHead.transform.position = OtherHead.transform.position;
            print(temp);
            OtherHead.transform.position = temp;
            powerup = "Null";
        }

        else if (powerup == "Mine")
        {
            Instantiate(Mine, ThisHead.transform.position - ThisHead.transform.right * 2, ThisHead.transform.rotation);
            powerup = "Null";
        }

        else if (powerup == "Stun")
        {
            otherst.speed = 0;
            timer = 3;
            timerRunning = true;
        }
        else if (powerup == "Badfood")
        {
            badfood = true;
            timer = 5;
            timerRunning = true;
        }
        else if (powerup == "Shield")
        {
            shielding = true;
            timer = 5;
            timerRunning = true;
        }
        else if (powerup == "Reverse")
        {
            reverse = true;
            timer = 5;
            timerRunning = true;
        }
    }

}
