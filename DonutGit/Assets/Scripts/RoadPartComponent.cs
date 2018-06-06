using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPartComponent : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//TODO: Make this speed a variable so that we can get faster and slower during gameplay.
		this.transform.Translate(0,0, -(Time.deltaTime * 10));

		//Teleport any road parts that are behind the camera to the far end of the road.
		if (this.transform.position.z < -20f)
		{
			//TODO: Consider also swapping out the mesh for another; to reduce the repition.
			this.transform.Translate(0, 0, 120);
		}
	}
}
