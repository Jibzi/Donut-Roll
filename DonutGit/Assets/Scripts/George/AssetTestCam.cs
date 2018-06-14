using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Author: George
//
//Simple first person camera controls for the art asset testing scene, where the prefabs can be made without 
//interfering with the main game scene.
//This scipt is very janky, but it works well enough for what it is.
//

public class AssetTestCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(-5 * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(5 * Time.deltaTime,0,0);
		}

		if (Input.GetKey(KeyCode.Space))
		{
			transform.Translate(0, 5 * Time.deltaTime, 0);
		}
		
		if (Input.GetKey(KeyCode.LeftControl))
		{
			transform.Translate(0, -5 * Time.deltaTime, 0);
		}
		
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, 5 * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, 0, -5 * Time.deltaTime);
		}
		
		float sensitivity = 0.05f;
		Vector3 vp = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
		vp.x -= 0.5f;
		vp.y -= 0.5f;
		vp.x *= sensitivity;
		vp.y *= sensitivity;
		vp.x += 0.5f;
		vp.y += 0.5f;
		Vector3 sp = Camera.main.ViewportToScreenPoint(vp);
 
		Vector3 v = Camera.main.ScreenToWorldPoint(sp);
		transform.LookAt(v, Vector3.up);
		
	}
}
