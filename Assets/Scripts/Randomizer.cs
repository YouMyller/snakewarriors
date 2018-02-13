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
    public GameObject Bullet;

    string[] powerupTable = {/*"Speed", "Swap", "Stun", "Badfood", "Shield", "Reverse", "Mine",*/ "Gun"};
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
                otherst.stunned = false;
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
            if (st.move == 0)
            {
                Instantiate(Mine, ThisHead.transform.position + ThisHead.transform.up * 2, ThisHead.transform.rotation);
            }
            else if (st.move == 1)
            {
                Instantiate(Mine, ThisHead.transform.position + ThisHead.transform.right * 2, ThisHead.transform.rotation);
            }
            else if (st.move == 2)
            {
                Instantiate(Mine, ThisHead.transform.position - ThisHead.transform.up * 2, ThisHead.transform.rotation);
            }
            else
            {
                Instantiate(Mine, ThisHead.transform.position - ThisHead.transform.right * 2, ThisHead.transform.rotation);
            }
            powerup = "Null";
        }

        else if (powerup == "Stun")
        {
            otherst.stunned = true;
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
        else if (powerup == "Gun")
        {
            var luoti = new GameObject();
            if (st.move == 0)
            {
                luoti = Instantiate(Bullet, ThisHead.transform.position + ThisHead.transform.up * 2, Quaternion.Euler(90, 0, 0));
                luoti.SetActive(true);
            }
            else if (st.move == 1)
            {
                luoti = Instantiate(Bullet, ThisHead.transform.position + ThisHead.transform.right * 2, Quaternion.Euler(90, 0, -90));
                luoti.SetActive(true);
            } 
            else if (st.move == 2)
            {
                luoti = Instantiate(Bullet, ThisHead.transform.position - ThisHead.transform.up * 2, Quaternion.Euler(90, 0, 180));
                luoti.SetActive(true);
            }
            else
            {
                luoti = Instantiate(Bullet, ThisHead.transform.position - ThisHead.transform.right * 2, Quaternion.Euler(90, 0, 90));
                luoti.SetActive(true);
            }
            
            
            if (luoti.transform.position == otherst.transform.position)
            {
                print("hitti");
            }
            powerup = "Null";
        }
    }

}
