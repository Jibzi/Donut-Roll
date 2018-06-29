using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyWobble : MonoBehaviour {

	
	[Tooltip("How quickly the coin wobbles up and down. Recommended : 6.")]
	[Range(0, 10)]
	[SerializeField]
	private float WobbleFrequency;

	[Tooltip("How much the coin wobbles up and down. Recommended: 60.")]
	[Range(0, 20)]
	[SerializeField]
	private float WobbleAmplitude;
	
	// Use this for initialization
	void Start ()
	{

		WobbleAmplitude /= 3f;
		WobbleFrequency /= 10f;
	}
	
	// Update is called once per frame
	void Update () {
		
		var newPos = new Vector3(
			transform.position.x, 
			transform.position.y + ((Mathf.Sin(Time.time * WobbleFrequency) * WobbleAmplitude)),
			transform.position.z);
		
		transform.position = newPos;
	}
}
