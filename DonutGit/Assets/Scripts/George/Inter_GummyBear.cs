using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_GummyBear : Interactable
{
    
    
    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);

        this.isCollectable = true;

        //Do effect
        interactor.Score += 10;

        //Play sound
        CheckTypeThenDoThings();

        //Do visuals
        
        
        //Destroy self
        Destroy(gameObject);
    }
}
