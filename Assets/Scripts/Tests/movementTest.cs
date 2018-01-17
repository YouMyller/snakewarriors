using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour {

    public float moveSpeed = .4f;
    public float rotationSpeed = 50;

    //private Vector3 moveVelocity;

    //public Rigidbody myRigidBody;

    public int dir = 0;

    public List<Transform> BodyParts = new List<Transform>();

    public float minDistance = 0.25f;

    public int beginSize;

    public GameObject bodyPrefab;

    private float dist;

    private Transform curBodyPart;
    private Transform prevBodyPart; 

    // Use this for initialization
    void Start()
    {
        //myRigidBody = GetComponent<Rigidbody>();

        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }
    }

    // Update is called once per frame
    void Update ()
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

        if (Input.GetKey(KeyCode.Q))
        {
            AddBodyPart();
        }
    }

    public void Movement()
    {
        float curSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            curSpeed *= 2;
        }

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

        BodyParts[0].Translate(BodyParts[0].forward * curSpeed * Time.smoothDeltaTime, Space.World);

        /*if (Input.GetAxis("Horizontal") != 0)   //This probably won't work for what I'm trying to make
        {
            BodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }*/

        for (int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            dist = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newPos = prevBodyPart.position;

            newPos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * dist / minDistance * curSpeed;

            if (T > .5f)
            {
                T = .5f;
            }

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }
    }

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count -1].position, BodyParts[BodyParts.Count -1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        BodyParts.Add(newpart);
    }
}
