using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //
    //Author: George
    //
    //Purely to set the structor of children that inherit from this, so that unique scripts can be called all through 
    //this one virtual function.
    //
    
    public virtual void Interact(Donut interactor)
    {
        
    }
}
