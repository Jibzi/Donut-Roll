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
    float sidewaysSpeed;

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

    void ClampHorizontalMovement()
    {
        //What happens if it goes too far left?
        if (!hasMovedTooFarLeft)
        {
            
        }
        //What happens if it goes too far right?
        if (!hasMovedTooFarRight)
        {
            
        }
    }

    void GetInput()
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




        GetInput();
        
        MoveSideways();
		this.transform.Rotate(SpinSpeed);
	}


}
