using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Inter_Strawberry : Interactable {

    public Inter_Strawberry()
    {

        points = 100;
        sound = "Pickup";
        shake = 0f;
    }

    protected override void Unique(Donut interactor)
    {
        
        Destroy(gameObject);
    }
}
