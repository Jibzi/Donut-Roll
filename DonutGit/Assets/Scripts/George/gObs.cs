using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gObs : MonoBehaviour {

	//
	//Author: George
	//
	//Class for obstacles. This will be called as a "new" wherever spawning obstacles and collectables.
	//This class will then build unique gColl scripts so that each obstacle can know what itself is and therefore
	//be able to talk to the gCollManager properly
	//

	private gColl _gColl;
	private Vector3 _pos;
	private GameObject _go;

	public gObs(GameObject prefab, string name, Vector3 pos)
	{
		_go = prefab;
		_pos = pos;
		_gColl = gameObject.AddComponent<gColl>();
		_gColl.name = name;
	}
	
	// Use this for initialization
	void Start ()
	{
		Instantiate(_go, _pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
