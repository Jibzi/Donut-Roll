using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    private Vector3 SpinSpeed;

	[SerializeField]
    private float moveSpeed;    //Luke: 20f
    [SerializeField]
    private float spinSpeed;    //George: 225f

    [SerializeField]
	private float leftConstraint;
    [SerializeField]
	private float rightConstraint;

    // Use this for initialization
    void Start()
    {
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
     
		transform.Rotate(SpinSpeed);
	}


}
