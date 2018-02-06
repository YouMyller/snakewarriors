using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour {

    public GameObject wall;
    public Vector3 radius;
    public Collider[] colliders;


    // Use this for initialization
    void Start ()
    {
        Vector3 spawnPos = new Vector3(0,-32,0);
        bool canSpawnHere = false;
        int safetyNet = 0;

        wall.transform.localScale = new Vector3(Random.Range(3, 25), 2, Random.Range(3, 25));


        while (!canSpawnHere)
        {

            float spawnPosX = Random.Range(-43.5f, 45.5f);
            float spawnPosY = Random.Range(-30.5f, 120.5f);
            spawnPos = new Vector3(spawnPosX, -32, spawnPosY);
            canSpawnHere = preventSpawnOverlap(spawnPos);

            safetyNet++;
            if (safetyNet > 10)
            {
 
                Debug.Log("Too many attempts");
                break;

            }

        }
        GameObject seina = Instantiate(wall, spawnPos, Quaternion.identity) as GameObject;

    }
	
	// Update is called once per frame
	void Update ()
    {
        
            
}

    bool preventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics.OverlapBox(wall.transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.z;

            float leftextent = centerPoint.x - width;
            float rightextent = centerPoint.x + width;
            float upperextent = centerPoint.y + height;
            float lowerextent = centerPoint.y + height;

            if (spawnPos.x >= leftextent && spawnPos.x <= rightextent)
            {
                if (spawnPos.y >= lowerextent && spawnPos.y <= upperextent)
                {
                    return false;
                }

            }
            
        }
        return true;

    }
    

}
