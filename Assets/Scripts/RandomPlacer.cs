using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour {

    public GameObject wall;
    public SnakeTest pelaaja1;
    public SnakeTest pelaaja2;


    // Use this for initialization
    void Start ()
    {
        wall.transform.localScale = new Vector3(Random.Range(5, 25), 2, Random.Range(5, 25));
        wall.transform.position = new Vector3(Random.Range(-43, 45), -32, Random.Range(-30, 120));
        

        //while (wall.transform.position = new Vector3(Range(20,25), RangeInt(20, 25), RangeInt(20, 25)))
        {
            wall.transform.position = new Vector3(Random.Range(-43, 45), -32, Random.Range(-30, 120));

        }
    }
	
	// Update is called once per frame
	void Update ()
    {


}


}
