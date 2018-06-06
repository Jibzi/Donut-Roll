using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This tag makes it effect the editor, for feedback when tweaking the sliders.
[ExecuteInEditMode]
public class WorldBender : MonoBehaviour
{
    //This is a point in space from where the warping originates. Point this to the camera to get the effect. 
    //But can be played with for some other space bending effects!
    public Transform BendStart;

    //Make sliders for the variables in the editor.
    [Range(-200f, 200f)] [SerializeField] private float _x = 0f;
    [Range(-200f, 200f)] [SerializeField] private float _y = 0f;
    [Range(-50f, 50f)] [SerializeField] private float _falloff = 0f;

    //Pack the two variables into a vector to be passed to the shader.
    private Vector2 bendAmount = Vector2.zero;

    //Globals for shader
    private int bendAmountId;
    private int bendStartId;
    private int bendFalloffId;

    void Start()
    {
        //Init shader values.
        bendAmountId = Shader.PropertyToID("_BendAmount");
        bendStartId = Shader.PropertyToID("_BendStart");
        bendFalloffId = Shader.PropertyToID("_BendFalloff");
    }

    void Update()
    {
        //Update shader values at runtime, so we can create the illusion of corners just by altering the x bend amount.
        bendAmount.x = _x;
        bendAmount.y = _y;

        Shader.SetGlobalVector(bendAmountId, bendAmount);
        Shader.SetGlobalVector(bendStartId, BendStart.position);
        Shader.SetGlobalFloat(bendFalloffId, _falloff);
    }
}