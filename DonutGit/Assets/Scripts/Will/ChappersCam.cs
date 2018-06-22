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
	[SerializeField]   private     GameObject    donutCameraTarget;
	[SerializeField]   private     bool          chappersCam;
	[SerializeField]   private     bool          shakeCam;
	                   private     System.Random rand                  = new System.Random();
	
	//Camera Position/Origin variables
	[SerializeField]   private     Vector3       currentTarget;
	[SerializeField]   private     Vector3       origin                = new Vector3(0f, 14f, -14.3f);
	[SerializeField]   private     Vector3       donutOffset           = new Vector3(0f, 0.65f, 5.2f);
	[SerializeField]   private     Vector3       positionFraction      = new Vector3(0.5f, 0.05f, 0.125f);
	
	//Smoothing Variables
	[SerializeField]
	[Range(1f, 128f)]
	private     float         targetSmoothFactor    = 4f;
	[SerializeField]
	[Range(1f, 128f)]
	private     float         positionSmoothFactor  = 4f;
	[SerializeField]
	[Range(1f, 128f)]
	private     Vector3       shakeFactor;

	void Start()
	{
		//Initialise ChappersCam, then set RunCamera to true
		donutCameraTarget = GameObject.Find("Donut");
		currentTarget = donutCameraTarget.transform.position;
		chappersCam = true;
	}

	//Won't use this camera trickery when not required.
	public bool RunCamera
	{
		get { return chappersCam;  }
		set { chappersCam = value;  }
	}
	
	//Call with a float intensity of how much camera hake to add
	public void Shake(float _intensity)
	{
		shakeCam = true;
		shakeFactor = new Vector3(rand.Next(10), rand.Next(10), 0).normalized * _intensity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.chappersCam)
		{
			if (shakeCam)
			{
				//Future development could include smooth springing along a defined axis
				shakeFactor *= -0.9f;
				if (shakeFactor.magnitude < 0.1f)
				{
					shakeFactor = new Vector3(0, 0, 0);
					shakeCam = false;
				}
			}
			
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
			) + shakeFactor;
			//Need to translate by the difference between the desired position and the current one, eased by positionSmoothFactor
			Vector3 translatePositionBy = (desiredPosition - transform.position ) / positionSmoothFactor;
			
			//Update position and LookAt
			transform.Translate(translatePositionBy);	
			transform.LookAt(currentTarget);
		}
	}
	
}