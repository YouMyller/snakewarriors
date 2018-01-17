using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppedDead : MonoBehaviour {

    public Rigidbody rb;


    private void Start()
    {
        Rigidbody rb = new Rigidbody();    
    }

    private void Update()
    {
        if (rb.velocity.magnitude == 0.0f && transform.parent.tag != "Keeper")
        {
            Destroy(gameObject);
        }
    }

    /*private Transform _myTransform;
    private Vector3 _lastPosition;

    private float wait = 2f;

    private void Start()
    {

    }

    private void Update()
    {
        wait -= Time.deltaTime;

        if (wait <= 0)
        { 
            _myTransform = transform;
            _lastPosition = _myTransform.position;
        }

        if (_lastPosition == _myTransform.position)
        {
            Destroy(gameObject);
        }
        _lastPosition = _myTransform.position;
    }


    /*Vector3 lastPosition;
    Transform myTransform;
    bool isMoving;

    private void Start()
    {
        myTransform = transform;
        lastPosition = myTransform.position;
        isMoving = false;
    }

    private void Update()
    {
        if (myTransform.position != lastPosition)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = myTransform.position;
    }*/
}
