using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatingFood : MonoBehaviour {

    public SnakeTest st;

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
        if (collision.gameObject.tag == "SpeedFruit")
        {
            if (st.speed == st.normalValue)
            {
                st.speed = st.xtraSpeed;
            }
            else if (st.speed == st.xtraSpeed)
            {
                st.speed = st.xtraSpeed2;
            }
            else if (st.speed == st.xtraSpeed2)
            {
                st.speed = st.xtraSpeed3;
            }
            else if (st.speed == st.xtraSpeed3)
            {
                st.speed = st.xtraSpeed3;
            }
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
            if (gameObject.tag == "P1")
            {
                end1.SetActive(true);
            }
            if (gameObject.tag == "P2")
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
