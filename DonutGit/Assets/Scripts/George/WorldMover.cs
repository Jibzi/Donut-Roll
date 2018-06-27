using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{

	//
	//Author: George
	//		  Will
	//
	//Manager script that handles the world speed variable that the road peices can grab, so they can slowly ramp up in speed.
	//

	public float WorldSpeed;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip(
		"How much extra speed is added to the world speed every second. Recommended 0.075")]
	public float WorldAcceleration;

	
	
	// Use this for initialization
	void Start ()
	{

		WorldSpeed = 13f;
		WorldAcceleration = 0.14f;
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		if (WorldSpeed > 1)
		{
			WorldSpeed = Mathf.Clamp(WorldSpeed + (Time.deltaTime * WorldAcceleration), 0f, Mathf.Infinity);
			WorldAcceleration += 0.001f * Time.deltaTime;
		}
		else
		{
			//Make double sure that the WorldSpeed is 0, jst incase it was updated from 0 before the next check
			WorldSpeed = 0;
		}
	}
}
