using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_Pellets : Interactable
{
    public Inter_Pellets()
    {
        points = 0;
        sound = "Pickup";
        shake = 5f;
    }

    protected override void Unique(Donut interactor)
    {
        //Speed Boost
        SpEf.DonutBoost();
        //Destroy trigger but not visuals
        Destroy(this.GetComponent<BoxCollider>());
    }

}
