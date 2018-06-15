﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Author: George
//
//Component script that gives behaviour to the road pieces. Mainly the speed at which they move, which in turn is
//how fast the game is; as it is the world moving, not the player.
//Also calls the PopulateRoad script when this resets back to the far end of the road, prompting new objects to spawn.
//

public class RoadPartComponent : MonoBehaviour
{

	private PopulateRoad _populateRoad;
	
	// Use this for initialization
	void Start ()
	{

		_populateRoad = gameObject.GetComponentInParent<PopulateRoad>();
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
			
			Debug.Log(_populateRoad);
			_populateRoad.PopulateRoadSegment();
		}
	}
}