using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {

    GameObject Collectable;

    [SerializeField] SphereCollider SC;
    [SerializeField] private float timeToDespawn;
    private float collectablesCollected;

    // Use this for initialization
    void Start()
    {
        Collectable = GameObject.FindWithTag("Collectable");
    }

    void AddToCollectablesCollected()
    {
        //Increment the number of collectables collected, which will influence the score.
        collectablesCollected++;
    }

    

    void ResetCollectable()
    {
        Collectable = new GameObject();
    }

    void DespawnCollectable()
    {
        //Remove the coin from the scene after it has passed the camera.
        Destroy(Collectable, timeToDespawn); //https://docs.unity3d.com/ScriptReference/Object.Destroy.html
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
