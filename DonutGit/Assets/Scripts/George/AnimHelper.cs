using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHelper : MonoBehaviour {

    //
    //Author: George
    //
    //Script that acts as a middle-man for calling animations.
    //Mainly this adds the ability to define a delay before playing the animation, as well as having easier to read
    //function names for the animations.
    //This system leverages coroutines to allow for the delay without pausing the game.
    //Taken from an old project.
    //
    
    //TO USE: Each animation needs two functions.
    //Firstly a public void that takes a float, which is the desired delay in seconds. Naming convention Actor_AnimName_Start().
    //Secondly a private IEnumerator that takes the same float as above, as well as an Animator component. Naming Convention: Actor_AnimName_Play().


    #region Jump
    public void Donut_Jump_Start(float Sdelay)
    {
        
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(Donut_Jump_Play(Sdelay, animator));
    }

    
    private IEnumerator Donut_Jump_Play(float delay, Component animator)
    {
        
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("Jump", -1, 0.0f);
    }
    #endregion

    #region BeginMoveLeft
    public void Donut_BeginMoveLeft_Start(float Sdelay)
    {
        
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(Donut_BeginMoveLeft_Play(Sdelay, animator));
    }

    
    private IEnumerator Donut_BeginMoveLeft_Play(float delay, Component animator)
    {
        
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("BeginMovingLeft", -1, 0.0f);
    }
    #endregion

    #region BeginMoveRight
    public void Donut_BeginMoveRight_Start(float Sdelay)
    {
        
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(DonutMoveRight_Play(Sdelay, animator));
    }

    
    private IEnumerator DonutMoveRight_Play(float delay, Component animator)
    {
        
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("BeginMovingRight", -1, 0.0f);
    }
    #endregion

    #region Death

    public void Donut_Death_Start(float Sdelay)
    {
        
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(Donut_Death_Play(Sdelay, animator));
    }

    
    private IEnumerator Donut_Death_Play(float delay, Component animator)
    {
        
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("Death", -1, 0.0f);
    }

    #endregion
}
