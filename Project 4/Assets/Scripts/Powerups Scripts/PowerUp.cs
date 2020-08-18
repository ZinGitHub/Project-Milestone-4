using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Float variable storing the multiplier
    public float multiplier = 2f;
    // GameObject component variable that will attach to the health pickup
    public GameObject pickUpEffect;

    // OnTriggerEnter method used for when another object with a tag player or enemy interacts with the trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the object collider has a tag with Player then execute PickUp function
        if (other.CompareTag("Player"))
        {
            // PickUp function recall
            PickUp(other);
        }

        // If the object collider has a tag with Enemy then execute PickUp function
        if(other.CompareTag("Enemy"))
        {
            // PickUp function recall
            PickUp(other);
        }
    }

    // PickUp function definition
    void PickUp(Collider player)
    {
        // Variable that will spawn a particle effect
        var paricleEffect = Instantiate(pickUpEffect, transform.position, transform.rotation);

        // Apply health buff effect to the tank
        // Grab the tank health data from TankHealth component
        TankHealth stats =  player.GetComponent<TankHealth>();
        // Muliply the current health by the multiplier variable
        stats.currentHealth *= multiplier;


        // Remove power up object
        Destroy(gameObject);
        // Remove the particle effect after a second
        Destroy(paricleEffect,1);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
