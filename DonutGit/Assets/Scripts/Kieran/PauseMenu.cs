using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private bool isPaused;
    private bool escapePressed;
    
    // Use this for initialization
	void Start ()
    {
        isPaused = (Time.timeScale == 1f);
        escapePressed = (Input.GetAxis("Cancel") == 1);
    }

    public float Pause()
    {
        const float kPauser = 0f;
        Debug.Log("The game has been paused.");
        ContextDependentPause();
        return  0f;
    }

    public float Unpause()
    {
        const float kUnauser = 1f;
        Debug.Log("The game has been unpaused.");
        ContextDependentPause();
        return 1f;
    }

    public bool IsPaused
    {
        get { return isPaused; }
        set { /*readonly*/ Debug.LogWarning("Cannot set. Property is readonly."); }
    }

    void ContextDependentPause()
    {
        {
            //If the game is paused, unpause it. Otherwise, pause it.
            Time.timeScale = isPaused ? Unpause() : Pause();
        }
    }
    
    //Deprecated
    /*void ContextDependentPause()
    {
        //Has escape been pressed?
        if (escapePressed)
        {
            //If the game is paused, unpause it. Otherwise, pause it.
            Time.timeScale = isPaused ? Unpause() : Pause();
        }
    }

	// Update is called once per frame
	void Update ()
    {
        ContextDependentPause();
	}*/
}
