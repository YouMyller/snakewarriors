using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour {

    public GameObject wall;
    public GameObject food;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
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
            wall.transform.localScale = new Vector3(Random.Range(3, 10), 1, Random.Range(3, 10));

                float spawnPosX = Random.Range(-43.5f, 45.5f);
                float spawnPosY = Random.Range(-30.5f, 120.5f);
                spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
                GameObject seina = Instantiate(wall, spawnPos, Quaternion.AngleAxis (90, Vector3.left)) as GameObject;
            
        }
    }
    
        void createFood()
        {
        for (int i = 0; i < foodAmount; i++)
        {
            Vector3 spawnPos = new Vector3(0, -31, 0);
                float spawnPosX = Random.Range(-43.5f, 45.5f);
                float spawnPosY = Random.Range(-30.5f, 120.5f);
                spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
            GameObject ruoka = Instantiate(food, spawnPos, Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
        }
    }
    void playerSpawn()
    {
        Vector3 spawnPos = new Vector3(0, -31, 0);
            float spawnPosX = Random.Range(-43.5f, 45.5f);
            float spawnPosY = Random.Range(-30.5f, 120.5f);
            spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
        spawnPoint.transform.position = spawnPos;
        spawnPoint2.transform.position = spawnPos;

    }



}
