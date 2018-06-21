using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
//Author: George
//
//This script displaces GameObjects by the same algorithm that is used in the "World Bender" shader.
//This is to give the effect of obstacles and collectables coming over the crest of the hill caused by the 
//World Bender.
//
//This script also handles other aspects of a obstacle's or collectable's movement, such as where it spawns,
//if it spins, and the parameters for wobbly floating.
//
//
public class WarpRedux : MonoBehaviour
{
    //Stores two separate positions, needed for warp calculations.
    public Vector3 _realPos;
    private Vector3 _warpPos;

    [Tooltip("How quickly the coin wobbles up and down. Recommended : 6.")]
    [Range(0, 10)]
    [SerializeField]
    private float WobbleFrequency;

    [Tooltip("How much the coin wobbles up and down. Recommended: 60.")]
    [Range(0, 20)]
    [SerializeField]
    private float WobbleAmplitude;

    [SerializeField]
    private Vector3 RotationSpeed;

    //Value used to reduce the amplitude of wobbling
    private float WobbleClamper = 100f;

    private WorldMover _worldMover;

    private WorldBender _wbs;

    void Start()
    {

        WobbleAmplitude = WobbleAmplitude / 100f;
        
        //Initiate realpos with current position.
        _realPos = transform.position;

        //Grab the world bender so we can retrieve variables from it during warping. Allows for run-time editing of the 
        //world bender's variable.
        _wbs = GameObject.Find("Bender").GetComponent<WorldBender>();
        _worldMover = GameObject.Find("Road").GetComponent<WorldMover>();
    }

    // Update is called once per frame
    void Update()
    {
        Float();
        WarpRy();
        Rotate();
    }

    //Spins the object according to the variables set in the editor.
    void Rotate()
    {
        this.transform.Rotate(RotationSpeed / 100, Space.World);
    }

    //Applies proper movements to the object.
    //TODO: Add helper functions here so that applying movements to the objects don't requre adding code to this section.
    void Float()
    {
        
        _realPos.Set(
            _realPos.x,
            _realPos.y,
            _realPos.z + -_worldMover.WorldSpeed * Time.deltaTime
        );
    }

    //Replication of the vertex displacement that is applied to the road.
    //But instead just adjusts the objects transform so that it appears to also be warped.
    void WarpRy()
    {
        var dist = Vector3.Distance(_realPos, _wbs.BendStart.transform.position);

        dist = Mathf.Max(0, (dist - _wbs.Falloff));

        dist = dist * dist;

        var distx = dist * (_wbs.X * 0.0001f);

        dist = dist * (_wbs.Y * 0.0001f);

        _warpPos.Set(
            
            _realPos.x + distx,
            
            (_realPos.y + dist) + ((Mathf.Sin(Time.time * WobbleFrequency) * WobbleAmplitude)),
            
            _realPos.z);

        transform.position = _warpPos;
    }

}