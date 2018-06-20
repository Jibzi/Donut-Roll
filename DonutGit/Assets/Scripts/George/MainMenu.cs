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

    }




    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnterOptionsMenu()
    {

    }

    public void ExitOptionsMenu()
    {

    }


    public void QuitGame()
    {
        Debug.Log("Game will quit!");
        Application.Quit();
    }
    
    //Secondary Methods:
}
