using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

//
//Author: George
//
//Script that builds the road out of road parts. Simple loop that instantiates prefab road parts.
//

public class BuildRoad : MonoBehaviour
{

	public GameObject _roadPart;

	private int _roadLength;

	
	// Use this for initialization
	void Start ()
	{

		//Tune the road length here. Updated to 7 to allow for Road behind camera - Will
		_roadLength = 8;
		
		MakeTheRoad();
	}

	private void MakeTheRoad()
	{
		var _forests = gameObject.GetComponentInChildren<TreeSpawner>()._trees;

		for (int j = 0; j < _roadLength; j++)
		{
			var rObj = Instantiate(_roadPart, new Vector3(0, 0, j * 20), Quaternion.identity, transform);

			var rnd = Random.Range(0, 1);

			Instantiate(_forests[rnd], new Vector3(0, 1, j * 21), Quaternion.identity);
		}
	}
}
