using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMov : MonoBehaviour {

    int dir;

    public float moveSpeed = .5f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (dir != 2 && Input.GetKeyDown(KeyCode.W))
        {
            dir = 0;
        }
        else if (dir != 3 && Input.GetKeyDown(KeyCode.D))
        {
            dir = 1;
        }
        else if (dir != 0 && Input.GetKeyDown(KeyCode.S))
        {
            dir = 2;
        }
        else if (dir != 1 && Input.GetKeyDown(KeyCode.A))
        {
            dir = 3;
        }

        Movement();
    }

    void Movement()
    {
        if (dir == 0)
        {
            transform.Translate(Vector2.up * moveSpeed);
        }
        if (dir == 1)
        {
            transform.Translate(Vector2.right * moveSpeed);
        }
        if (dir == 2)
        {
            transform.Translate(Vector2.down * moveSpeed);
        }
        if (dir == 3)
        {
            transform.Translate(Vector2.left * moveSpeed);
        }

        /*float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);*/
    }
}
