Shader "Unlit/ScreenCutoutShader_VR"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        Lighting Off
        Cull Back
        ZWrite On
        ZTest Less

        Fog { Mode Off }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing // Ensure compatibility with single-pass instanced rendering

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO // Macro for VR stereo compatibility
            };

            sampler2D _MainTex;

            v2f vert (appdata v)
            {
                v2f o;

                UNITY_SETUP_INSTANCE_ID(v); // Setup instance ID for single-pass rendering
                UNITY_INITIALIZE_OUTPUT(v2f, o); // Initialize stereo output

                // Compute vertex position in clip space
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); // Ensure correct eye index for VR rendering

                // Adjust screen position for each eye in single-pass stereo rendering
                i.screenPos /= i.screenPos.w;

                // Sample texture using screen space coordinates
                float2 uv = float2(i.screenPos.x, i.screenPos.y);
                fixed4 col = tex2D(_MainTex, uv);

                return col;
            }
            ENDCG
        }
    }
}
