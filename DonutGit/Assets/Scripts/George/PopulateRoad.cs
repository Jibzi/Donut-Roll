using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Author: George
//
//Called when a road part resets to the far end of the road. Populates that road part with 4 obstacles, which are
//randomly chosen from the array. Then gives those obstacles a random X position chosen from 3 "lanes".
//Currently the obstacles are evenly spaced 5 units apart in Z i.e. 0, 5, 10, 15.
//

//TODO: Currently this does not work due to the WarpRedux script setting the new obstacles postitions to a hardcoded value.

public class PopulateRoad : MonoBehaviour {

    public GameObject[] Obstacles = new GameObject[2];

    private readonly float[] _xLanes = new float[3] {-5f, 0f, 5f};

    public void PopulateRoadSegment()
    {

        for (int i = 0; i < 4; i++)
        {
            int rnd = UnityEngine.Random.Range(0, 2);

            int rndVec = UnityEngine.Random.Range(0, 3);
            
            Vector3 vec = new Vector3(
                _xLanes[rndVec],
                0f,
                (100f + (5f * i))
                );

            Instantiate(Obstacles[rnd], vec, Quaternion.identity);
        }
    }
}
