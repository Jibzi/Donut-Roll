using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Snickers : Interactable
{
    

    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);

        //Do effect
        interactor.Score -= 100;


        //Do visuals


        //Destroy self
        Destroy(gameObject);
    }
}
