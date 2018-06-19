using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gcol : MonoBehaviour
{

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
				
		if (_gCollManager.CheckCol(transform.position, _myWidth))
		{
			
			Debug.Log("There was a gColl!" + transform.position.x);
			
			GameObject.Destroy(this.gameObject);
		}
	}
}
