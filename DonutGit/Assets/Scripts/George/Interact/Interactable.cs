using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //
    //Author: George
    //        Will
    //       
    //Purely to set the structor of children that inherit from this, so that unique scripts can be called all through 
    //this one virtual function.
    //

    //The AudioManager and SpellEffects
    protected AudioManager AMa;
    protected SpellEffects SpEf;
    
    //Variables
    protected int points;
    protected string sound;
    protected float shake;

    public void Start()
    {
        AMa = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        SpEf = GameObject.Find("Player").GetComponent<SpellEffects>();
    }

    public void Interact(Donut interactor)
    {
        //Add points
        interactor.Score += points;
        
        //Play sound
        AMa.Play(sound);

        //Do visuals
        Camera.main.GetComponent<ChappersCam>().Shake(shake);
        
        //Call Unique
        Unique(interactor);
    }

    protected virtual void Unique(Donut interactor)
    {
        
    }
}
