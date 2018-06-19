/*
  Camera
  
  Will Chapman
  19/06/2018
  
  NOT READY FOR USE
  
  Sets the position of the camera to a distance (1/positionFraction) between the origin and donut position,
  and aims it at the donut. The speed at which these change slows the larger targetTween and positionTween are.
  
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChappersCam : MonoBehaviour
{

	[SerializeField]  private              Vector3      currentTarget;
	[SerializeField]  private              GameObject   donutCameraTarget;
	[SerializeField]  private              Camera       donutCamera;
	[SerializeField]  private              bool         chappersCam;
	[SerializeField]  static    readonly   Vector3      origin                = new Vector3(0f, 2f, -11f);
	[SerializeField]  private   const      float        targetTween           = 2f;
	[SerializeField]  private   const      float        positionTween         = 2f;
	[SerializeField]  private   const      float        positionFraction      = 4f;

	void Start()
	{
		//Initialise ChappersCam, then set RunCamera to true
		donutCameraTarget = GameObject.Find("Donut");
		currentTarget = donutCameraTarget.transform.position;
		donutCamera = Camera.main;
		chappersCam = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.chappersCam)
		{
			//Target Tweening Values
			Vector3 desiredTarget = donutCameraTarget.transform.position;
			currentTarget = (desiredTarget - currentTarget ) / targetTween;
			
			//Position Tweening Values
			Vector3 originDifference = donutCameraTarget.transform.position - origin;
			Vector3 desiredPosition = new Vector3(
				origin.x + (originDifference.x / positionFraction),
				origin.y + (originDifference.y / positionFraction),
				origin.z + (originDifference.z / positionFraction) 
			);
			Vector3 currentPosition = transform.position;
			Vector3 translatePositionBy = (desiredPosition - currentPosition ) / positionTween;
			
			//Update position and LookAt
			transform.Translate(translatePositionBy);	
			
			transform.LookAt(currentTarget);
		}
	}

	public bool RunCamera
	{
		get { return chappersCam;  }
		set { chappersCam = value;  }
	}
	
}
