using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_GummyBear : Interactable
{
    public Inter_GummyBear()
    {
        points = 10;
        sound = "Pickup";
        shake = 0f;
    }
        
    protected override void Unique(Donut interactor)
    {
        //Destroy self
        Destroy(gameObject);
    }
}
