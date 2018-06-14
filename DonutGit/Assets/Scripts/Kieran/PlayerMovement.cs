using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //The speed at which the player travels.
    public Vector3 speed;

    [Range(3, 5)]
    public int pathways_locked = 3;
    [Range(0, 5)]
    public float pathways;

    const float
        x = 1,
        y = 1,
        z = 1;
    private readonly Vector3 k_defaultSpeed = new Vector3(
        x,
        y,
        z
        );

    Gyroscope m_gyro;
     
    enum CharacterHorizontalMovement
    {
        Gyroscope,
        Touchscreen,
        Arrowkeys,
        Defunct
    };

    CharacterHorizontalMovement CHM;

    //public Vector3 Speed();
   
    // Use this for initialization
    void Start()
    {
        m_gyro = Input.gyro;
        //Enum to define what will control the character 
        InitialiseInput();
    }

    void SetSpeedToDefault()
    {
        //This method resets speed to default. To be used after a speedboost.
        speed = k_defaultSpeed;
    }

    void SpeedUp(float speedMultiplier)
    {
        //This method speeds up the player as they pass over a jump-pad; but can be reused
        speed *= speedMultiplier;
    }

    //This method speeds up the player for a specified amount of time, before returning the speed to default
    void SpeedUpTemporarily(float speedMultiplier)
    {
        SpeedUp(speedMultiplier);
        //DoSomethingWithTime()

    }
    
    //Move the player avatar left or right, but they can only be in one of 3 to 5 places.
    void MoveSidewaysLocked(int pathways)
    {
        
    }

    //Move the player avatar left or right, using the gyroscope.
    void MoveSideWays()
    {

    }

    //This method sets up the the game's input
    void InitialiseInput()
    {
        //Is gyroscope enabled?
        if (m_gyro.enabled) //https://docs.unity3d.com/ScriptReference/Input-gyro.html
        {
            CHM = CharacterHorizontalMovement.Gyroscope;
        }
        //Does touchscreen work? This will let us use the touchscreen instead
        else if (SystemInfo.deviceType == DeviceType.Handheld)  //https://docs.unity3d.com/ScriptReference/SystemInfo.html
        {
            CHM = CharacterHorizontalMovement.Touchscreen;
        }
        //Are we using a desktop (thus needing a keyboard)?
        else if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            CHM = CharacterHorizontalMovement.Arrowkeys;
            //Initialise arrow keys
        }
        //Nothing works; so display an error message.
        else
        {
            CHM = CharacterHorizontalMovement.Defunct;
        }
    }

    void GetGyroscopicInput()
    {
        //if (Input.gyro.)
    }



    void GetInput()
    {
        if (CHM == CharacterHorizontalMovement.Gyroscope)
        {

        }
    }

	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        //Use this for input
        GetInput();
    }
}
