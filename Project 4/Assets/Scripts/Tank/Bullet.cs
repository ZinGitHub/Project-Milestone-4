using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The variable tf will hold the data on the transform component
    public Transform tf;
    // Retrieve shooter data from TankData.cs script/TankData class
    public TankData shooter;
    // Float variable for the speed of the bullet
    // Can be editted by the designer
    public float speed = 10.0f;
    // Float variable for the amount of damage the bullet represents
    // Can be editted by the designer
    public float damage = 1.0f;
    // Float variable for how long the bullet will stay until it despawns
    // Can be editted by the designer
    public float timeOut = 1.0f;

    // Initialize the variables and game state
    void Awake()
    {
        // Get the component transform (position, rotation, and scale)
        // the variable tf will hold the data on the transform component
        tf = GetComponent<Transform>();
        // Destroy the bullet once the timer (timeOut) variable has counted to zero
        Destroy(gameObject, timeOut);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the position of the bullet according to the location of the turrent
        tf.position += tf.forward * speed * Time.deltaTime;
    }

    // Function for when the bullet collides with another object
    // Collide.isTrigger enabled
    void OnTriggerEnter(Collider other)
    {
        // Destroy the bullet object when colliding
        Destroy(gameObject);

        // Retrieve data from the TankData class and get its component
        TankData healthData = other.GetComponent<TankData>();
        // An if statement for if when the tank's health is not equl to null 

        if(healthData != null)
        {
            // The tank will take damage according the TakeDamage function from TankHealth class
            healthData.health.TakeDamage(damage, shooter);
        }
    }

   

}
