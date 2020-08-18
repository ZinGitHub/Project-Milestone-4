using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Audio component for the slider to attach to the audio mixer for music
    public AudioMixer AudioMixer;
    // Audio component for the slider to attach to the audio mixer for sound effects
    public AudioMixer SoundMixer;
    // Array to hold all the resolutions available
    Resolution[] resolutions;
    // Variable component that will reference the resolution dropbown in the UI
    public TMP_Dropdown ResolutionDropdown;

    // Call everything in the start method when scene loads
    private void Start()
    {
        // Int variable that should hold the correct resolution
        int CurrentResolutionIndex = 0;
        // Screen will give scripts access to the resolution
        // Set the resolution array to whatever resolutions are found via Screen.resolutions
        resolutions = Screen.resolutions;

        // Access the resolution dropbown and make sure it starts of with no options initially
        ResolutionDropdown.ClearOptions();

        // Create strings because AddOptions(...) will only take in a list of strings and not the array of resolutions 
        // Convert the array of resolutions into strings
        List<string> options = new List<string>();

        // Loop through each resolution element array
        for (int i = 0; i < resolutions.Length; i++)
        {
            // For each element in the resolutions create a string for it
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            // Add the element to the options list from the given option string created
            options.Add(Option);

            // If the resolution that is being looked at is equal to the players personal default resolution
            // Compare the width and the height of the resolutions
            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                // If both match up then the player is using what is deemed the correct/optimal resolution
                CurrentResolutionIndex = i;
            }
        }

        // Access the resolution dropdown and add the resolution options 
        ResolutionDropdown.AddOptions(options);
        // By default set the current resolutionto whatever the CurrentResolutionIndex is showing
        ResolutionDropdown.value = CurrentResolutionIndex;
        // Display the resolutions 
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Function definition for SetVolume
    // Take a float value for volume
    public void SetVolume(float Volume)
    {
        // Calculate the value of the volume parameter
        // Using Mathf.Log10 gives it better percision
        AudioMixer.SetFloat("Volume", Mathf.Log10(Volume) * 20);
        // Save the settings of music volume
        DontDestroyOnLoad(this.AudioMixer);
    }

    // Functio  defintiion for SetSound
    // Take a float value for sound
    public void SetSound(float Sound)
    {
        // Calculate the value of the volume parameter
        // Using Mathf.Log10 gives it better percision
        SoundMixer.SetFloat("Sound", Mathf.Log10(Sound) * 20);
        // Save the settings of sound volume
        DontDestroyOnLoad(this.SoundMixer);
    }


    // Function definition for SetQuality
    // Take a int value for qualityIndex (quality options)
    // 0 = low quality
    // 1 = medium quality
    // 2 = high quality
    public void SetQuality(int qualityIndex)
    {
        // Access the QualitySettings
        // QualitySettings allows the script to gain access to the quality settings in the gmae engine and adjust through inspector
        // qualityIndex should be hooked onto the UI
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Function definition for SetFullScreen
    // Take a boolean value to check if the game is being played on fullscreen or not at the current moment
    public void SetFullscreen(bool isFullscreen)
    {
        // Access the screen and give script access to the game screen
        // isFullscreen should be hooked onto the UI
        Screen.fullScreen = isFullscreen;
    }

}
