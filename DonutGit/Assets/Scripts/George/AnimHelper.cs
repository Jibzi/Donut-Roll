using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHelper : MonoBehaviour {

    
    public void DonutJumpStart(float Sdelay)
    {
        
        print("DonutJumpStart");
        Component animator = this.GetComponent<Animator>();
        StartCoroutine(DonutJumpPlay(Sdelay, animator));
    }

    
    private IEnumerator DonutJumpPlay(float delay, Component animator)
    {
        
        print("DonutJumpPlay");
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
