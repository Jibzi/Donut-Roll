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
    private bool canCollide = true;
    
    public virtual void Interact(Donut interactor)
    {
        
    }

    public bool CanCollide
    {
        get { return canCollide; }
        set { canCollide = value; }
    }
}
