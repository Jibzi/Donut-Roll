using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //
    //Author: George
    //       
    //Purely to set the structor of children that inherit from this, so that unique scripts can be called all through 
    //this one virtual function.
    //

    //The AudioManager
    protected AudioManager AMa;
    protected SpellEffects SpEf;

    public void Start()
    {

        AMa = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        SpEf = GameObject.Find("Player").GetComponent<SpellEffects>();
    }

    public virtual void Interact(Donut interactor)
    {
        
    }
}
