Shader "Custom/Background Distortion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _InterlaceTex ("Interlace", 2D) = "white" {}
        
        _Tiling ("Sine Tiling", Float) = 1
        
        _Offset ("Offset Amount", Range(-1, 1)) = 0
        _OffsetSpeed ("Offset Scroll Speed", Range(-10, 10)) = 1
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            sampler2D _InterlaceTex;
            float4 _InterlaceTex_ST;
            
            float _Tiling;

            float _Offset;
            float _OffsetSpeed;

            fixed4 frag (v2f i) : SV_Target
            {
                const float y = i.uv.y * _Tiling;
                const float t = (y + _Time * _OffsetSpeed) % 1;
                const float offset = sin(t * UNITY_PI * 2);

                const float2 interlaceUV = i.uv * _InterlaceTex_ST.xy;
                fixed4 interlaceCol = tex2D(_InterlaceTex, interlaceUV);
                const float offsetAmount = _Offset * interlaceCol.r + -_Offset * (1 - interlaceCol.r);
                
                i.uv.x += offset * offsetAmount;
                
                fixed4 col = tex2D(_MainTex, i.uv);
                
                return col;
            }
            ENDCG
        }
    }
}
