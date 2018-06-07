using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingComponent : MonoBehaviour
{

    
    [Range(0,10)][SerializeField] private float WobbleFrequency;
    
    [Range(0, 100)] [SerializeField] private float WobbleAmplitude;
    
    [SerializeField] private Vector3 RotationSpeed;

    private Vector3 _startPos;

    // Use this for initialization
	void Start ()
    {
        _startPos = new Vector3(0, 1.7f, 120);
        transform.position = _startPos;
    }

    void Rotate()
    {
        this.transform.Rotate(RotationSpeed/100, Space.World);
    }

    void Float()
    {
        transform.Translate(0,(Mathf.Sin(Time.time * WobbleFrequency) / (1/WobbleAmplitude)), -10 * Time.deltaTime, Space.World);
    }

    void Move()
    {
        Rotate();
        Float();
    }

    void Update ()
    {
        Rotate();
        Move();
    }
}
