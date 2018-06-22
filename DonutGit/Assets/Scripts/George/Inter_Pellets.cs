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


        //Do visuals
        Camera.main.GetComponent<ChappersCam>().Shake(6f);


        //Destroy self
        Destroy(gameObject);
    }
}
