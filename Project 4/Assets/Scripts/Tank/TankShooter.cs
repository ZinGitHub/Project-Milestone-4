using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    // Create a transform class for firePoint
    public Transform firePoint;
    // Float variable for lastFireTime
    private float lastFireTime;
    // Public field TankData contained in data
    private TankData data;


    // Start is called before the first frame update
    void Start()
    {
        // The variable data will contain the component TankData
        data = GetComponent<TankData>();

        // The variable lastFireTime will be calculated with Time.time which will give the amount of time
        lastFireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function for Shoot
    // Parameter = GameObject bulletPrefab
    public void Shoot(GameObject bulletPrefab)
    {
        // An if statement for when the time amount is greater than the lastFireTime plus the cooldown timer
        if (Time.time > lastFireTime + data.fireCooldown)
        {
            // Instantiate the bulletPrefab creating clones of bullets that can be shot once cooldown is over
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            // Get the bullet data from the Bullet Component/class
            Bullet bulletData = bullet.GetComponent<Bullet>();

            // an if statement that will be executed when the bullet data does not equal null
            if (bulletData != null)
            {
                // bullet.data,shooter set to the data variable which is connected to TankData
                bulletData.shooter = data;
            }

            // The variable lastFireTime will be calculated with Time.time which will give the amount of time
            lastFireTime = Time.time;
        }
    }
}
