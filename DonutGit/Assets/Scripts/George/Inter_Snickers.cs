using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Snickers : Interactable
{
    

    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);

        //Do effect
        interactor.Score = 0;
        
        //Play sound
        PlayTypeSound();

        //Do visuals
        Camera.main.GetComponent<ChappersCam>().Shake(8f);


        //Don't destroy self
        Triggerable = false;
        //Destroy(gameObject);
    }
}
