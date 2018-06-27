﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_GummyBear : Interactable
{
    
    
    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);
        
        //Do effect
        interactor.Score+= 10;
        
        //Play sound
        AMa.Play("Pickup");
        
        //Do visuals
        
        
        //Destroy self
        Destroy(gameObject);
    }
}
