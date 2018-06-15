using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PostProcessing;

//
//Author: George
//
//Adds user input to the donut. Handles left and right movement, and jumping. Contrains the player to the road.
//Also handles playing certain animations, like jump.
//

public class Donut : MonoBehaviour
{

	[SerializeField]
	[Range(0, 90)]
	public float SwayLimit = 90f;
	
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
	private float _coEf;

	private GameObject _donutGraphics;
	
	
    void Start()
    {

	    _animHelper = this.GetComponent<AnimHelper>();
	    
	    _donutGraphics = GameObject.Find("CharacterModel");
	    
        _leftConstraint = -5;
        _rightConstraint = 5f;
    }


    // Update is called once per frame
    void Update ()
    {
	    
	    _isLeftMoving = false;
	    _isRightMoving = false;

	    DonutControl();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			
			_animHelper.DonutJumpStart(0f);
		}

	    if (_isLeftMoving &&  !_oldLeft)
	    {
		    _animHelper.DonutMoveLeftStart(0f);
	    }

	    if (_isRightMoving && !_oldRight)
	    {
		    _animHelper.DonutMoveRightStart(0f);
	    }

	    _oldLeft = _isLeftMoving;
	    _oldRight = _isRightMoving;
    }

	
//Method that handles basic player input to move the donut.
	private void DonutControl()
	{

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
