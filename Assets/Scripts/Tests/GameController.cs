using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject snakePrefab;

    public Snake head;
    public Snake tail;
     
    public int dir;

    public Vector2 nextPos;

    public float speed = 5;

    public int maxSize;
    public int currentSize;

    public int xBound;
    public int yBound;

    public GameObject foodPrefab;
    public GameObject currentFood;

    public Vector2 moveVelocity;

	// Use this for initialization
	void Start ()
    {
        //Invokes a method in specified seconds, then repeatedly every specified seconds.
        InvokeRepeating("TimerInvoke", 0, .5f);
        //FoodFunction();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeDir();
        moveVelocity = nextPos * speed;
        //Movement();
	}

    void TimerInvoke()
    {
        Movement();

        if (currentSize >= maxSize)
        {
            TailFunction();
        }
        else
        {
            currentSize++;
        }
    }

    //Change movement into something smooth - I could use the movement from MA as a guideline
    void Movement()
    {
        GameObject temp;
        nextPos = head.transform.position;

        switch (dir)
        {
            case 0:
                nextPos = new Vector2(nextPos.x, nextPos.y + 1);
                break;

            case 1:
                nextPos = new Vector2(nextPos.x + 1, nextPos.y);
                break;

            case 2:
                nextPos = new Vector2(nextPos.x, nextPos.y - 1);
                break;

            case 3:
                nextPos = new Vector2(nextPos.x - 1, nextPos.y);
                break;
        }

        //"Duplicate" an object and specify its position and rotation.
        temp = Instantiate(snakePrefab, nextPos, transform.rotation);   //(GameObject)

        head.SetNext(temp.GetComponent<Snake>());
        head = temp.GetComponent<Snake>();

        return;
    }

    void ChangeDir()
    {
        if (dir != 2 && Input.GetKeyDown(KeyCode.W))
        {
            dir = 0;
        }
        if (dir != 3 && Input.GetKeyDown(KeyCode.D))
        {

            dir = 1;
        }
        if (dir != 0 && Input.GetKeyDown(KeyCode.S))
        {
            dir = 2;
        }
        if (dir != 1 && Input.GetKeyDown(KeyCode.A))
        {
            dir = 3;
        }
    }

    void TailFunction()
    {
        Snake tempSnake = tail;
        tail = tail.GetNext();
        tempSnake.RemoveTail();
    }

    /*void FoodFunction()
    {
        int xPos = Random.Range(-xBound, xBound);
        int yPos = Random.Range(-yBound, yBound);

        currentFood = Instantiate(foodPrefab, new Vector2(xPos, yPos), transform.rotation);
        StartCoroutine(CheckRender(currentFood));
    }*/

    /*IEnumerator CheckRender(GameObject IN)
    {
        yield return new WaitForEndOfFrame();
        
        if (IN.GetComponent<Renderer>().isVisible == false)
        {
            if (IN.tag == "Food")
            {
                Destroy(IN);
                FoodFunction();
            }
        }
    }*/
}
