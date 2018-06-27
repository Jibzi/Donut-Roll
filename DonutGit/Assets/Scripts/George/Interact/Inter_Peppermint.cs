using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Peppermint : Interactable
{
    public Inter_Peppermint()
    {
        points = 50;
        sound = "Pickup";
        shake = 0f;
    }
        
    protected override void Unique(Donut interactor)
    {
        //Destroy self
        Destroy(gameObject);
    }
}
