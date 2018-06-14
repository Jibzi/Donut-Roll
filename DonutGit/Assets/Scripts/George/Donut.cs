using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Donut : MonoBehaviour
{
    private Vector3 SpinSpeed;

	[SerializeField]
    private float moveSpeed;    //Luke: 20f
    [SerializeField]
    private float spinSpeed;    //George: 225f
    //
    [SerializeField][Tooltip("Distance the path's centre to the right, at which the donut is stopped from going out of bounds. ")]
	private float rightConstraint;
    private float leftConstraint;
	
	//Store the Donut's animator
	private AnimHelper _animHelper;

    // Use this for initialization
    void Start()
    {

	    _animHelper = this.GetComponent<AnimHelper>();
	    
        leftConstraint = -5;
        rightConstraint = 5f;
    }




    // Update is called once per frame
    void Update ()
	{

        SpinSpeed.x = (Time.deltaTime * spinSpeed); 

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			if (transform.position.x < leftConstraint)
			{
				transform.position.Set(leftConstraint, transform.position.y, transform.position.z);
			}
			else
			{
				transform.Translate(-moveSpeed * Time.deltaTime, 0,0);
			}
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			if (transform.position.x > rightConstraint)
			{
				transform.position.Set(rightConstraint, transform.position.y, transform.position.z);
			}
			else
			{
				transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
			}

		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_animHelper.DonutJumpStart(0f);
		}
	}
}
