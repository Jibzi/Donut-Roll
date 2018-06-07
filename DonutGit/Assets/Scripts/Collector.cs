using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    GameObject Collectable;

    // Use this for initialization
    void Start()
    {
        Collectable = GameObject.FindWithTag("Collectable");
    }

    void ResetCollectable()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
