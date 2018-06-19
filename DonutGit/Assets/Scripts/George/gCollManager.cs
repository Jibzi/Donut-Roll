using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class gCollManager : MonoBehaviour
{
	
	//
	//Author: George
	//
	//Script that acts as a hub for all gCol components.
	//Contains the CheckCol method that gCol components call in order to check for collisions between themselves
	//and the player.
	//

	public GameObject PlayerGO;
	private float[] _ZBand = new float[2] {-5f, -7f};
	private float _XWidth = 0.75f;

	public Dictionary<string, float> DICTwidth = new Dictionary<string, float>();

	public bool CheckCol(Vector3 position, float width, string name)
	{
		return Collision(position, DICTwidth[name]);
	}

	private bool Collision(Vector3 position, float width)
	{
				
		if (position.z < _ZBand[0])
		{
			//Debug.Log("Check 1 passed.");

			if (position.z > _ZBand[1])
			{
				//Debug.Log("Check 2 passed.");

				//Left check
				if ((position.x + width) > (PlayerGO.transform.position.x - _XWidth))
				{
					//Debug.Log("Check 3 passed.");

					if ((position.x - width) < (PlayerGO.transform.position.x + _XWidth))
					{
						//Debug.Log("Check 4 passed.");

						return true;
					}

					return false;
				}

				return false;
			}

			return false;
		}

		return false;
	}

	public void Start()
	{
		PlayerGO = GameObject.Find("Player");

		DICTwidth.Add("CurlyWurly", 2.6f);
	}

	public void Update()
	{
		
	}
}
