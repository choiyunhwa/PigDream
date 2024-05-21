Shader "Custom/BackGroundScroll"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _U ("TileU", float) = 1
        _V ("TileV", float) = 1        
    }
    SubShader
    {
        Tags { 
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"                  
        }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        float _U;
        float _V;

        struct Input
        {
            float2 uv_MainTex;
        };
        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex;
            uv.x = uv.x * _U;
            uv.y = uv.y * _V + _Time.y;

            fixed4 c2 = tex2D (_MainTex, uv);
            o.Emission = c2.rgb;
            o.Alpha = c2.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
