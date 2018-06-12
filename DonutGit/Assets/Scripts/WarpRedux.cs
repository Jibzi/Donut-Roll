using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpRedux : MonoBehaviour
{
    //Stores two separate positions, needed for warp calculations.
    private Vector3 _realPos;
    private Vector3 _warpPos;

    [Tooltip("How quickly the coin wobbles up and down. Recommended : 6.")] [Range(0, 10)] [SerializeField]
    private float WobbleFrequency;

    [Tooltip("How much the coin wobbles up and down. Recommended: 60.")] [Range(0, 100)] [SerializeField]
    private float WobbleAmplitude;

    [SerializeField] private Vector3 RotationSpeed;

    //Tells the object where to appear in the world.
    //TODO: Add a more robust system for setting the spawn point, maybe load it based on what object this script is attached to.
    [SerializeField]
    [Tooltip("This will be where the object appears. Use 0, 1, 120 for most collectables or obstacles")]
    private Vector3 _startPos;

    //Value used to reduce the amplitude of wobbling
    private float clamper = 100f;

    //Stores the speed at which the world is currently moving.
    //TODO: Make this just grab the speed from a manager class or something.
    private float worldSpeed = -10;

    private GameObject _wb;
    private WorldBender _wbs;

    // Use this for initialization
    void Start()
    {
        //Set object to it's start pos.
        //_startPos = new Vector3(0, 0.9f, 120);
        transform.position = _startPos;

        //Initiate realpos with startpos.
        _realPos = _startPos;

        //Grab the world bender so we can retrieve variables from it during warping. Allows for run-time editing of the 
        //world bender's variable.
        _wb = GameObject.Find("Bender");
        _wbs = _wb.GetComponent<WorldBender>();
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
            (_realPos.y + (Mathf.Sin(Time.time * WobbleFrequency) / (clamper - WobbleAmplitude))),
            (_realPos.z + worldSpeed * Time.deltaTime)
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

        _warpPos.Set(_realPos.x + distx, _realPos.y + dist, _realPos.z);

        transform.position = _warpPos;
    }
}