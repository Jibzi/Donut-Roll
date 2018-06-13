using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromaticRandomiser : MonoBehaviour {

    [SerializeField][Tooltip("The material whose textures will be randomised.")]
    Material _material;
    [SerializeField]
    [Tooltip("The textures to be randomly applied to the material.")]
    //Dictionary of textures. Indices are integral, rather than in the form of bytes, to maintain 32-bit memory size.
    Dictionary<int, Texture> Textures;

    void RandomiseColour()
    {
        
    }

    void RandomiseTexture()
    {
        int texturalIndex;
        int modulator = 6;
        texturalIndex = (int)Mathf.RoundToInt(Time.fixedTime % modulator);
        switch(texturalIndex)
        {
            case 0:
                break;
            case 1:
                break;
        }
    }

    void Randomise()
    {
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
