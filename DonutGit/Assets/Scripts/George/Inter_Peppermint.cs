﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Peppermint : Interactable
{

        
    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);
        
        //Do effect
        interactor.Score += 5;
        
        
        //Do visuals
        
        
        //Destroy self
        Destroy(gameObject);
    }
}
