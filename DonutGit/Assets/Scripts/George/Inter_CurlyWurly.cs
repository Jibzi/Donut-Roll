using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_CurlyWurly : Interactable
{
    
        
    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);
        this.isCollectable = false;


        //Do effect
        interactor.Score = 0;

        //Play sound
        CheckTypeThenPlaySound();

        //Do visuals
        Camera.main.GetComponent<ChappersCam>().Shake(10f);
        
        
        //Destroy self
        Destroy(gameObject);
    }
}
