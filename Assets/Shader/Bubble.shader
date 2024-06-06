Shader "Custom/Bubble"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Emission ("Emission", Range(0,1)) = 0.0
        
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        [PowerSlider(4)] _FresnelIntensity ("Fresnel Intensity", Range(0.25,4)) = 1.0
    }
    
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade

        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal;
            float3 viewDir;
            INTERNAL_DATA
        };

        half _Glossiness;
        half _Metallic;
        half _Emission;
        
        fixed4 _Color;
        
        fixed4 _FresnelColor;
        half _FresnelIntensity;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input i, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, i.uv_MainTex) * _Color;
            
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;

            float fresnel = dot(i.worldNormal, i.viewDir);
            fresnel = saturate(1 - fresnel);
            fresnel = pow(fresnel, _FresnelIntensity);
            float3 fresnelColor = _FresnelColor * fresnel;
            
            o.Alpha = fresnel * c.a;
            
            o.Emission = _Emission + fresnelColor;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
