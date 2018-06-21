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
    //
    
    //TO USE: Each animation needs two functions.
    //Firstly a public void that takes a float, which is the desired delay in seconds. Naming convention AnimNameStart().
    //Secondly a private IEnumerator that takes the same float as above, as well as an Animator component. Naming Convention: AnimNamePlay().
    
    
    
    public void DonutJumpStart(float Sdelay)
    {
        
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(DonutJumpPlay(Sdelay, animator));
    }

    
    private IEnumerator DonutJumpPlay(float delay, Component animator)
    {
        
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("Jump", -1, 0.0f);
    }
    
    
    public void DonutMoveLeftStart(float Sdelay)
    {
        
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(DonutMoveLeftPlay(Sdelay, animator));
    }

    
    private IEnumerator DonutMoveLeftPlay(float delay, Component animator)
    {
        
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("MovingLeft", -1, 0.0f);
    }
    
    
    public void DonutMoveRightStart(float Sdelay)
    {
        
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(DonutMoveRightPlay(Sdelay, animator));
    }

    
    private IEnumerator DonutMoveRightPlay(float delay, Component animator)
    {
        
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("MovingRight", -1, 0.0f);
    }
}
