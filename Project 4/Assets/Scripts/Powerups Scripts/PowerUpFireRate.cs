using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFireRate : MonoBehaviour
{
    // Float variable storing the multiplier
    public float multiplier = 2f;
    // Float variable storing the amounf of seconds
    public float duration = 3f;
    // GameObject component variable that will attach to the health pickup
    public GameObject pickUpEffect;

    // OnTriggerEnter method used for when another object with a tag player or enemy interacts with the trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the object collider has a tag with Player then execute PickUp function
        if (other.CompareTag("Player"))
        {
            // PickUp function recall
            // Starting the coroutine on the pickUp method
            StartCoroutine(PickUp(other));
        }

        // If the object collider has a tag with Enemy then execute PickUp function
        if (other.CompareTag("Enemy"))
        {
            // PickUp function recall
            // Starting the coroutine on the pickUp method
            StartCoroutine(PickUp(other));
        }
    }

    // Converted from void to IEnumerator to allow the usage of a coroutine
    IEnumerator PickUp(Collider player)
    {
        // Variable that will spawn a particle effect
        var paricleEffect = Instantiate(pickUpEffect, transform.position, transform.rotation);

        // Apply fire rate buff effect to the tank
        // Grab the tank fireCooldown data from TankData component
        TankData stats = player.GetComponent<TankData>();
        // Divide the current fireCooldown by the multiplier variable
        stats.fireCooldown /= multiplier;

        // Disable the graphics of the powerup by disabling MeshRendered
        GetComponent<MeshRenderer>().enabled = false;
        // Disable the collider
        GetComponent<Collider>().enabled = false;

        // Wait how every many seconds in duration variable
        yield return new WaitForSeconds(duration);

        // Reverse the effect on the tank and go back to a normal state
        // Multiply the fireCooldown by the multiplier variable
        stats.fireCooldown *= multiplier;

        // Remove power up object
        Destroy(gameObject);
        // Remove the particle effect after a second
        Destroy(paricleEffect, 1);
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
