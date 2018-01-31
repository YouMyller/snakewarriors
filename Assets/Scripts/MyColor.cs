using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColor : MonoBehaviour {

    public GameObject headOne;
    public GameObject headTwo;
    private HeadCollision headCol;

    Color32 white = new Color32(255, 255, 255, 255);
    Color color;

    // Use this for initialization
    void Start()
    {
        MyColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Renderer>().material.color == white)
        {
            MyColorChange();
        }
    }

    public void MyColorChange()
    {
        if (transform.parent.tag == "P1")
        {
            headCol = headOne.GetComponent<HeadCollision>();
            gameObject.GetComponent<Renderer>().material.color = headCol.gameObject.GetComponent<Renderer>().material.color;

            color = gameObject.GetComponent<Renderer>().material.color;
            //color.g = .7f;        Tried to make the other parts a slightly different color, left this unfinished
            //color.b = .7f;
        }
        if (transform.parent.tag == "P2")
        {
            headCol = headTwo.GetComponent<HeadCollision>();
            gameObject.GetComponent<Renderer>().material.color = headCol.gameObject.GetComponent<Renderer>().material.color;

            color = gameObject.GetComponent<Renderer>().material.color;
            //color.g = 255;        Tried to make the other parts a slightly different color, left this unfinished
            //color.b = 255;
        }
    }
}
