using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Pellets : Interactable
{


    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);

        //Do effect
        interactor.Score = 0;

        //Play sound
        PlayTypeSound();

        //Do visuals
        Camera.main.GetComponent<ChappersCam>().Shake(6f);


        //Don't destroy self
        Triggerable = false;
        //Destroy(gameObject);
    }
}
