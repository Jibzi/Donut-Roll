﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromaticRandomiser : MonoBehaviour {
    
    [SerializeField][Tooltip("The material whose textures will be randomised.")]
    Material _material;
    [SerializeField]
    [Tooltip("The textures to be randomly applied to the material.")]
    //Array of textures. Indices are integral, rather than in the form of bytes, to maintain 32-bit memory size.
    public Texture[] textures;
    private int indexOfLastUsedElement;

    void RandomiseColour()
    {
        //Dictionary of colours to apply to the given material
        Dictionary<int, Color> colours = new Dictionary<int, Color>();
        colours.Add(0, Color.green);
        colours.Add(1, Color.red);
<<<<<<< HEAD
        //The key of the to be allocated colour
        int chromaticKey;
        //Max reachable key of dictionary (in accordance with zero-based indexing)
        int maxReachableKey = colours.Count - 1;
        //The number by which we will modulo delta time.
        int divisor = colours.Count;
        //The index of the colour. We need it to be an int, in accordance with that an array's index must be integral. Clamp it also
        //chromaticKey =  (int)Mathf.Clamp((Mathf.RoundToInt(Time.time % divisor)), 0 , colours.Count - 1);  
        chromaticKey = rand.Next(colours.Count);
        //chromaticKey =  (int)Mathf.Clamp((Mathf.RoundToInt((int)localDate % divisor)), 0 , colours.Count - 1);
        if (colours.ContainsKey(chromaticKey))
        {
            _material.color = colours[chromaticKey];
            Debug.Log(chromaticKey);
        }
        else
        {
            Debug.Log(@"chromaticKey value was {chromaticKey}");
        }   
=======
        //The index of the to be allocated colour
        int chromaticIndex;
        //The number by which we will modulo delta time. This must be equal to the array's length - 1, accounting for the extra number 0.
        int divisor = colours.Count + 1;// - 1;
        //The index of the colour. We need it to be an int, in accordance with that an array's index must be integral.
        chromaticIndex = (int)Mathf.RoundToInt(Time.time % divisor);
        _material.color = colours[chromaticIndex];
        Debug.Log(colours[chromaticIndex]);
>>>>>>> 61440514a0a8fde86255da381cb62adc0efcf27b
    }

    void RandomiseTexture()
    {
        if (textures.Length > 0)
        {
            //The index of the to be allocated texture
            int texturalIndex;
            //The number by which we will modulo delta time. This must be equal to the array's length - 1, to account for the extra number 0.
            int divisor = textures.Length;// + 1;
            //The index of the texture. We need it to be an int, in accordance with that an array's index must be integral.
            texturalIndex = Mathf.RoundToInt(Time.time % divisor);
            _material.mainTexture = textures[texturalIndex];

        }
        
        
        //Switch by the index 
        
    }

    void Randomise()
    {
        //If the material is simplistic enough to redound a base colour, simply recolour it using the albedoColor parameter.
        if (_material.name == "GummyMat" || textures.Length <= 0)
        {
            RandomiseColour();  
        }
        else
        {
            RandomiseTexture();
        }
    }

    void GetLastColourOrTexture()
    {

    }

    void GetLastColour()
    {

    }

    void SetLastColour()
    {
        //indexOfLastUsedElement = 
    }

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = true;
        _material = GetComponent<Renderer>().material;
        RandomiseColour();

	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
