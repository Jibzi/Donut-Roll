using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_CurlyWurly : Interactable
{
    public Inter_CurlyWurly()
    {
        points = 0;
        sound = "Crash";
        shake = 15f;
    }
        
    protected override void Unique(Donut interactor)
    {
        //Do visuals
        SpEf.DonutDie();

        //Destroy trigger but not visuals
        Destroy(this.GetComponent<BoxCollider>());
    }
    
}
