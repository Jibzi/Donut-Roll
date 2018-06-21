/*
  Input Handler
  
  Will Chapman
  14/06/2018
  20/06/2018
  
    
  Now Works!
  Need to add other input types in future
  
  Input Handler will track user input for you and enable you to request data on
  which keys are currently pressed.
  
  Create a new handler, then add keys to be tracked. You can inspect the status of these keys at any time, and add
  events to fire when the lkey is pressed, goes up, or on every frame.
  
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
  Changed,
  Update
}

// A blank delegate to insert anonymous methods with
public delegate void Function(InputData input);

//Class containing all the data for a single input instance
public class InputData
{
  //initialise variables
  
  //The string of the input
  private string     input;
  //The type of the input
  private InputType  type;
  //The position of the input
  private float[]    position;
  //The delta position between last frame and this frame
  private float[]    positionDelta;
  //The time the key has been in its current position
  private float      positionTime;
  //The total time the key has been tracked for
  private float      timeTracked;
  //The timestamp of the last update
  private float      lastUpdate;
    
  //Constructor takes input identifier, input type, and input position
  public InputData(string _keyIdentifier, InputType _type, float[] _position )
  {
    input        =   _keyIdentifier;
    type         =   _type;
    position     =   _position;
    positionTime =   0;
    timeTracked  =   0;
    lastUpdate   =   Time.time;
  }
  
  //The string of the input
  public string Input
  {
    get { return input; }
    set { /*readonly*/ Debug.LogWarning("Cannot set INPUT of " + input + " Property is readonly"); }
  }
  
  //The type of the input
  public InputType Type
  {
    get { return type; }
    set { /*readonly*/ Debug.LogWarning("Cannot set TYPE of " + input + " Property is readonly"); }
  }
  
  //The position of the input
  public float[] Position
  {
    get { return position; }
    set { /*readonly*/ Debug.LogWarning("Cannot set POSITION of " + input + " Property is readonly"); }
  }
  
  //The delta position between last frame and this frame
  public float[] PositionDelta
  {
    get { return positionDelta; }
    set { /*readonly*/ Debug.LogWarning("Cannot set POSITIONDELTA of " + input + " Property is readonly"); }
  }
  
  //The time the key has been in its current position
  public float PositionTime
  {
    get { return positionTime; }
    set { /*readonly*/ Debug.LogWarning("Cannot set POSITIONTIME of " + input + " Property is readonly"); }
  }
  
  //The total time the key has been tracked for
  public float TimeTracked
  {
    get { return timeTracked; }
    set { /*readonly*/ Debug.LogWarning("Cannot set TIMETRACKED of " + input + " Property is readonly"); }
  }
  
  //The timestamp of the last update
  public float LastUpdate
  {
    get { return lastUpdate; }
    set { /*readonly*/ Debug.LogWarning("Cannot set LASTUPDATE of " + input + " Property is readonly"); }
  }
  
  //The time delta between the last update and now
  public float UpdateDelta
  {
    get { return Time.time - LastUpdate; }
    set { /*readonly*/ Debug.LogWarning("Cannot set UPDATEDELTA of " + input + " Property is readonly"); }
  }
  
  //Called by InputHandler, should not really be invoked by user
  public void Update(float[] _newPosition)
  {
    //Update position delta
    positionDelta[0] = _newPosition[0] - Position[0];
    positionDelta[1] = _newPosition[1] - Position[1];
    //Update position
    position = _newPosition;
    //Update Position Time
    if (positionDelta[0] == 0 && positionDelta[1] == 0)
    {
      positionTime += Time.deltaTime;
    }
    //Update Time Tracked
    timeTracked += Time.deltaTime;
    //Update LastUpdate
    lastUpdate = Time.time;
  }
      
}

/*
The main class. Should only be instantiated once; will track all input for you, make requests to it
Only use one otherwise the redundant duplicates will just eat memory and CPU time.
*/
class InputHandler : MonoBehaviour
{
  
  //Initialise variables
  private bool                             touchScreen       =   false;
  private Dictionary<string, InputData>    inputDict         =   new Dictionary<string, InputData>();
  private Dictionary<string, Function>     downEventDict     =   new Dictionary<string, Function>();
  private Dictionary<string, Function>     upEventDict       =   new Dictionary<string, Function>();
  private Dictionary<string, Function>     changedEventDict  =   new Dictionary<string, Function>();
  private Dictionary<string, Function>     updateEventDict   =   new Dictionary<string, Function>();
  
  //Constructor creates an input handler
  public InputHandler()
  {
    
  }
  
  //Method to add input to the dictionary for tracking
  public void TrackInput(string _keyIdentifier, InputType _inputType)
  {
    inputDict.Add(
      _keyIdentifier,
      new InputData(_keyIdentifier, _inputType, new float[] {1,0})
    );
  }
  
  //Method to remove input from the dictionary
  public void IgnoreInput(string _keyIdentifier)
  {
    if (inputDict.ContainsKey(_keyIdentifier))
    {
      inputDict.Remove(_keyIdentifier); 
    }
  }

  //Method to get status of a certain key
  public InputData GetState(string _keyIdentifier)
  {
    return this.inputDict[_keyIdentifier];
  }
  
  //Method to get just position of a certain key
  float[] Position(string _keyIdentifier)
  {
    return this.inputDict[_keyIdentifier].Position;
  }
  
  //Method to add a custom event function to be fired when a key goes down, up or each frame
  //Event function will have the InputData for that key passsed to it as the first argument when fired
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
      case InputEventType.Changed:
        changedEventDict.Add(_keyIdentifier, _function);
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
          if (Input.GetKey(input.Value.Input))
          {
            //Key Down
            if (inputDict[input.Key].Position[0] == 0)
            {
              //Key down for first time
              Console.WriteLine("Key [{0}] Down", input.Key);
              if (downEventDict.ContainsKey(input.Key))
              {
                Console.WriteLine("Key Down Event Firing:");
                downEventDict[input.Key](input.Value);
              }
            }
          }
          else
          {
            //Key Up
            if (inputDict[input.Key].Position[0] == 1)
            {
              //Key up for first time
              Console.WriteLine("Key [{0}] Up", input.Key);
              if (upEventDict.ContainsKey(input.Key))
              {
                Console.WriteLine("Key Up Event Firing:");
                upEventDict[input.Key](input.Value);
              }
            }
          }
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
          Debug.LogWarning("INPUT SYSTEM ERROR \"Update\": key["+input.Key+"] has invalid type");
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















