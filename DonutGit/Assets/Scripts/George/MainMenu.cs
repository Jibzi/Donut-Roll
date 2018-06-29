using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

//
//Author: George & Kieran
//
//Script that adds functionality to the main menu.
//

public class MainMenu : MonoBehaviour {
    //
    //Menus
    GameObject MainMenuObject;
    GameObject OptionsMenuObject;
    //
    //Const bools to avoid magic numbers. I'll be able to make these local if 
    const bool kEnabled = true;
    const bool kDisabled = false;
    //
    //Audio
    AudioMixer audioMixer;
    float volume;
    float lastVolume;
    //
    //
    void Start()
    {
        //Initialise variables
        MainMenuObject = gameObject;
        OptionsMenuObject = GameObject.FindGameObjectWithTag("OptionsMenu");
        //Check that we have found the menu object
        Debug.Log(OptionsMenuObject);
        //Turn off the options menu, so it cannot be seen until wanted.
        DeactivateObject(OptionsMenuObject);
    }
    //
    //
        //Primary Methods(enabled by button press):
    //
    //
    //Enter the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    //
    //Go to the options menu from the main menu
    public void EnterOptionsMenu()
    {
        //Turn off the main menu, as we move from it
        DeactivateObject(MainMenuObject);
        Debug.Log("Main menu is no longer visible!");
        //Turn on the options menu, as we move to it
        ActivateObject(OptionsMenuObject);
        Debug.Log("Options menu is now visible!");
    }
    //
    //Go to the main menu from the options menu
    public void ExitOptionsMenu()
    {
        //Turn off the options menu, as we move from it
        DeactivateObject(OptionsMenuObject);
        Debug.Log("Options menu is no longer visible!");
        //Turn on the main menu, as we move to it
        ActivateObject(MainMenuObject);
        Debug.Log("Main menu is now visible!");
    }
    //
    //Exit the game
    public void QuitGame()
    {
        Debug.Log("Game will quit!");
        Application.Quit();
    }
    //
    //Change the volume via a slider
    public void SetVolume(float volume)
    {
        //Get the exposed vale here 
        audioMixer.SetFloat("MasterVolume", volume);
        Debug.Log("The volume has been changed");
    }   
    //
    //Mute or unmute the script dynamically, when the speaker icon is pressed
    public void MuteOrUnmuteVolume()
    {
        //if (volumeIsMuted) 
        //{
            //void Unmute()
            //{
                //volume = lastVolume
                //Destroy(lastVolume)
            //}
        //else
        //{
            //void Mute() //Set volume to const float kMinimalVolume = 80f; //Set float lastVolume to volumre.
        //}
    }
    //
    
    //
    //
        //Secondary Methods:
    //
    //
    //Turn on the given menu object
    void ActivateObject(GameObject menu)
    {
        if (menu.tag == "OptionsMenu" || menu.tag == "MainMenu")
        {
            menu.SetActive(kEnabled);
        }
        else
        {
            Debug.LogError("Error: the object inserted into ActiveObject is no menu");
        }
        
    }
    //
    //Turn off the given menu object
    void DeactivateObject(GameObject menu)
    {
        if (menu.tag == "OptionsMenu" || menu.tag == "MainMenu")
        {
            menu.SetActive(kDisabled);
        }
        else
        {
            Debug.LogError("Error: the object inserted into DeactiveObject is no menu");
        }
    }
    //
    private void MuteVolume()
    {
        lastVolume = volume;
        volume = 80f;
    }
    //
    private void UnMuteVolume()
    {
        volume = lastVolume;
    }
    //
    //Make sure the AudioMixer is valid. Print an error if it is not.
    private void FindAudioMixer()
    {
        audioMixer = GetComponent<AudioMixer>();
        if (!audioMixer) { Debug.LogError("Error: audioMixer is invalid"); }
    }
    //
    //
}
