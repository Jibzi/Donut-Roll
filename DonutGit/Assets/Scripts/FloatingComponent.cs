using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingComponent : MonoBehaviour {
    
    [SerializeField]
    //How much the component floats
    private Vector3 FloatingAmount;
    //Speed at which the component floats
    [SerializeField]
    private Vector3 FloatingSpeed;
    //Speed at which the component rotates
    [SerializeField]
    private Vector3 RotationSpeed;
    private Quaternion QuaternionicRotation;

    // Use this for initialization
	void Start ()
    {
        QuaternionicRotation = transform.rotation;
        RotationSpeed.Set(500, 500, 500);
    }

    void Rotate()
    {

        QuaternionicRotation.Set
            (
            RotationSpeed.x * Time.deltaTime,
            RotationSpeed.y * Time.deltaTime,
            RotationSpeed.z * Time.deltaTime, 
            0
            );
    }

    void Float()
    {

    }

    void Move()
    {
        Rotate();
        Float();
    }


    // Update is called once per frame
    private void Update()
    {
        
    }



    void LateUpdate ()
    {
        Rotate();
	}
}
