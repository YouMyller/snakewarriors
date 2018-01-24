using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour {

    public SnakeTest st;
    public SnakeTest other;

    string[] powerupTable = {"Speed", "Swap", "Power3", "Power4" };
    string powerup = "none";
    int number;
    Vector3 P1loc;
    Vector3 P2loc;
    public bool newpower = false;
    bool haspower = false;
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
            if (st.speed == st.normalValue)
            {
                st.speed = st.xtraSpeed;
                powerup = "null";
            }
            else if (st.speed == st.xtraSpeed)
            {
                st.speed = st.xtraSpeed2;
                powerup = "null";
            }
            else if (st.speed == st.xtraSpeed2)
            {
                st.speed = st.xtraSpeed3;
                powerup = "null";
            }
            else if (st.speed == st.xtraSpeed3)
            {
                st.speed = st.xtraSpeed3;
                powerup = "null";
            }
        }
        else if (powerup == "Swap")
        {
            P1loc = st.transform.position;
            P2loc = other.transform.position;
            st.transform.position = P2loc;
            other.transform.position = P1loc;
            powerup = "Null";
        }

    }
}
