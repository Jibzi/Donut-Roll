using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

//
//Author: George
//
//Script that builds the road out of road parts. Simple.
//

public class BuildRoad : MonoBehaviour
{

	public GameObject _roadPart;

	private int _roadLength;

	
	// Use this for initialization
	void Start ()
	{

		//Tune the road length here.
		_roadLength = 6;
		
		MakeTheRoad();
	}

	private void MakeTheRoad()
	{

		for (int j = 0; j < _roadLength; j++)
		{
			Instantiate(_roadPart, new Vector3(0, 0, j * 20), Quaternion.identity, transform);
		}
	}
}
