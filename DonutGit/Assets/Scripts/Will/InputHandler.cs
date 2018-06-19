/*
  Input Handler
  
  Will Chapman
  14/06/2018
  19/06/2018
  
  NOT READY FOR USE
  
  Events now work <3
  Need to reconfig InputHandler.Update to go through keys on a list to check, chcek them, then update inputDict as needed.
  Possibly add MonoBehaviour Update to InputData for this?
  
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
  
  Syntax for adding events to key presses is:
  InputHandler.AddEvent(string key, 
    
    delegate (InputData input) //"input" is recommended argument name
            {
                //code
            }

    );
  
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

//Enum describing the input event type
public enum InputEventType
{
  Down,
  Up,
  Update
}

// A blank delegate to insert anonymous methods with
public delegate void Function(InputData input);

//Class containing all the data for a single input instance
public class InputData
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
    //this.positionDelta = Time.time - this.positionDelta;
    this.lastUpdate = Time.time;
    this.timeDown += this.updateDelta;
  }
      
}

/*The main class. Should only be instantiated once; will track all input for you, make requests to it

Only use one otherwise the redundant duplicates will just eat memory and CPU time.
*/
class InputHandler : MonoBehaviour
{
  
  //Initialise variables
  private bool                             touchScreen       =   false;
  private Dictionary<string, InputData>    inputDict         =   new Dictionary<string, InputData>();
  private Dictionary<string, Function>     downEventDict     =   new Dictionary<string, Function>();
  private Dictionary<string, Function>     upEventDict       =   new Dictionary<string, Function>();
  private Dictionary<string, Function>     updateEventDict   =   new Dictionary<string, Function>();
  
  /*
   Constructor creates an input handler
      
   _enableTouchScreen and _enableAccelerometer can be set to true if you want the Input Handler to track touches and
   gyro movements by default, otherwise you will have to enable it later manually.
  */
  public InputHandler()
  {
    
  }
  
  public InputHandler(bool _enableTouchScreen, bool _enableAccelerometer)
  {
    
  }
  
  //Method to add input to the dictionary for tracking
  public void TrackInput(string _keyIdentifier)
  {
    inputDict.Add(
      _keyIdentifier,
      new InputData(_keyIdentifier, InputType.Button, new float[] {1,0})
    );
  }

  //Method to get status of a certain key
  public InputData GetState(string _keyIdentifier)
  {
    return this.inputDict[_keyIdentifier];
  }
  
  // A custom event function to be fired when a key is pressed or input changes
  // First argument will be the InputData for that key, second defines when the event fires
  public void AddEvent(string _keyIdentifier, InputEventType _eventType, Function _function)
  {
    switch (_eventType)
    {
      case InputEventType.Down:
        downEventDict.Add(_keyIdentifier, _function);
        break;
      case InputEventType.Up:
        upEventDict.Add(_keyIdentifier, _function);
        break;
      case InputEventType.Update:
        updateEventDict.Add(_keyIdentifier, _function);
        break;
      default:
        Console.WriteLine("INPUT SYSTEM ERROR \"AddEvent\": event has invalid type");
        break;
    }
  }
  
  //Updates every input once per frame
  private void Update ()
  {
    foreach(KeyValuePair<string, InputData> input in inputDict)
    {
      // do something with input.Value or input.Key
      Console.WriteLine("Updating Input Dictionary [{0}]: {1}", input.Key, input.Value);
      
      switch (input.Value.Type)
      {
        case InputType.Button:
          /*
          if (UnityInput.KeyIsDown(input.Key))
          {
            if (!inputDict.ContainsKey(input.Key))
            {
              Console.WriteLine("Key [{0}] Down", input.Key);
              if (downEventDict.ContainsKey(input.Key))
              {
                Console.WriteLine("Key Down Event Firing:");
                upEventDict[input.Key](input.Value);
              }
            }            
          }
          else
          {
            //Key no longer down, remove from input
            inputDict.Remove(input.Key);
            Console.WriteLine("Key Up Firing:");
            if (upEventDict.ContainsKey(input.Key))
            {
              Console.WriteLine("Key Up Event Firing:");
              upEventDict[input.Key](input.Value);
            }
          }
          */
          break;
        case InputType.Axis:
          /*
           input.Value.Position[0] = UnityInput.GetAxisPos(input.Key)[0];
           */
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
          Console.WriteLine("INPUT SYSTEM ERROR \"Update\": key[{0}] has invalid type", input.Key);
          break;
      }
      
      //Do this last so it goes in order: Down, Update(*n) Up
      if (updateEventDict.ContainsKey(input.Key))
      {
        Console.WriteLine("Event Firing:");
        updateEventDict[input.Key](input.Value);
      }
      
    }
  }
}
















