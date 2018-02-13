using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour {

    public GameObject wall;
    public GameObject food;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public Vector3 radius;
    public Collider[] colliders;
    public int wallAmount;
    public int foodAmount;

    // Use this for initialization
    void Start ()
    {
        createWalls();
        createFood();
        playerSpawn();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
            
}

    void createWalls()
    {
        for (int i = 0; i < wallAmount; i++)
        {
            Vector3 spawnPos = new Vector3(0, -31, 0);
            bool canSpawnHere = false;
            wall.transform.localScale = new Vector3(Random.Range(3, 25), 1, Random.Range(3, 25));


            while (!canSpawnHere)
            {

                float spawnPosX = Random.Range(-43.5f, 45.5f);
                float spawnPosY = Random.Range(-30.5f, 120.5f);
                spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
                canSpawnHere = preventSpawnOverlap(spawnPos);

            }

            GameObject seina = Instantiate(wall, spawnPos, Quaternion.identity) as GameObject;
        }
    }

        void createFood()
        {
        for (int i = 0; i < foodAmount; i++)
        {
            Vector3 spawnPos = new Vector3(0, -31, 0);
            bool canSpawnHere = false;

            while (!canSpawnHere)
            {

                float spawnPosX = Random.Range(-43.5f, 45.5f);
                float spawnPosY = Random.Range(-30.5f, 120.5f);
                spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
                canSpawnHere = preventSpawnOverlap(spawnPos);


            }

            GameObject ruoka = Instantiate(food, spawnPos, Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
        }
    }
    void playerSpawn()
    {
        Vector3 spawnPos = new Vector3(0, -31, 0);
        bool canSpawnHere = false;


        while (!canSpawnHere)
        {

            float spawnPosX = Random.Range(-43.5f, 45.5f);
            float spawnPosY = Random.Range(-30.5f, 120.5f);
            spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
            canSpawnHere = preventSpawnOverlap(spawnPos);
        }
        spawnPoint.transform.position = spawnPos;
        spawnPoint2.transform.position = spawnPos;

    }

    bool preventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics.OverlapBox(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x +15;
            float height = colliders[i].bounds.extents.z +5;

            float leftextent = centerPoint.x - width;
            float rightextent = centerPoint.x + width;
            float upperextent = centerPoint.y + height;
            float lowerextent = centerPoint.y - height;

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
