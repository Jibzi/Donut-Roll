/*
  Camera
  
  Will Chapman
  19/06/2018
  
  Sets the position of the camera to a distance (*positionFraction) between the origin and donut position,
  and aims it at the donut(+an offset).
  
  Movement of the camera's position and target can be smoothed by increasing their SmoothFactors.
  
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChappersCam : MonoBehaviour
{

	//Class Variables
	[SerializeField]   private     GameObject   donutCameraTarget;
	[SerializeField]   private     bool         chappersCam;
	
	//Camera Position/Origin variables
	[SerializeField]   private     Vector3      currentTarget;
	[SerializeField]   private     Vector3      origin                = new Vector3(0f, 8f, -14.3f);
	[SerializeField]   private     Vector3      donutOffset           = new Vector3(0f, 0.65f, 5.2f);
	[SerializeField]   private     Vector3      positionFraction      = new Vector3(0.5f, 0.05f, 0.125f);
<<<<<<< HEAD
	[SerializeField]   private     float        targetSmoothFactor    = Mathf.Clamp(4f, 1f, 128f);
	[SerializeField]   private     float        positionSmoothFactor  = Mathf.Clamp(4f, 1f, 128f);
=======
	
	//Smoothing Factors
	[SerializeField]
	[Range( 1f, 128f)] private     float        targetSmoothFactor    = 16f;
	[SerializeField]
	[Range( 1f, 128f)] private     float        positionSmoothFactor  = 8f;
>>>>>>> d8879a88d2a9c82b6dbc476c4af06c21ee1e1d44

	//Initialise ChappersCam
	void Start()
	{
		donutCameraTarget = GameObject.Find("Donut");
<<<<<<< HEAD
		currentTarget = donutCameraTarget.transform.position;
		chappersCam = true;
=======
		currentTarget = donutCameraTarget.transform.position+donutOffset;
>>>>>>> d8879a88d2a9c82b6dbc476c4af06c21ee1e1d44
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.chappersCam)
		{
			//Set current target to itself, plus the difference bewteen it and the donut's position(+ an offset), eased by targetTween
			currentTarget += (donutCameraTarget.transform.position+donutOffset - currentTarget ) / targetSmoothFactor;
			
			//Get difference between donut position and origin
			Vector3 originDifference = donutCameraTarget.transform.position - origin;
			
			//Set desired position to the origin, plus a fraction of the difference between the origin and and donut position
			//Desired position is just a maximum offset from the origin for wherever the donut currently is
			Vector3 desiredPosition = new Vector3(
				origin.x + (originDifference.x * positionFraction.x),
				origin.y + (originDifference.y * positionFraction.y),
				origin.z + (originDifference.z * positionFraction.z) 
			);
			
			//Need to translate by the difference between the desired position and the current one, eased by positionTween
			Vector3 translatePositionBy = (desiredPosition - transform.position ) / positionSmoothFactor;
			
			//Update position and LookAt
			transform.Translate(translatePositionBy);	
			transform.LookAt(currentTarget);
		}
	}

	//Won't use this camera trickery when not required.
	public bool RunCamera
	{
		get { return chappersCam;  }
		set { chappersCam = value;  }
	}
	
}