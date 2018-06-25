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
	[Range(1f, 100f)]
    private float _moveSpeed = 15f;
	private float _moveDirection;

	private float _rightConstraint;
    private float _leftConstraint;
	
	//Store the Donut's animator
	private AnimHelper _animHelper;


	[SerializeField]
	public int Score;
	private TextMeshProUGUI _scoreHUD;

	public bool IsJumping;
	
	InputHandler inh;
	
	
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
	    
	    
	    //Turn back all ye who do not wish a painful death - Will
	    
	    //Initialise Input handler
	    inh = GameObject.Find("Player").AddComponent<InputHandler>();
	    
	    //Track Keys
	    inh.TrackInput(KeyCode.Space, InputType.Button);
	    inh.TrackInput(KeyCode.A, InputType.Button);
	    inh.TrackInput(KeyCode.D, InputType.Button);
	    inh.TrackInput(KeyCode.LeftArrow, InputType.Button);
	    inh.TrackInput(KeyCode.RightArrow, InputType.Button);
	    
	    /*//////////////////////////////
	    ///       Define Events      ///
	    //////////////////////////////*/
	    
	    //Move Left
	    inh.AddEvent(KeyCode.LeftArrow, InputEventType.Down, delegate (InputData inp)
	    {
		    _moveDirection = -1f;
		    _animHelper.Donut_BeginMoveLeft_Start(0f);
	    });
	    inh.AddEvent(KeyCode.LeftArrow, InputEventType.Up, delegate (InputData inp) { if (_moveDirection == -1f) _moveDirection = 0f; });
	    
	    inh.AddEvent(KeyCode.A, InputEventType.Down, delegate (InputData inp)
	    {
		    _moveDirection = -1f;
		    _animHelper.Donut_BeginMoveLeft_Start(0f);
	    });
	    inh.AddEvent(KeyCode.A, InputEventType.Up, delegate (InputData inp) { if (_moveDirection == -1f) _moveDirection = 0f; });
	    
	    //Move Right
	    inh.AddEvent(KeyCode.RightArrow, InputEventType.Down, delegate (InputData inp)
	    {
		    _moveDirection = 1f;
		    _animHelper.Donut_BeginMoveRight_Start(0f);
	    });
	    inh.AddEvent(KeyCode.RightArrow, InputEventType.Up, delegate (InputData inp) { if (_moveDirection == 1f) _moveDirection = 0f; });
	    
	    inh.AddEvent(KeyCode.D, InputEventType.Down, delegate (InputData inp)
	    {
		    _moveDirection = 1f;
		    _animHelper.Donut_BeginMoveRight_Start(0f);
	    });
	    inh.AddEvent(KeyCode.D, InputEventType.Up, delegate (InputData inp) { if (_moveDirection == 1f) _moveDirection = 0f; });
	    
	    //Jump
	    inh.AddEvent(KeyCode.Space, InputEventType.Down, delegate (InputData inp)
	    {
		    if (!IsJumping)
		    {
				_animHelper.Donut_Jump_Start(0f);
			}
	    });
    }


    void Update ()
    {
		
	    //Update the score counter.
	    _scoreHUD.text = Score.ToString();
	    
	    //Move the donut
	    transform.Translate
	    (
		    Mathf.Clamp(transform.position.x + (_moveSpeed * Time.deltaTime * _moveDirection), _leftConstraint, _rightConstraint) - transform.position.x, 
		    0, 
		    0
	    );

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

}
