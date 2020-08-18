using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    // AudioSource component attached to button sound effect
    public AudioSource buttonFX;
    // Audioclip component attached to click sound effect
    public AudioClip clickFX;

    // Function definition for click sound
    public void ClickSound()
    {
        // Play the button affect with the appropriate click sound effect.
        buttonFX.PlayOneShot(clickFX);
    }

}
