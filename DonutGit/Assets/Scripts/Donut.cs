using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    private Vector3 SpinSpeed;

	[SerializeField] private float MoveSpeed;

	private float leftConstraint = -5f;
	private float rightConstraint = 5f;

    // Use this for initialization
    void Start()
    {

    }




    // Update is called once per frame
    void Update ()
	{

        SpinSpeed.x = (Time.deltaTime * 225f); //225f

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (transform.position.x < leftConstraint)
			{
				transform.position.Set(leftConstraint, transform.position.y, transform.position.z);
			}
			else
			{
				this.transform.Translate(-MoveSpeed * Time.deltaTime, 0,0);
			}

		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (transform.position.x > rightConstraint)
			{
				transform.position.Set(rightConstraint, transform.position.y, transform.position.z);
			}
			else
			{
				this.transform.Translate(MoveSpeed * Time.deltaTime, 0,0);
			}

		}
     
		this.transform.Rotate(SpinSpeed);
	}


}
