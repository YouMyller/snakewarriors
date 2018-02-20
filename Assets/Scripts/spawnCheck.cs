using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCheck : MonoBehaviour {

    public GameObject spawnedObject;
    public Vector3 radius;
    public Collider[] colliders;

    // Use this for initialization
    void Start ()
    {
        createWalls();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void createWalls()
    {
            Vector3 spawnPos = new Vector3(0, -31, 0);
            bool canSpawnHere = false;

        int safetynet = 0;

            while (canSpawnHere == false)
            {
            spawnedObject.transform.localScale = new Vector3(Random.Range(3, 25), 1, Random.Range(3, 25));
            float spawnPosX = Random.Range(-43.5f, 45.5f);
                float spawnPosY = Random.Range(-30.5f, 120.5f);
                spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
                canSpawnHere = preventSpawnOverlap(spawnPos);
            spawnedObject.transform.position = spawnPos;
            safetynet ++;
            if (safetynet > 500)
            {
                Debug.Log("too many attempts");
                break;
            }

            }



    }
    

    bool preventSpawnOverlap(Vector3 spawnPos)
    {

        radius = spawnedObject.transform.localScale;
        colliders = Physics.OverlapBox(spawnedObject.transform.position, radius);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.z;

            float leftextent = centerPoint.x - width;
            float rightextent = centerPoint.x + width;
            float upperextent = centerPoint.z + height;
            float lowerextent = centerPoint.z - height;


        }
        
        if (colliders.Length > 1)
        {
            
            return false;
        }

            return true;


    }

}
