using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.PostProcessing;

//
//Author: George
//		  Will
//
//Adds user input to the donut. Handles left and right movement, and jumping. Contrains the player to the road.
//Also handles playing certain animations, like jump.
//


public class Donut : MonoBehaviour
{

	[SerializeField]
	[Range(1f, 100f)]
	public float testShakeAmount = 10f;
	
	[SerializeField]
    private float _moveSpeed;

    [SerializeField][Tooltip("Distance the path's centre to the right, at which the donut is stopped from going out of bounds. ")]
	private float _rightConstraint;
    private float _leftConstraint;
	
	//Store the Donut's animator
	private AnimHelper _animHelper;

	private bool _isLeftMoving;
	private bool _isRightMoving;
	private bool _oldLeft;
	private bool _oldRight;

	[SerializeField]
	public int Score;
	private TextMeshProUGUI _scoreHUD;

	public bool IsJumping;
	
	InputHandler inh = new InputHandler();
	
	
    void Start()
    {
	    
	    //Initialise the score and UI to display it.
	    Score = 0;
	    _scoreHUD = GameObject.Find("HUDCanvas").GetComponentInChildren<TextMeshProUGUI>();

	    //Grab the AnimHelper, adds some functionality to calling animations.
	    _animHelper = this.GetComponent<AnimHelper>();
	    
	    //Initialise the left and right constrains, or "walls".
        _leftConstraint = -5f;
        _rightConstraint = 5f;
	    
	    //Communicate to the "ChappersCam" that we want that script enabled.
	    Camera.main.GetComponent<ChappersCam>().RunCamera = true;

	    //Initialise IsJumping.
	    IsJumping = false;
	    
	    
	    inh.TrackInput(KeyCode.L, InputType.Button);
	    inh.AddEvent(KeyCode.L, InputEventType.Down, delegate (InputData inp){
				Debug.Log("L Pressed");
			    Camera.main.GetComponent<ChappersCam>().Shake(testShakeAmount);
		    }
	    );
    }


    void Update ()
    {
		
	    //Update the score counter.
	    _scoreHUD.text = Score.ToString();

	    DonutControl();

	    //Jump
	    if (!IsJumping)
	    {
		    
		    if (Input.GetKeyDown(KeyCode.Space))
		    {

			    _animHelper.Donut_Jump_Start(0f);
		    }
	    }

	    //Shake
	    if (Input.GetKeyDown(KeyCode.K))
	    {
		    Debug.Log("Shake K");
		    Camera.main.GetComponent<ChappersCam>().Shake(testShakeAmount);
	    }

	    //Shake L IF
	    if (inh.Position(KeyCode.L)[0] == 1f)
	    {
		    Debug.Log("Shake L IF");
		    Camera.main.GetComponent<ChappersCam>().Shake(testShakeAmount);
	    }

	    //Move left.
	    if (_isLeftMoving &&  !_oldLeft)
	    {
		    
		    _animHelper.Donut_BeginMoveLeft_Start(0f);
	    }

	    //Move right.
	    if (_isRightMoving && !_oldRight)
	    {
		    
		    _animHelper.Donut_BeginMoveRight_Start(0f);
	    }

	    //Store our current left and right bools, so we can use the delta between this frame and next frame, on next frame.
	    _oldLeft = _isLeftMoving;
	    _oldRight = _isRightMoving;
    }


	//Where the donut checks for collisions with "Interactables". While jumping, collision checking is turned off.
	//The donut will collide with any collider with the "Is Trigger" option ticked. The donut will then check for
	//any script that derrives from the Interactable class, then call Interact(); on that, meaning many, unique, scripts
	//can all be called through one line of code!
		void OnTriggerEnter(Collider other)
		{
			
			if (!IsJumping)
			{
				
				//Check to see if it's Interactable and CanCollide
				if (other.GetComponent<Interactable>() != null && other.GetComponent<Interactable>().Triggerable)
				{
					other.GetComponent<Interactable>().Interact(this);
				}
			}
		}


//Method that handles basic player input to move the donut.
	private void DonutControl()
	{

		//Reset left and right bools, so they are ready to be set properly below.
		_isLeftMoving = false;
		_isRightMoving = false;
		
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{

			if (transform.position.x < _leftConstraint)
			{

				transform.position.Set(_leftConstraint, transform.position.y, transform.position.z);
				_isLeftMoving = false;
			}

			else
			{

				transform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);
				_isLeftMoving = true;
			}
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{

			if (transform.position.x > _rightConstraint)
			{

				transform.position.Set(_rightConstraint, transform.position.y, transform.position.z);
				_isRightMoving = false;
			}

			else
			{

				transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
				_isRightMoving = true;
			}
		}
	}	
}
