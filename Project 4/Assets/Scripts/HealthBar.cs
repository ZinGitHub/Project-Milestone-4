using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Variable storing slider UI for health
    public Slider slider;
    // Variable storing the gradient scale for health bar UI
    public Gradient gradient;
    //
    public Image fill;


    // Function definition for SetMaxHealth
    // This function will define the max health value the health bar (UI slider) should account for
    public void SetMaxHealth(float health)
    {
        // The max value of the health bat will be the player's health when starting the game (max health)
        slider.maxValue = health;
        // Slider UI's value will equal player tank health
        slider.value = health;
        // By default put the gradient to 1 which equals green
        fill.color = gradient.Evaluate(1f);
    }

    // Function definition for SetHealth
    // This function will define the value the health bar (UI slider) should update to
    public void SetHealth(float health)
    {
        // Slider UI's value will equal player tank health
        slider.value = health;
        // Adjust the color of the gradient depending on health
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    

}
