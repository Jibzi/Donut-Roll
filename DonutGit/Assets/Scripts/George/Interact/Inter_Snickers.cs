using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Inter_Snickers : Interactable
{
    public Inter_Snickers()
    {
        points = 0;
        sound = "Crash";
        shake = 10f;
    }

    protected override void Unique(Donut interactor)
    {
        //Reduce Speed
        GameObject.Find("Road").GetComponent<WorldMover>().WorldSpeed -= 10;
        
        //Kill donut if too slow
        if (GameObject.Find("Road").GetComponent<WorldMover>().WorldSpeed < 13)
        {
            GameObject.Find("Road").GetComponent<WorldMover>().WorldSpeed = 0;
        }

        //Destroy trigger but not visuals
        Destroy(this.GetComponent<BoxCollider>());
    }
}
