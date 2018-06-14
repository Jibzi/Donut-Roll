﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //Properties will be public, to be reached by other
    //name of sound
    public string name;
    //the clip to be used
    public AudioClip clip;
    //the clip's volume
    [Range(0f, 1f)]
    public float volume;
    //the clip's pitch
    [Range(0.1f, 3f)]
    public float pitch;
    //CAN'T REMEMBER WHAT THIS IS!?
    [HideInInspector]
    public AudioSource source;
    //whether to loop. Defaultly true
    public bool loop = true;
}

[System.Serializable]
public class Music : Sound
{
    //
    public new string name;
    //
    public new AudioClip clip;
    //
    [Range(0f, 1f)]
    public new float volume;
    //
    [Range(0.1f, 3f)]
    public new float pitch;
    //
    [HideInInspector]
    public new AudioSource source;

    public new bool loop;
}


public class Voice : Sound
{
    //
    public new string name;
    //
    public new AudioClip clip;
    //
    [Range(0f, 1f)]
    public new float volume;
    //
    [Range(0.1f, 3f)]
    public new float pitch;
    //
    [HideInInspector]
    public new AudioSource source;

    public new bool loop;
}

public class SFX : Sound
{
    //
    public new string name;
    //
    public new AudioClip clip;
    //
    [Range(0f, 1f)]
    public new float volume;
    //
    [Range(0.1f, 3f)]
    public new float pitch;
    //
    [HideInInspector]
    public new AudioSource source;

    public new bool loop;
}