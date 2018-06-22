﻿using System.Collections;
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
	private float _worldAcceleration;

	
	
	// Use this for initialization
	void Start ()
	{

		WorldSpeed = 15f;
	}
	
	
	// Update is called once per frame
	void Update ()
	{

			WorldSpeed += (Time.deltaTime * _worldAcceleration);
	}
}
