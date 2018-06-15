/*
  Input Handler
  
  Will Chapman
  14/06/2018
  15/06/2018
  
  NOT READY FOR USE
  
  Updated InputHandler to contain event firing
  
  Input Handler will track user input for you and enable you to request data on
  which keys are currently pressed.
  
  You are able to see which keys are pressed, and for each of those keys enquire:
  The Key itself
  The Key type (A button, trigger, axis, mouse, touch, accelerometer position)
  Its position (simple keys up/down & positions of XBox triggers, axis, etc)
  The position delta between where it is now and where it was last frame
  The time the key has been in that position
  The time that key was last updated by the Input Handler
  The time delta between this update and the last
*/

//Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

//Enum describing the input types
public enum InputType
{
    Button,
    Axis,
    Trigger,
    Mouse,
    Touch,
    Accelerometer
}

// A blank delegate to insert anonymous methods with
public delegate void Function();

//Class containing all the data for a single input instance
class InputData
{
  //initialise variables
  private string     input;
  private InputType  type;
  private float[]    position;
  private float[]    positionDelta;
  private float      timeDown;
  private float      lastUpdate;
  private float      updateDelta;
    
  //Constructor takes input identifier, input type, and input position
  public InputData(string _keyIdentifier, InputType _type, float[] _position)
  {
  this.input        =   _keyIdentifier;
  this.type         =   _type;
  this.position     =   _position;
  this.timeDown     =   0;
  this.lastUpdate   =   Time.time;
  this.updateDelta  =   0;
  }
  
  public string Input
  {
    get { return this.input; }
    set { this.input = value; }
  }
  
  public InputType Type
  {
    get { return this.type; }
    set { this.type = value; }
  }
  
  public float[] Position
  {
    get { return this.position; }
    set { this.position = value; }
  }
  
  public float[] PositionDelta
  {
    get { return this.positionDelta; }
  }
  
  public float TimeDown
  {
    get { return this.timeDown; }
    set { this.timeDown = value; }
  }
  
  public float LastUpdate
  {
    get { return this.lastUpdate; }
  }
  
  public float UpdateDelta
  {
    get { return this.updateDelta; }
  }
  
  public void Update()
  {
    this.updateDelta = Time.time - this.lastUpdate;
    this.positionDelta = Time.time - this.positionDelta;
    this.lastUpdate = Time.time;
    this.timeDown += this.updateDelta;
  }
      
}

//The main class. Should only be instantiated once; will track all input for you, make requests to it
class InputHandler : MonoBehaviour
{
  
  //Initialise variables
  private bool                             touchScreen   =   false;
  private Dictionary<string, InputData>    inputDict     =   new Dictionary<string, InputData>();
  private Dictionary<string, Function>     eventDict     =   new Dictionary<string, Function>();
  
  /*
   Constructor creates an input handler
   Only use one otherwise the redundant duplicates will just eat memory and CPU time.
   _enableTouchScreen and _enableAccelerometer can be set to true if you want the Input Handler to track touches and
   gyro movements by default, otherwise you will have to enable it later manually.
  */
  public InputHandler(bool _enableTouchScreen, bool _enableAccelerometer)
  {
    
  }

  //Method to add input to the dictionary for tracking
  public void AddInput()
  {
    
  }

  //Method to get status of a certain key
  public List<InputData> GetState(string _keyIdentifier)
  {
    return this.inputDict[_keyIdentifier];
  }
  
  // A custom event function to be fired when a key is pressed or input changes
  // First argument will be the InputData for that key
  public void AddEvent(string _keyIdentifier, Function _function)
  {
    eventDict.Add(_keyIdentifier, _function);
  }
  
  //Updates every input once per frame
  private void Update ()
  {
    foreach(KeyValuePair<string, InputData> input in inputDict)
    {
      // do something with input.Value or input.Key
      
      switch (input.Value.Type)
      {
        case InputType.Button:
          /*
          if (UnityInput.KeyIsDown(input.Key))
          {
            
          }
          else
          {
            //Key no longer down, remove from input
            inputDict.Remove(input.Key);
          }
          */
          break;
        case InputType.Axis:
          break;
        case InputType.Trigger:
          break;
        case InputType.Mouse:
          break;
        case InputType.Touch:
          break;
        case InputType.Accelerometer:
          break;
        default:
          Console.WriteLine("INPUT SYSTEM ERROR: key[{0}] has invalid type", input.Key);
          break;
      }
      
    }
  }
}
















