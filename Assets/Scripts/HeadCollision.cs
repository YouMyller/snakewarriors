using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour {

    public GameObject spawnPosition;
    public SnakeTest st;
    public List<GameObject> bodyPartsNew = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        bodyPartsNew = new List<GameObject>(st.bodyParts);
    }
	
	// Update is called once per frame
	void Update ()
    {
        bodyPartsNew = st.bodyParts;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = spawnPosition.transform.position;
            bodyPartsNew[bodyPartsNew.Count - 1].tag = "Null";
            //
            //Debug.Log("Kamoon, kamoon beibi kamoon");
        }

        if (collision.gameObject.tag == "BodyPart")
        {
            if (collision.gameObject.transform.parent.tag == "P1" && gameObject.tag == "P2")
            {
                //st.points += 1;
                //st.SetScoreText();
                //st.scoreText.text = "P1: " + st.points.ToString();
                Debug.Log("P2 got poits");
                collision.gameObject.tag = "Null";
            }
            if (collision.gameObject.transform.parent.tag == "P2" && gameObject.tag == "P1")
            {
                //st.points += 1;
                //st.SetScoreText();
                //st.scoreText.text = "P2: " + st.points.ToString();
                Debug.Log("P2 got poits");
                collision.gameObject.tag = "Null";
            }
        }
    }
}
