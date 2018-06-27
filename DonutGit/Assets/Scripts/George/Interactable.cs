using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //
    //Author: George
    //        Kieran
    //        Will
    //       
    //Purely to set the structor of children that inherit from this, so that unique scripts can be called all through 
    //this one virtual function.
    //

    //The AudioManager. Static, because it must be the same in every instance.
    protected static AudioManager AMa;
    //Whether the inheritor is an obstacle or collectable.
    protected bool isCollectable;

    private bool triggerable = true;

    

    private void Start()
    {
        //Get the audio manager
        AMa = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


    public virtual void Interact(Donut interactor)
    {
        
    }

    //Check if the collisible is a colectable or an obstacle, before carrring out type-specific actions
    protected void CheckTypeThenDoThings()
    {
        //If the collisible is an obstacle
        if (!isCollectable)
        {
            PlayObstacleSound();
        }
        //Else, the collisible must be a collectable
        else if(isCollectable)
        {
            PlayCollectableSound();
        }
        //Otherwise, the collisible has not been assigned a type
        else
        {
            Debug.LogError("This collisible is neither a collectable nor an obstacle.");
        }
    }

    //Play the pickup noise
    private void PlayCollectableSound()
    { 
        AMa.Play("Pickup");
    }
    
    //Play the obstacle noise
    private void PlayObstacleSound()
    {
        AMa.Play("Crash");
    }




    public bool Triggerable
    {
        get { return triggerable; }
        set { triggerable = value; }
    }

}
