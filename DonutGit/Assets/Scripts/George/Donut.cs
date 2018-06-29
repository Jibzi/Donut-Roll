using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
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
	private WorldMover _worldMover;


	[SerializeField]
	public int Score;
	private TextMeshProUGUI _scoreHUD;

	public bool IsJumping;
	public bool IsDead;
	
	private KeyMapManager inp;
	private PauseMenu pauser;


	void Start()
	{

		//Initialise the score and UI to display it.
		Score = 0;
		_scoreHUD = GameObject.Find("HUDCanvas").GetComponentInChildren<TextMeshProUGUI>();

		//Grab the AnimHelper, adds some functionality to calling animations.
		_animHelper = this.GetComponent<AnimHelper>();
		
		//Grab world mover
		_worldMover = GameObject.Find("Road").GetComponent<WorldMover>();

		//Initialise the left and right constrains, or "walls".
		_leftConstraint = -5f;
		_rightConstraint = 5f;

		//Communicate to the "ChappersCam" that we want that script enabled.
		Camera.main.GetComponent<ChappersCam>().RunCamera = true;

		//Initialise IsJumping.
		IsJumping = false;
		
		//Initialise IsDead.
		IsDead = false;

		//Initialise pauser
		pauser = new PauseMenu();
		
		//Turn back all ye who do not wish a painful death - Will

		
		//Initialise KeyMap Manager
		inp = GameObject.Find("InputSystem").GetComponent<KeyMapManager>();
		
		//Create Virtual Keys
		inp.AddVirtualButton("Jump");
		inp.AddVirtualButton("Left");
		inp.AddVirtualButton("Right");
		inp.AddVirtualButton("Pause");
		
		//Create keymap
		inp.AddMap("Default");
		inp.SetTo("Default");

		//Map real keys to virtual keys
		inp.Map().AddKey("Jump", KeyCode.Space, InputType.Button);
		inp.Map().AddKey("Left", KeyCode.A, InputType.Button);
		inp.Map().AddKey("Left", KeyCode.LeftArrow, InputType.Button);
		inp.Map().AddKey("Right", KeyCode.D, InputType.Button);
		inp.Map().AddKey("Right", KeyCode.RightArrow, InputType.Button);
		//inp.Map().AddKey("Pause", KeyCode.P, InputType.Button);
		//inp.Map().AddKey("Pause", KeyCode.Escape, InputType.Button);

		
		
		/*//////////////////////////////
		///       Define Events      ///
		//////////////////////////////*/

		//Move Left
		inp.AddEvent("Left", InputEventType.Down, delegate(InputData inp)
		{
			_moveDirection = -1f;
			if (!IsDead) _animHelper.Donut_BeginMoveLeft_Start(0f);
		});
		inp.AddEvent("Left", InputEventType.Up, delegate(InputData inp)
		{
			if (_moveDirection == -1f) _moveDirection = 0f;
		});
		
		//Move Right
		inp.AddEvent("Right", InputEventType.Down, delegate(InputData inp)
		{
			_moveDirection = 1f;
			if (!IsDead) _animHelper.Donut_BeginMoveRight_Start(0f);
		});
		inp.AddEvent("Right", InputEventType.Up, delegate(InputData inp)
		{
			if (_moveDirection == 1f) _moveDirection = 0f;
		});

		//Jump
		inp.AddEvent("Jump", InputEventType.Down, delegate(InputData inp)
		{
			if (!IsJumping && !IsDead)
			{
				_animHelper.Donut_Jump_Start(0f);
			}
		});
		
		//Pause
		inp.AddEvent("Pause", InputEventType.Down, delegate(InputData inp)
		{
			if (!IsDead)
			{
				if (pauser.IsPaused)
				{
					pauser.Unpause();
				}
				else
				{
					pauser.Pause();
				}
			}
		});
	}


	void Update ()
    {
		
	    //Update the score counter.
	    _scoreHUD.text = Score.ToString();

	    
	    //Move the donut if running, if not then finish killing the donut
	    if (_worldMover.WorldSpeed > 0)
	    {
		    transform.Translate
		    (
			    Mathf.Clamp(transform.position.x + (_moveSpeed * Time.deltaTime * _moveDirection), _leftConstraint, _rightConstraint) - transform.position.x, 
			    0, 
			    0
		    );
	    }
	    else if (!IsDead)
	    {
		    IsDead = true;
		    _animHelper.Donut_Death_Start(0f);
	    }

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
			if (other.GetComponent<Interactable>() != null)
			{
				other.GetComponent<Interactable>().Interact(this);
			}
		}
	}

}
