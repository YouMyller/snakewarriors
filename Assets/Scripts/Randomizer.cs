using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour {

    public SnakeTest st;
    public SnakeTest other;
    public GameObject P1;
    public GameObject P2;

    string[] powerupTable = {"Speed", "Swap", "Stun", "Power4"};
    string powerup = "none";
    int number;
    public float timer = 0;
    Vector3 temp;
    public bool newpower = false;
    bool haspower = false;
    public bool timerRunning = false;
    Random r = new Random();

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
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

    }
}
