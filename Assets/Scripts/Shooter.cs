using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float shootingTime = 1;
    public Bullet bullet;
    public Transform bulletSpawner;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        shootingTime -= Time.deltaTime;

        if (shootingTime <= 0)
        {
            Bullet newBullet = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation) as Bullet;
            shootingTime = 1;
        }
	}
}
