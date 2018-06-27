//
//Author: George
//
//Reference: http://www.jordanstevenstechart.com/vertex-displacement
//
//Shader that displaces vertecies based in their distance from the camera in world space.
//Controlled in editor by the "Bender" object.
//


shader "Custom/Bender"{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BumpMap ("Bumpmap", 2D) = "bump" {}
        _GlossTex ("Gloss", 2D) = "white" {}
        _SpecTex ("Specular", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf BlinnPhong vertex:vert addshadow

        //Globals
        uniform float2 _BendAmount;
        uniform float3 _BendStart;
        uniform float _BendFalloff;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_GlossTex;
            float2 uv_SpecTex;
        };

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _GlossTex;
        sampler2D _SpecTex;
       

        float4 Warp(float4 v)
        {

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

        void vert(inout appdata_full v)
        {

            //Handle input of verts and hand them over the warp function.
            v.vertex = Warp(v.vertex);
        }

        //Basic surface shader, does colour and albedo map.
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
            o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
            o.Gloss = tex2D (_GlossTex, IN.uv_GlossTex).r;
            o.Specular = tex2D (_SpecTex, IN.uv_SpecTex).r;
            o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
        }
        ENDCG
    }
	FallBack "Mobile/Diffuse"
}
