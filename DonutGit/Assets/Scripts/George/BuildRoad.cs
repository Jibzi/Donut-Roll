using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BuildRoad : MonoBehaviour
{

	public GameObject _roadPart;

	
	// Use this for initialization
	void Start ()
	{		
		//Spawn some length of road
		//TODO:make this variable.
		for (int i = 0; i < 6; i++)
		{
			Instantiate(_roadPart, new Vector3(0, 0, i * 20), Quaternion.identity, this.transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
