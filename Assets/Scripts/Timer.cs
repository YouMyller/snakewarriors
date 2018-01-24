using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float myTimer= 99;
    public Text timerText;


    public SnakeTest player1;
    public SnakeTest player2;

    public GameObject end1;
    public GameObject end2;

    // Use this for initialization
    void Start () {
        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        myTimer -= Time.deltaTime;
        timerText.text = myTimer.ToString("f0");
        print (myTimer);
        if (myTimer < 0)
        {
            myTimer = Time.deltaTime;
            if (player1.points > player2.points)
            {
                end1.SetActive(true);
            }
            if (player2.points > player1.points)
            {
                end2.SetActive(true);
            }
        }
	}

}
