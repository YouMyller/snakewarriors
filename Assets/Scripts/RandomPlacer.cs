using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : MonoBehaviour {

    public GameObject wall;
    public GameObject food;
    public GameObject powerUp;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public int wallAmount;
    public int foodAmount;
    public int powerAmount;
    public float randomXa;
    public float randomXb;
    public float randomYa;
    public float randomYb;

    // Use this for initialization
    void Start ()
    {
        createWalls();
        createFood();
        playerSpawn();
        createPower();
        
    }
	
    void createWalls()
    {
        for (int i = 0; i < wallAmount; i++)
        {
            Vector3 spawnPos = new Vector3(0, -31, 0);
            wall.transform.localScale = new Vector3(Random.Range(3, 20), 1, Random.Range(3, 20));

                float spawnPosX = Random.Range(randomXa, randomXb);
                float spawnPosY = Random.Range(randomYa, randomYb);
                spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
                GameObject seina = Instantiate(wall, spawnPos, Quaternion.identity) as GameObject;
            
        }
    }
    
        void createFood()
        {
        for (int i = 0; i < foodAmount; i++)
        {
            Vector3 spawnPos = new Vector3(0, -31, 0);
            float spawnPosX = Random.Range(randomXa, randomXb);
            float spawnPosY = Random.Range(randomYa, randomYb);
            spawnPos = new Vector3(spawnPosX, -31.2f, spawnPosY);
            GameObject ruoka = Instantiate(food, spawnPos, Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
        }
    }
    void playerSpawn()
    {
        Vector3 spawnPos = new Vector3(0, -31, 0);
        float spawnPosX = Random.Range(randomXa, randomXb);
        float spawnPosY = Random.Range(randomYa, randomYb);
        spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
        spawnPoint.transform.position = spawnPos;
        spawnPoint2.transform.position = spawnPos;

    }

    void createPower()
    {
        for (int i = 0; i < powerAmount; i++)
        {
            Vector3 spawnPos = new Vector3(0, -31, 0);
            float spawnPosX = Random.Range(randomXa, randomXb);
            float spawnPosY = Random.Range(randomYa, randomYb);
            spawnPos = new Vector3(spawnPosX, -31, spawnPosY);
            GameObject poweri = Instantiate(powerUp, spawnPos, Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
      
        }
    }

}
