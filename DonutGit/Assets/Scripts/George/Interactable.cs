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

    //The AudioManager
    protected AudioManager AMa;
    //Whether the inheritor is an obstacle or collectable.
    protected bool isCollectable;

    private bool triggerable = true;

    

    private void Start()
    {
        //Init Audio manager
        AMa = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


    public virtual void Interact(Donut interactor)
    {
        
    }


    protected void PlayTypeSound()
    {
        if (isCollectable)
        {
            PlayCollectableSound();
        }
        else
        {
            PlayObstacleSound();
        }
    }

    private void PlayCollectableSound()
    {
        //The constant index of the pickup
            //const int kPickupIndex = 1;
        //Play the pickup noise
        AMa.Play("Pickup");
    }

    private void PlayObstacleSound()
    {
        //The constant index of the obstacle's noise
            //const int kObstacleIndex = 2;
        //Play the obstacle noise
        AMa.Play("Crash");
    }

    public bool Triggerable
    {
        get { return triggerable; }
        set { triggerable = value; }
    }

}
