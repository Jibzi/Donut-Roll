using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Peppermint : Interactable
{

        
    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);
        
        //Do effect
        interactor.Score += 50;
        
        //Play sound
        PlayTypeSound();
        
        //Do visuals
        
        
        //Destroy self
        Destroy(gameObject);
    }
}
