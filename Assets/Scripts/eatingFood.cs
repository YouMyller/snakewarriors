using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatingFood : MonoBehaviour {

    public SnakeTest st;
    public Randomizer random;

    public SnakeTest player1;
    public SnakeTest player2;

    private bool slowed = false;

    public GameObject end1;
    public GameObject end2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            st.growTwo = true;
        }

        if (collision.gameObject.CompareTag("SuperFood"))
        {
            st.growFive = true;
        }

        if (collision.gameObject.tag == "Powerup")
        {
            random.newpower = true;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Grass" && slowed == false)
        {
            st.speed = st.speed / 4;
            slowed = true;
        }
        if (collision.gameObject.tag == "Finale")
        {
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

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grass" && slowed == true)
        {
            st.speed = st.speed * 4;
            slowed = false;
        }
    }
}
