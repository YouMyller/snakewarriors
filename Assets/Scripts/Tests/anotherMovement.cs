using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anotherMovement : MonoBehaviour {

    public float moveSpeed = 5;

    private Vector2 move;
    public Vector2 moveVelocity;

    public Rigidbody myRigidBody;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveVelocity = move * moveSpeed;
        myRigidBody.velocity = moveVelocity;

        if (Input.GetKeyDown(KeyCode.W))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
        }
    }

    void MoveUpDown()
    {
        move = new Vector2(move.x, Input.GetAxisRaw("Vertical"));
    }

    void MoveRightLeft()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), move.y);
    }

    void MoveFourDirections()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = move * moveSpeed;
    }
}
