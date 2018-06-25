using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_CurlyWurly : Interactable
{
    
        
    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);
        this.isCollectable = false;
        AudioManager AMa = base.AMa;

        //Do effect
        interactor.Score = 0;

        //Play sound
        PlayTypeSound();

        //Do visuals
        Camera.main.GetComponent<ChappersCam>().Shake(10f);
        GameObject.Find("Road").GetComponent<WorldMover>().WorldAcceleration = -30;
        GameObject.Find("Player").GetComponent<AnimHelper>().Donut_Jump_Start(0f);
        GameObject.Find("Donut").GetComponent<DonutSpin>().SpinSpeed = 0f;
        AMa.Play(AMa.sounds[3].ToString());
            
        
        //Don't destroy self
        Triggerable = false;
        //Destroy(gameObject);
    }
}
