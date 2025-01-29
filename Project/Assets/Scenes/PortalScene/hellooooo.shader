Shader "Custom/PortalStencil"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Geometry+1" }
        Lighting Off
        ZWrite On
        ZTest LEqual
        Cull Back

        Stencil
        {
            Ref 1             // Reference value for the stencil buffer
            Comp Always       // Always pass stencil test
            Pass Replace      // Write the reference value (1) to the stencil buffer
        }

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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv); // Render the portal's texture
            }
            ENDCG
        }
    }
}
