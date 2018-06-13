using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutSpin : MonoBehaviour
{

	private Vector3 _spinSpeed;

	public float SpindSpeed;
	
	// Use this for initialization
	void Start () {
		
		_spinSpeed = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update ()
	{

		_spinSpeed.y = SpindSpeed * Time.deltaTime;
		
		transform.Rotate(_spinSpeed);
	}
}
