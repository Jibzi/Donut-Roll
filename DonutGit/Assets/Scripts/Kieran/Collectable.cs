using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//System because dealing with EventHandlers
using System;   

public class Collectable : MonoBehaviour {

    GameObject Player;
    private bool isColliding;

    //Random scaling
    [SerializeField][Tooltip("The minimal randomly allocable to the collectable. Recommended: 0.9")]
    private float minimalCollectableSize;
    [SerializeField]
    [Tooltip("The maximal randomly allocable to the collectable. Recommended: 1.1")]
    private float maximalCollectableSize;
    [SerializeField]
    [Tooltip("The distance from the donut to check for collision")]
    private float xDistance;
    [SerializeField]
    [Tooltip("The distance from the donut to check for collision")]
    private float zDistance;
    //ToDo: Luke has suggested a collisive offset for the donut, to change the gamefeel.
    
    //Our lovely event handler, to which we add using the += operator (Page 16 of Player's Guide to C#)
    public static event EventHandler Collected; 



    //For visual variation, minutely change the size of every collectable
    void SetSize()
    {
        /*A temporary local randomisative modulator - the number by which we modulo
            total playtime to get our number of different sizes the coin can be.*/
        const float 
            randomisitiveModulator = 10f,
            randomisitiveDivisor = 5f;
        //Declare a local holder variable for the randomised scale.
        float rando = Mathf.Clamp((
            (Time.fixedTime % randomisitiveModulator) / randomisitiveDivisor), 
            minimalCollectableSize, 
            maximalCollectableSize
            );
        transform.localScale *= rando;
    }
    
    void FindPlayer()
    {
        const string kPlayerTag = "Player";
        Player = GameObject.FindGameObjectWithTag(kPlayerTag);
        Debug.Log(kPlayerTag);
        
    }

    void PrintPlayerPosX()
    {
        Debug.Log("PlayerX = " + Player.transform.position.x);
    }

    void PrintPlayerPosZ()
    {
        Debug.Log("Player Z = " + Player.transform.position.z);
    }

    void PrintCollectablePosX()
    {
        Debug.Log("Coin X = " + this.transform.position.x);
    }

    void PrintCollectablePosZ()
    {
        Debug.Log("Coin Z = " + this.transform.position.z);
    }

    bool CheckCollideZAndGetCollidingOnX()
    {
        //Declare a bool.
        bool isCollidingZ = transform.position.z == Player.transform.position.z;
        if (isCollidingZ)
        {
            Debug.Log("This is colliding on Z");
        }


        return isCollidingZ;
    }

    public void OnCollected()
    {
        if (Collected != null)
        {
            Collected(this, EventArgs.Empty);
        }
    }

    public void HandleCollected(object sender, EventArgs eventArgs)
    {
        //Do something important when collected:
        //Trigger a pretty particle effect upon destruction.
        
        //Destroy the current collectable
        Destroy(this);
        Debug.Log("Collectable has been destroyed");
    }

    public bool GetIsColliding()
    {
        return isColliding;
    }

    void CheckIsCollidingThenCollect()
    {
        //Note: I want to later change this method to a container-method.
        //Declared and initialised in case of reuse, and for cleaner code, avoiding magic numbers/magic variables
        //Check if the collectable is colliding with the donut. 
        //If the collectable is colliding with the donut,
        if (this.GetIsColliding())
        {
            //Trigger the OnCollected() event.
            OnCollected();
        }
    }

    // Use this for initialization
    void Start()
    {
        SetSize();
        FindPlayer();
        
        Collected += HandleCollected;
        isColliding = (transform.position.x <= (xDistance + Player.transform.position.x))
            && (transform.position.z <= (zDistance + Player.transform.position.z));
        //isColliding = false;
        
    }

    // Update is called once per frame
    void Update ()
    {
        
        PrintPlayerPosX();
        PrintCollectablePosX();
        PrintPlayerPosZ();
        PrintCollectablePosZ();
        CheckCollideZAndGetCollidingOnX();
    }

    private void FixedUpdate()
    {
        CheckIsCollidingThenCollect();
    }
}
