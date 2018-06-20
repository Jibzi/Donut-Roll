using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
//Author: George
//
//Script that adds functionality to the main menu.
//

public class MainMenu : MonoBehaviour {

    //Menus
    GameObject MainMenuObject;
    GameObject OptionsMenuObject;
    //Const bools to avoid magic numbers. I'll be able to make these local if 
    const bool kEnabled = true;
    const bool kDisabled = false;

    void Start()
    {
        MainMenuObject = gameObject;
        OptionsMenuObject = GameObject.FindGameObjectWithTag("OptionsMenu");
        Debug.Log(OptionsMenuObject);
        DeactivateObject(OptionsMenuObject);
    }


    //Primary Methods(enabled by button press):

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnterOptionsMenu()
    {
        DeactivateObject(MainMenuObject);
        Debug.Log("Main menu is no longer visible!");

        ActivateObject(OptionsMenuObject);
        Debug.Log("Options menu is now visible!");
    }

    public void ExitOptionsMenu()
    {
        DeactivateObject(OptionsMenuObject);
        Debug.Log("Options menu is no longer visible!");

        ActivateObject(MainMenuObject);
        Debug.Log("Main menu is now visible!");
    }

    public void QuitGame()
    {
        Debug.Log("Game will quit!");
        Application.Quit();
    }
    
    //Secondary Methods:

    void ActivateObject(GameObject menu)
    {
        menu.SetActive(kEnabled);
    }


    void DeactivateObject(GameObject menu)
    {
        menu.SetActive(kDisabled);
    }

}
