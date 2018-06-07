using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    GameObject Collectable;

    [SerializeField] SphereCollider SC;
    [SerializeField] private float timeToDespawn;
    private float collectablesCollected;
    private const string kTagToSeek = "collectable";

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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == kTagToSeek)
        {
            Destroy(col.gameObject);
        }
    }

    void ResetCollectable()
    {
        //Reset the collectable to nothing.
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
