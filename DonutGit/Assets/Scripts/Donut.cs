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
    private bool hasMovedTooFarLeft;
    private bool hasMovedTooFarRight;
    [SerializeField]
    private float sidewaysSpeed;

    // Use this for initialization
    void Start()
    {
        leftConstraint = -5;
        rightConstraint = 5;
        HorizontalConstraints = new Vector2(leftConstraint, rightConstraint);
        horizontalMovement = Input.GetAxis("Horizontal");
        hasMovedTooFarLeft = this.transform.position.x < leftConstraint;
        hasMovedTooFarRight = this.transform.position.x > rightConstraint;
    }

    /*A method to clamp the movement on X between the left and right constraints. Though, for now
    I will use the far less optimised box colliders to get the prototype working.*/
    void ClampHorizontalMovement()
    {
        //If the donut has moved too far right:
        if (hasMovedTooFarLeft)
        {
            //Only allow the donut to move to the right.
            //horizontalMovement = Mathf.Clamp01(horizontalMovement);
            Mathf.Clamp(this.transform.position.x, leftConstraint, rightConstraint);
            //Move the donut
            MoveSideways();
        }
        //Else if the donut has moved too far right:
        if (hasMovedTooFarRight)
        {
            //Only allow the donut to move to the left
            //horizontalMovement = -Mathf.Clamp01(horizontalMovement);
            //Mathf.Clamp(this.transform.position.x, leftConstraint, rightConstraint);
            //Move the donut
            MoveSideways();
        }
        //Else, the donut is somewhere between the two: (this used to be an else statement, whence its dodgy stucture).
        if (!hasMovedTooFarLeft && !hasMovedTooFarRight)
        {
            //Allow the donut to move either left or right
            ResetHorizontalMovement();
            //Move the donut
            MoveSideways();
        }
    }

    void ResetHorizontalMovement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    void MoveSideways()
    {
        this.transform.Translate(new Vector3(horizontalMovement*Time.deltaTime*sidewaysSpeed,0,0));
    }



    // Update is called once per frame
    void Update ()
	{
        SpinSpeed.x = (Time.deltaTime * 225f); //225f
        ClampHorizontalMovement();
		this.transform.Rotate(SpinSpeed);
	}


}
