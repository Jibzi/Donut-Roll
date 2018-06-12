using System;   //System because dealing with Eventhandlers
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    GameObject Player;

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

    //Our lovely event handler, to which we add using the += operator (Page 16 of Player's Guide to C#)
    public static event EventHandler Collected; 

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

    void CheckIsCollidingThenCollect()
    {
        //Note: I want to later change this method to a container-method.
        //Declared and initialised in case of reuse, and for cleaner code, avoiding magic numbers/magic variables
        //Check if the collectable is colliding with the donut. 
        bool isColliding = (this.transform.position.x <= (xDistance + Player.transform.position.x))
            && (this.transform.position.z <= (zDistance + Player.transform.position.z));
        //If the collectable is colliding with the donut,
        if (isColliding)
        {
            //Trigger the OnCollected() event.
            OnCollected();
        }
    }
    
// Use this for initialization
	void Start () {
        SetSize();
        FindPlayer();
        Collected += HandleCollected;
	}

	// Update is called once per frame
	void Update ()
    {
        CheckIsCollidingThenCollect();
        
    }
}
