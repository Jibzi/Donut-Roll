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

    void RandomiseColour()
    {
        Dictionary<string, Color> colours = new Dictionary<string, Color>();
        colours["Red"] = Color.red;
        //colours["Green"]


        //_material.color 
    }

    void RandomiseTexture()
    {
        if (textures.Length > 0)
        {
            //The index of the to be chosen texture
            int texturalIndex;
            //The number by which we will modulo delta time. This must be equal to the array's length - 1, to account for the extra number 0.
            int divisor = textures.Length + 1;
            //The index of the texture. We need it to be an int, in accordance with that an array's index must be integral.
            texturalIndex = (int)Mathf.RoundToInt(Time.fixedTime % divisor);
            _material.mainTexture = textures[texturalIndex];
        
        }
        
        
        //Switch by the index 
        
    }

    void Randomise()
    {
        //If the material is simplistic enough to redound a base colour, simply recolour it using the albedoColor parameter.
        if (_material.name == "GummyMat")
        {
            RandomiseColour();  
        }
        else
        {
            RandomiseTexture();
        }
    }

	// Use this for initialization
	void Start () {
        _material = GetComponent<Renderer>().material;
        //Randomise();

	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
