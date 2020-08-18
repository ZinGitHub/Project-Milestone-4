using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TankHealth : MonoBehaviour
{
    //public field TankData contained in data
    public TankData data;
    // float variable for the current health of the tank
    // Can be editted by designer
    public float currentHealth;
    // float varaibele for the max health, set to one by default
    // Can be editted by designer
    public float maxHealth = 1;

    // Attach gameObject for tank destroy particle effect for player tank
    public GameObject destroyEffect;

    // Attach HealthBat for player health bar componenent
    //public HealthBar healthBar;

    

    // Start is called before the first frame update
    void Start()
    {
        // The variable data will contain the component TankData 
        data = GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function for taking damage
    // parameter = float amount and TankData origin
    public void TakeDamage(float amount, TankData origin)
    {
        // Current health = current health - amount
        currentHealth -= amount;

        // Set the health bar according to current player tank health
        //healthBar.SetHealth(currentHealth);

        // Return a float between the minimum and maximum values
        Mathf.Clamp(currentHealth, 0.0f, maxHealth);

        // An if statement that will be executed if the current health is less than or equal to zero
        if(currentHealth <= 0)
        {
            // An if statemente that will be executed if the origin does not equal null
            if(origin != null)
            {
                // origin.score = origin.score + data.points
                origin.score += data.points;      
                
            }
            // Destroy the tank object
            Destroy(gameObject);


        } 

        if(currentHealth == 0)
        {
            deathEffect();
        }
    }

    void deathEffect()
    {
        // Spawn a cool effect
        var paricleEffect = Instantiate(destroyEffect, transform.position, transform.rotation);

        Destroy(paricleEffect, 1);
    }
}
