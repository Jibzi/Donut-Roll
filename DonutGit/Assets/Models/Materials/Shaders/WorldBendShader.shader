//
//Author: George
//
//Reference: http://www.jordanstevenstechart.com/vertex-displacement
//
//Shader that displaces vertecies based in their distance from the camera in world space.
//Controlled in editor by the "Bender" object.
//


shader "Custom/Bender"
{
Properties{
_Color ("Main Color", Color) = (1,1,1,1)
_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader
{
Tags { "RenderType" = "Opaque" }
LOD 200

CGPROGRAM
#pragma surface surf Lambert vertex:vert addshadow

//Globals
uniform float2 _BendAmount;
uniform float3 _BendStart;
uniform float _BendFalloff;

sampler2D _MainTex;
fixed4 _Color;

struct Input{
float2 uv_MainTex;
};

float4 Warp(float4 v){

//reduce bend amount from an easily changed editor value to one that works for the maths.
_BendAmount *= 0.0001;

//Get verts world space position
float4 world = mul(unity_ObjectToWorld, v);

//Calulate the difference between the world position of the vertex and the BendStart, which should be set to the camera.
float dist = length(world.xz-_BendStart.xz);

//Apply falloff, which is a grace area where no warping happens.
dist = max(0, dist-_BendFalloff);

//Distance squared, so the warp curves and is not linear.
dist = dist*dist;

//Set the new world position for the vertex.
world.xy += dist*_BendAmount;

return mul(unity_WorldToObject, world);
}

void vert(inout appdata_full v){

//Handle input of verts and hand them over the warp function.
v.vertex = Warp(v.vertex);
}

//Basic surface shader, does colour and albedo map.
void surf(Input IN, inout SurfaceOutput o){
fixed4 c =tex2D(_MainTex, IN.uv_MainTex) * _Color;
o.Albedo = c.rgb;
o.Alpha = c.a;
}

ENDCG
}
	FallBack "Mobile/Diffuse"
}
