using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoWarp : MonoBehaviour
{

	private float _x = 0f;
	private float _y = -15f;
	private float _falloff = 0f;

	private Vector3 _lastWarp;

	private Camera _cam;
	
	// Use this for initialization
	void Start ()
	{
		_lastWarp = new Vector3(0,0,0);
		
		
		var wb = GameObject.Find("Bender");
		var wbs = wb.GetComponent<WorldBender>();
		_x = wbs.X * 0.0001f;
		_y = wbs.Y * 0.0001f;
		_falloff = wbs.Falloff;
		
		
		_cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(-_lastWarp.x, -_lastWarp.y, -_lastWarp.z);
		
		
		transform.Translate( 
			PsWarpY(transform.position.y),
			PsWarpX(transform.position.x),
			0
			);
			
	}

	private float PsWarpX(float pos)
	{
		Debug.Log("PsWarpX");
		Debug.Log("X: " + _x);


		if (_x != 0f)
		{

			Debug.Log("pos: " + pos);

			var dist = Vector3.Distance(transform.position, _cam.transform.position);
			Debug.Log("Distance: " + dist);

			dist = Mathf.Max(0, dist - _falloff);
			Debug.Log("Distnace maxxed: " + dist);

			dist = dist * dist;
			Debug.Log("Distance squared: " + pos);

			dist = dist * _x;
			
			_lastWarp.x = dist;

			return dist;
		}
		else
		{
			_lastWarp.x = 0;
			return 0;
		}

	}
	
	private float PsWarpY(float pos)
	{
		Debug.Log("PsWarpY");
		Debug.Log("Y: " + _y);
		
		if (_y != 0)
		{
			Debug.Log("pos: " + pos);

			var dist = Vector3.Distance(transform.position, _cam.transform.position);
			Debug.Log("Distance: " + dist);

			dist = Mathf.Max(0, dist - _falloff);
			Debug.Log("Distnace maxxed: " + dist);

			dist = Mathf.Pow(dist, 2f);
			Debug.Log("Distance squared: " + dist);

			dist = dist * _y;

			_lastWarp.y = dist;
			return dist;
		}
		else
		{
			_lastWarp.y = 0;
			return 0;
		}

	}
	
}
