using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    private float horizontalMovement;
    private Vector3 SpinSpeed;
    //The points between which the donut's left-to-right movement is constrained
    public float 
        leftConstraint,
        rightConstraint;
    private Vector2 HorizontalConstraints;
    private bool donutNeedsToStop;

    // Use this for initialization
    void Start()
    {
        HorizontalConstraints = new Vector2(leftConstraint, rightConstraint);
        SpinSpeed = new Vector3(0, 0, 0);
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    void ClampHorizontalMovement()
    {
        if (donutNeedsToStop)
        {

        }
    }

    void GetInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    void MoveSideways()
    {
        this.transform.Translate(new Vector3(horizontalMovement,0,0));
    }



    // Update is called once per frame
    void Update ()
	{
		SpinSpeed.x = (Time.deltaTime * 225f);
        donutNeedsToStop = this.transform.position.x > leftConstraint || this.transform.position.x < rightConstraint;
        GetInput();
        MoveSideways();
		this.transform.Rotate(SpinSpeed);
	}


}
