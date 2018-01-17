using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour {

    public GameObject spawnPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = spawnPosition.transform.position;
            //Debug.Log("Kamoon, kamoon beibi kamoon");
        }

        if (collision.gameObject.tag == "BodyPart")
        {
            if (collision.gameObject.transform.parent.tag == "P1" && gameObject.tag == "P2")
            {
                collision.gameObject.tag = "Null";
            }
            if (collision.gameObject.transform.parent.tag == "P2" && gameObject.tag == "P1")
            {
                collision.gameObject.tag = "Null";
            }
        }
    }
}
