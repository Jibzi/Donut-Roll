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

    public IEnumerator DonutJumpPlay(float delay, Component animator)
    {
        print("DonutJumpPlay");
        yield return new WaitForSeconds(delay);
        
        animator.GetComponent<Animator>().Play("DonutJump", -1, 0.0f);
    }
}
