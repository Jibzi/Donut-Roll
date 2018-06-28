using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestComponent : MonoBehaviour
{

	private WorldMover _worldMover;
	
	// Use this for initialization
	void Start () {
		_worldMover = GameObject.Find("Road").GetComponent<WorldMover>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(0,0, (-_worldMover.WorldSpeed * Time.deltaTime));

		//Teleport any road parts that are behind the camera to the far end of the road.
		if (this.transform.position.z < -40f)
		{

			this.transform.Translate(0, 0, 160);
		}
	}
}
