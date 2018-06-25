using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //
    //Author: George
    //        Will
    //
    //Purely to set the structor of children that inherit from this, so that unique scripts can be called all through 
    //this one virtual function.
    //
<<<<<<< HEAD

    //The AudioManager
    private AudioManager AMa;
    //Whether the inheritor is an obstacle or collectable.
    protected bool isCollectable;
=======
    private bool canCollide = true;
>>>>>>> cccd3d358b6c5acf0fbd14d8b8b1ec3c51a55f17
    

    private void Awake()
    {
        FindAudioManager();
    }

    public virtual void Interact(Donut interactor)
    {
        
    }

<<<<<<< HEAD
    protected void CheckTypeThenPlaySound()
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
        const int kPickupIndex = 2;
        //Play the pickup noise
        AMa.Play(AMa.sounds[kPickupIndex].ToString());
    }

    private void PlayObstacleSound()
    {
        //The constant index of the obstacle's noise
        const int kObstacleIndex = 2;
        //Play the obstacle noise
        AMa.Play(AMa.sounds[kObstacleIndex].name);
    }


    private void FindAudioManager()
    {
        AMa = GetComponent<AudioManager>();
    }

=======
    public bool CanCollide
    {
        get { return canCollide; }
        set { canCollide = value; }
    }
>>>>>>> cccd3d358b6c5acf0fbd14d8b8b1ec3c51a55f17
}
