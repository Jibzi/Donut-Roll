using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gColl : MonoBehaviour
{
	
	//
	//Author: George
	//
	//Component script that communicates with the gCollManager script in order to check for collisions.
	//A component was needed so that check can be abstacted and the obstacles/collectables feed their info,
	//such as their width and position (which forms a basic 2D hitbox).
	//
	//This script needs to be attached as a component to all object that need to interact with the donut, i.e. collectables and obstacles.
	//
	
	//TODO: Add an inheritence system so that each obstacle can have a version of this script that defines obstacle specific widths.

	private string _name;
	
	public gColl(string name)
	{
		_name = name;
	}

	private gCollManager _gCollManager;
	private float _myWidth;
	
	// Use this for initialization
	void Start () {
		_gCollManager = GameObject.Find("gCollManager").GetComponent<gCollManager>();
		_myWidth = 2.6f;
	}
	
	// Update is called once per frame
	void Update ()
	{
				
		if (_gCollManager.CheckCol(transform.position, _myWidth, this.name))
		{
			
			Debug.Log("There was a gColl!" + transform.position.x);
			
			GameObject.Destroy(this.gameObject);
		}
	}
}
