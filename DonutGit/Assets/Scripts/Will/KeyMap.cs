/*
  Keymap
  
  Will Chapman
  15/06/2018
  25/06/2018
  
  Create a keymap
  Add virtual buttons
  Add events to the virtual buttons/check their state
  
  ToDo: Add detail to virtual buttons
  ToDo: Update virtual name change to effect keymap dictionary
  ToDo: Update details of virtual buttons on MonoBehaviour.Update()
  ToDo: Connect IH events to virtual button events
  
*/

//Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;


//Holds all stats for a virtual button
//Inherits from Input Data, sets keycode to keyCode.None as not likely to be used anywhere else
class VirtualButton : InputData
{
  
  //The name of the input
  private string name;
  //A list of all the keycodes that contribute to this virtual button 
  private List<KeyCode> keys;
  
  //
  public VirtualButton(string _name, List<KeyCode> _keys) : base (KeyCode.None, InputType.Virtual, new [] {0f, 0f})
  {
    name = _name;
    keys = _keys;
  }

  
  //The name of the input
  public string Name
  {
    get { return name; }
    set { name = value; }
  }

  public void AddKey(KeyCode _key)
  {
    if (keys.Contains(_key))
    {
      Debug.LogWarning("Virtual key \""+ name + "\" already contains this key! Aborting Attempt");
    }
    else
    {
      keys.Add(_key);
    }
  }
  
  public void RemoveKey(KeyCode _key)
  {
    if (keys.Contains(_key))
    {
      keys.Remove(_key);
    }
    else
    {
      Debug.LogWarning("Virtual key \""+ name + "\" does not contain this key! Aborting Attempt");
    }
  }
  
  /*Called by KeyMap, should not really be invoked by user
  public void override Update(float[] _newPosition)
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
  }*/
  
}

//Manages the use of keymaps
class KeyMapManager
{
  
}

//Maps real keys to virtual keys, and connects real key events to their virtual counterparts
//Metaphorically: The class is github, the virtual key is a project, the real keys are contributors
class KeyMap
{
  //Store virtual buttons for this map
  private Dictionary<string, VirtualButton>     virtualButtons    =   new Dictionary<string, VirtualButton>();
  
  //Initialise Event Dictionaries
  private Dictionary<VirtualButton, Function>   downEventDict     =   new Dictionary<VirtualButton, Function>();
  private Dictionary<VirtualButton, Function>   upEventDict       =   new Dictionary<VirtualButton, Function>();
  private Dictionary<VirtualButton, Function>   changedEventDict  =   new Dictionary<VirtualButton, Function>();
  private Dictionary<VirtualButton, Function>   updateEventDict   =   new Dictionary<VirtualButton, Function>();
  
  //Constructor creates a key map
  public KeyMap()
  {
    
  }

  public void AddVirtualButton(string _name, List<KeyCode> _keys)
  {
    if (virtualButtons.ContainsKey(_name))
    {
      Debug.LogWarning("Map already contains virtual key \""+ _name + "\"! Aborting Attempt");
    }
    else
    {
      virtualButtons.Add(_name, new VirtualButton(_name, _keys));
    }
  }
  
  public void RemoveVirtualButton(string _name)
  {
    if (virtualButtons.ContainsKey(_name))
    {
      virtualButtons.Remove(_name);
    }
    else
    {
      Debug.LogWarning("Map Does not contain virtual key \""+ _name + "\"! Aborting Attempt");
    }
  }

  public VirtualButton Virtual(string _name)
  {
    if (virtualButtons.ContainsKey(_name))
    {
      return virtualButtons[_name];
    }
    else
    {
      Debug.LogWarning("Virtual key \""+ _name + "\" does not exist! Aborting Attempt");
      return null;
    }
  }
}