using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Author: George
//
//Helper script that adds game mechanics to the donut without cluttering the donut.cs script, and to optimise 
//the process as opposed to calling these mechanics from Inter_ scripts. This script can grab all of it's
//referneces once and then be told what to do by Inter_ scripts.
//


public class SpellEffects : MonoBehaviour
{

    //References
    private AudioManager _aMa;
    private ChappersCam _chCam;
    private WorldMover _worldMover;
    private AnimHelper _anim;
    private DonutSpin _spin;
    private Donut _donut;
    
    //Variables
    private bool _isBoosting;
    private bool _hasBoosted;
    private float _boostProgress;
    
    
    public void Start()
    {
        var player = GameObject.Find("Player");
        
        _aMa = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _chCam = Camera.main.GetComponent<ChappersCam>();
        _worldMover = GameObject.Find("Road").GetComponent<WorldMover>();
        _anim = player.GetComponent<AnimHelper>();
        _spin = player.GetComponentInChildren<DonutSpin>();
        _donut = player.GetComponent<Donut>();
    }


    private void Update()
    {

        if (_isBoosting && !_hasBoosted)
        {
            Debug.Log("Starting boost");
            _worldMover.WorldSpeed += 5f;
            _hasBoosted = true;
        }

        if (_isBoosting)
        {
            Debug.Log("Boosting");
            _boostProgress += 10 * Time.deltaTime;
        }

        if (_boostProgress > 100f)
        {
            _worldMover.WorldSpeed -= 3f;
            Debug.Log("Ended boost!");
            _boostProgress = 0f;
            _isBoosting = false;
            _hasBoosted = false;
        }
    }


    public void DonutDie()
    {
        
        _chCam.Shake(10f);
        _worldMover.WorldAcceleration = -30;
        _anim.Donut_Death_Start(0f);
        _spin.SpinSpeed = 0f;
        _donut.IsDead = true;
    }

    public void DonutBoost()
    {

        _isBoosting = true;
        _hasBoosted = false;
    }

    protected void DonutSlow()
    {
        
        
    }

    protected void DonutInvert()
    {
        
        
    }
}
