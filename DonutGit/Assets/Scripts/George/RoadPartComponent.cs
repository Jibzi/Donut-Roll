using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Author: George
//
//Component script that gives behaviour to the road pieces. Mainly the speed at which they move, which in turn is
//how fast the game is; as it is the world moving, not the player.
//Also calls the PopulateRoad script when this resets back to the far end of the road, prompting new objects to spawn.
//

public class RoadPartComponent : MonoBehaviour
{

    private PopulateRoad _populateRoad;
    private WorldMover _worldMover;
	
    // Use this for initialization
    void Start ()
    {

        _populateRoad = GameObject.Find("Road").GetComponent<PopulateRoad>();
        _worldMover = GameObject.Find("Road").GetComponent<WorldMover>();
    }

	
    // Update is called once per frame
    void Update ()
    {
        this.transform.Translate(0,0, (-_worldMover.WorldSpeed * Time.deltaTime));

        //Teleport any road parts that are behind the camera to the far end of the road.
        if (this.transform.position.z < -40f)
        {
            //TODO: Consider also swapping out the mesh for another; to reduce the repition.
            //TODO: change from 160 to 20* roadparts
            this.transform.Translate(0, 0, 160);
			
            //Debug.Log(_populateRoad);
            _populateRoad.PopulateRoadSegment();
        }
    }
}