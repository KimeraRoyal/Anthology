Shader "Unlit/Fake Mirror"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        
        
        _MultColor ("Color (Multiply)", Color) = (1,1,1,1)
        _AddColor ("Color (Additive)", Color) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            fixed4 _MultColor;
            fixed4 _AddColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.screenPos.xy / i.screenPos.w;

                uv = TRANSFORM_TEX(uv, _MainTex);

                fixed4 col = tex2D(_MainTex, uv);
                return clamp(col * _MultColor + _AddColor, 0, 1);
            }
            ENDCG
        }
    }
}
