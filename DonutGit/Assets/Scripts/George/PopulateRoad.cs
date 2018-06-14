using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateRoad : MonoBehaviour {

    public GameObject[] Obstacles = new GameObject[2];

    private readonly float[] _xLanes = new float[3] {-5f, 0f, 5f};

    public void PopulateRoadSegment()
    {

        for (int i = 0; i < 4; i++)
        {
            int rnd = UnityEngine.Random.Range(0, 2);

            int rndVec = UnityEngine.Random.Range(0, 1);
            
            Vector3 vec = new Vector3(
                _xLanes[rndVec],
                0f,
                (100f + (5f * i))
                );

            Instantiate(Obstacles[rnd], vec, Quaternion.identity);
        }
    }
}
