using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingComponent : MonoBehaviour
{

    
    [Range(0,10)][SerializeField] private float WobbleFrequency;
    
    [Range(0, 100)] [SerializeField] private float WobbleAmplitude;
    
    [SerializeField] private Vector3 RotationSpeed;

    private float _clamper;

    private float _worldSpeed;

    private Vector3 _startPos;

    // Use this for initialization
	void Start ()
    {
        _startPos = new Vector3(0, 1.7f, 120);
        transform.position = _startPos;
        _clamper = 100;
        _worldSpeed = -10;
    }

    void Rotate()
    {
        this.transform.Rotate(RotationSpeed/100);
    }

    void Float()
    {
        transform.Translate(0, (Mathf.Sin(Time.time * WobbleFrequency) / (100 - WobbleAmplitude)), -10 * Time.deltaTime);
    }


    void Update ()
    {
        Rotate();
        Float();
    }
}
