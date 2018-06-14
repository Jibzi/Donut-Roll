using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesOfDay : MonoBehaviour {

    [SerializeField]
    float LengthOfADay;
    [SerializeField]
    Texture[] textures;

    void SetTimeOfDay()
    {
        Dictionary<int, int> TimesOfDay;
        //TimesOfDay
        //Time.fixedDeltaTime % textures.Length;
        //How will I code this? A 
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
