﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomizer : MonoBehaviour {

    public List<GameObject> bodylist = new List<GameObject>();

    public SnakeTest st;
    public SnakeTest otherst;
    public GameObject ThisHead;
    public GameObject OtherHead;
    public GameObject Mine;
    public GameObject Bullet;
    public Image[] powerupList;
    

    string[] powerupTable = {"Speed", "Swap", "Stun", "Badfood", "Shield", "Reverse", "Mine", "Gun"};
    public string powerup;
    int number;
    int bullets = 3;
    public float timer = 0;
    Vector3 temp;
    public bool newpower = false;
    bool haspower = false;
    bool shielding = false;
    public bool timerRunning = false;
    public bool badfood = false;
    public bool reverse = false;
    public bool speeded = false;

    public AudioSource soundi;
    public AudioClip shield;
    public AudioClip speed;
    public AudioClip mineDeploy;
    public AudioClip bad;
    public AudioClip stun;
    public AudioClip invert;
    public AudioClip tp;

    Random r = new Random();

	// Use this for initialization
	void Start ()
    {
        bodylist = new List<GameObject>(st.bodyParts);
        powerup = "Null";
        ResetImages();
        powerupList[8].enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        bodylist = st.bodyParts;

        if (newpower == true)
        {
            number = Random.Range(0, powerupTable.Length);
            powerup = powerupTable[number];
            powerupList[number].enabled = true;
            powerupList[8].enabled = false;
            newpower = false;
        }

        if (shielding == true)
        {
            for (int i = bodylist.Count - 1; i > 0; i--)
            {
                GameObject shielded = bodylist[i];
                shielded.GetComponent<myDeath>().enabled = false;   //Peli ei tykkää tästä kohdasta. Heittää herjaa
                bodylist[i].gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            }
        }
        else
        {
            for (int i = bodylist.Count - 1; i > 0; i--)
            {
                GameObject shielded = bodylist[i];
                shielded.GetComponent<myDeath>().enabled = true;    //Peli ei tykkää tästä kohdasta. Heittää herjaa
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
                ResetImages();
                powerupList[8].enabled = true;
                shielding = false;
                otherst.stunned = false;
                speeded = false;
            }
        }

    }
    public void UsePower()
    {
        if (powerup == "Speed")
        {
            powerup = ("Null");
            soundi.PlayOneShot(speed);
            st.speed = 16;
            timer = 5;
            timerRunning = true;
            speeded = true;
        }
        else if (powerup == "Swap")
        {
            powerup = ("Null");
            soundi.PlayOneShot(tp);
            temp = ThisHead.transform.position;
            ThisHead.transform.position = OtherHead.transform.position;
            print(temp);
            OtherHead.transform.position = temp;
            ResetImages();
            powerupList[8].enabled = true;
        }

        else if (powerup == "Mine")
        {
            soundi.PlayOneShot(mineDeploy);
            if (st.move == 2)
            {
                Instantiate(Mine, ThisHead.transform.position + ThisHead.transform.up * bodylist.Count*1.3f, ThisHead.transform.rotation);
            }
            else if (st.move == 3)
            {
                Instantiate(Mine, ThisHead.transform.position + ThisHead.transform.right * bodylist.Count *1.3f, ThisHead.transform.rotation);
            }
            else if (st.move == 0)
            {
                Instantiate(Mine, ThisHead.transform.position - ThisHead.transform.up * bodylist.Count *1.3f, ThisHead.transform.rotation);
            }
            else
            {
                Instantiate(Mine, ThisHead.transform.position - ThisHead.transform.right * bodylist.Count* 1.3f , ThisHead.transform.rotation);
            }
            powerup = "Null";
            ResetImages();
            powerupList[8].enabled = true;
        }

        else if (powerup == "Stun")
        {
            powerup = ("Null");
            soundi.PlayOneShot(stun);
            otherst.stunned = true;
            timer = 3;
            timerRunning = true;
        }
        else if (powerup == "Badfood")
        {
            powerup = ("Null");
            soundi.PlayOneShot(bad);
            badfood = true;
            timer = 5;
            timerRunning = true;
        }
        else if (powerup == "Shield")
        {
            powerup = ("Null");
            soundi.PlayOneShot(shield);
            shielding = true;
            timer = 5;
            timerRunning = true;
        }
        else if (powerup == "Reverse")
        {
            powerup = ("Null");
            soundi.PlayOneShot(invert);
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

                ResetImages();
                powerupList[8].enabled = true;
                powerup = "Null";

        }
    }
    void ResetImages()
    {
        for (int i = powerupList.Length-1; i >= 0; i--)
        {
            powerupList[i].enabled = false;
        }
    }

}
