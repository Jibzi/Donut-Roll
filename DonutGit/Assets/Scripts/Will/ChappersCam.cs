/*
  Camera
  
  Will Chapman
  19/06/2018
  
  NOT READY FOR USE
  
  Sets the position of the camera to a distance (1/4) between the origin and donut position, and aims it at the donut
  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChappersCam : MonoBehaviour
{

	[SerializeField]  private         GameObject   donutCameraTarget;
	[SerializeField]  private         Camera       donutCamera;
	[SerializeField]  private         bool         chappersCam;
	//[SerializeField]  private  const  Vector3      position;

	public ChappersCam()
	{
		//Initialise ChappersCam, then set RunCamera to true
		this.chappersCam = false;
	}
	
	// Use this for initialization
	void Start ()
	{
		this.donutCameraTarget = GameObject.Find("Player");
		this.donutCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.chappersCam)
		{
			//this.donutCamera.transform.position.Set();
			
		}
	}

	public bool RunCamera
	{
		get { return this.chappersCam;  }
		set { this.chappersCam = value;  }
	}
	
}
