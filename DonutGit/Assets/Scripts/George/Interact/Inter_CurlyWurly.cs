using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_CurlyWurly : Interactable
{
    
    public override void Interact(Donut interactor)
    {
        
        base.Interact(interactor);

        //Do effect
        interactor.Score = 0;

        //Play sound
        AMa.Play("Crash");

        //Do visuals
        SpEf.DonutDie();

        //Destroy trigger but not visuals
        Destroy(this.GetComponent<BoxCollider>());

    }
}
