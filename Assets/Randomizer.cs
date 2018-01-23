using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour {

    string[] powerupTable = {"Power1", "Power2", "Power3", "Power4" };
    string powerup = "none";
    int number;
    bool haspower = false;
    Random r = new Random();

	// Use this for initialization
	void Start ()
    {
        number = Random.Range(1, powerupTable.Length+1);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
