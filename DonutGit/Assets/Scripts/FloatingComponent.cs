using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingComponent : MonoBehaviour
{



    [Tooltip("How quickly the coin wobbles up and down. Recommended : 6.")]
    [Range(0, 10)]
    [SerializeField]
    private float WobbleFrequency;

    [Tooltip("How much the coin wobbles up and down. Recommended: 60.")]
    [Range(0, 100)]
    [SerializeField]
    private float WobbleAmplitude;

    [SerializeField]
    private Vector3 RotationSpeed;


    private Vector3 _startPos;
    private float clamper = 100f;
    private float worldSpeed = -10;



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
        transform.Translate(0,(Mathf.Sin(Time.time * WobbleFrequency) / (clamper - WobbleAmplitude)), worldSpeed * Time.deltaTime, Space.World);
    }

    void Move()
    {
        Rotate();
        Float();
    }

    void Update ()
    {
        Move();
    }
}
