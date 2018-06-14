using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    //Dicitionary in which to store the collectables as they appear on screen.
    Dictionary<int, GameObject> CollectablesOnScreen;

    [SerializeField] SphereCollider SC;
    [SerializeField] private float timeToDespawn;
    private bool hasBeenCollected;
    Dictionary<GameObject, GameObject> collectables;
    /*The number of collectables collected and the current combo, in respection. I chose integers as they
     make better numerary sense and floats seemed silly and too complex for a mobile game's demographic*/
    private int
        collectablesCollected,
        currentCombo;
    //The tag for which the collider should search.
    private const string kTagToSeek = "Collectable";
    
    // Use this for initialization
    void Start()
    {
        //Collectable = GameObject.FindWithTag(kTagToSeek);
        Collectable.Collected += AddToCollectablesCollected;        
    }

    //Increment the number of collectables collected, which will influence the score.
    void AddToCollectablesCollected(object sender, System.EventArgs eventArgs)
    {
        collectablesCollected++;
    }
    //Increment the combo, which will temporarily influence the score.
    void AddToCurrentCombo()
    {
        //I must put a time here
        /*Time for which the combo is active until it fades
         *Rate at which combo depletes
         *
         */
        currentCombo++;
    }

    //Triggered when the player's x2 multiplier fades
    void UnDoubleCombo()
    {
        /*Use integral halving to safely half the current combo, whilst keeping it integral 
        (thus easier of which for the player to keep track) without requiring rounding/ceiling/flooring*/
        currentCombo /= 2;
    }

    //Triggered when the player gets x2 multiplier
    void DoubleCombo()
    {
        //The maximal doublable combo before doubling
        /*local*/ const int kMaxUndoubledCombo = 8;
        //If the current combo is less than ^
        if (currentCombo <=  kMaxUndoubledCombo)
        { 
            /*local*/ const int
                kMinCombo = 2,
                kMaxCombo = kMaxUndoubledCombo * 2;
            //Double the combo, whilst ensuring it will not exceed 
            Mathf.Clamp(currentCombo * kMinCombo, kMinCombo, kMaxCombo);
        }
    }

    void ResetCollectable()
    {
        //Reset the collectable to nothing.
        //Collectable = new GameObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void BeCollided()
    {
        //
    }


    void DespawnCollectable()
    {
        float behindDonut = -10f;
        //if (Collectable.transform.position.z <= behindDonut)
        {
            //Remove the coin from the scene after it has passed the camera.
            //Destroy(Collectable, timeToDespawn); //https://docs.unity3d.com/ScriptReference/Object.Destroy.html
        }
    }

    // Update is called once per frame
    void Update ()
    {
        

    }
}
