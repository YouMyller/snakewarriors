using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20;
    public float destTime = 2;

    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        Rigidbody rb = new Rigidbody();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.up * speed * Time.smoothDeltaTime);
        //transform.Translate(Vector2.up * speed);

        destTime -= Time.deltaTime;

        if (destTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BodyPart"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Food" || collision.gameObject.tag == "SuperFood" || collision.gameObject.tag == "Powerup")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

    }
}
