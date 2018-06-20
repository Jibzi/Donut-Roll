using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {
    //We want a sphereCollider on every collectable, through which the GameObject tagged "Player" will pass.
    public SphereCollider SC;
    //The GameObject tagged "Player"
    private GameObject Player;

    
    //Destroy the current instance of the collectable
    private void DestroyCollectableInstance()
    {
        //Removes this script instance from the game object (https://docs.unity3d.com/ScriptReference/Object.Destroy.html)
        Destroy(this);
        Debug.Log("An instance has been destroyed");
    }

    //Find the object tagged "Player"
    private void FindPlayer()
    {
        //Declare a constant string for the player's tag.
        const string kPlayerTag = "Player";
        //Populate the local player object with the object in the scene which is tagged "Player"
        Player = GameObject.FindGameObjectWithTag(kPlayerTag);
        Debug.Log("Player: " + Player);
    }

    //Print a string determining Player's validity
    void PrintPlayerValidity()
    {
        //If the player object is valid
        if (Player != null)
        {
            //Print the player object
            Debug.Log(Player);
        }
        else
        {
            //Print the invalidity of Player
            Debug.Log("Player was not found");
        }
    }

	// Use this for initialization
	void Start ()
    {
        FindPlayer();

        //Debug.Log("PC: " + Player.GetComponent<SphereCollider>());
        //Debug.Log("CC: " + this.GetComponent<SphereCollider>());
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("There was a collision!");
        //When the GameObject tagged "Player" enters SC
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("The collider's tag was Player");
            DestroyCollectableInstance();
            Debug.Log("The Collectable was destroyed");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        //Destroy the current collectable instance upon Player's having exited it



    }





    // Update is called once per frame
    void Update ()
    {
        //PrintPlayerValidity();
	}
}
