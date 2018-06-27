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
    //TODO: Remove unused references.
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
            _boostProgress += Time.deltaTime;
        }

        if (_boostProgress > 5f)
        {
            _worldMover.WorldSpeed -= 5f;
            Debug.Log("Ended boost!");
            _boostProgress = 0f;
            _isBoosting = false;
            _hasBoosted = false;
        }
    }


    public void DonutDie()
    {
        _worldMover.WorldAcceleration = -100;
        _spin.SpinSpeed = 0f;
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
