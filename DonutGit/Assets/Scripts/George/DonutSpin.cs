using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Author: George
//
//Script that makes the donut spin, simple.
//

//TODO:Make this more automatic, and rely less on editor input.

public class DonutSpin : MonoBehaviour
{

	private Vector3 _spinSpeed;
	private WorldMover _worldMover;

	public float SpinSpeed;
	
	// Use this for initialization
	void Start ()
	{

		_worldMover = GameObject.Find("Road").GetComponent<WorldMover>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		_spinSpeed.y = SpinSpeed * Time.deltaTime;
		
		transform.Rotate(_spinSpeed * (_worldMover.WorldSpeed / 10));
	}
}
