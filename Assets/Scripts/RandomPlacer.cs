using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour {

    public GameObject wall;

	// Use this for initialization
	void Start ()
    {
        wall.transform.position = new Vector3(Random.Range(-43,45),-32, Random.Range(-30, 120));
        print(transform.position.x);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
