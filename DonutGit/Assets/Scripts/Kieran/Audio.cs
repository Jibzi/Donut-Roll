using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //Global volume of all music in the scene.
    [HideInInspector]
    public float globalMusicalVolume = 10;  
    
 
    //Name of sound
    public string name;
    //Clip to be used
    public AudioClip clip;
    //Clip's volume
    [Range(0f, 1f)]
    public float volume;
    //Clip's pitch
    [Range(0.1f, 3f)]
    public float pitch;
    //Clip's source
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