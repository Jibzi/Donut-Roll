using System;   //System because dealing with Eventhandlers
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    GameObject Player;

    //Random scaling
    [SerializeField][Tooltip("The minimal randomly allocable to the collectable. Recommended: 0.9")]
    private float minimalCollectableSize;
    [SerializeField]
    [Tooltip("The maximal randomly allocable to the collectable. Recommended: 1.1")]
    private float maximalCollectableSize;

    //For visual variation, minutely change the size of every collectable
    void SetSize()
    {
        /*A temporary local randomisative modulator - the number by which we modulo
            total playtime to get our number of different sizes the coin can be.*/
        const float 
            randomisitiveModulator = 10f,
            randomisitiveDivisor = 5f;
        //Declare a local holder variable for the randomised scale.
        float rando = Mathf.Clamp((
            (Time.fixedTime % randomisitiveModulator) / randomisitiveDivisor), 
            minimalCollectableSize, 
            maximalCollectableSize
            );
        transform.localScale *= rando;
    }
    
    void FindPlayer()
    {
        const string kPlayerTag = "Player";
        Player = GameObject.FindGameObjectWithTag(kPlayerTag);
        Debug.Log(kPlayerTag);
    }


    // Use this for initialization
	void Start () {
        SetSize();
        FindPlayer();
	}

    public event EventHandler PointChanged;

    public void OnCollected()
    {

    }

	// Update is called once per frame
	void Update () {
	}
}
