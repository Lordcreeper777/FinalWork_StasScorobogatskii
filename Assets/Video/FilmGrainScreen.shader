Shader "Custom/FilmGrainScreen"
{
    Properties
    {
        _MainTex ("Video", 2D) = "black" {}
        _Intensity ("Intensity", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
            "RenderPipeline"="UniversalPipeline"
        }

        ZWrite Off
        Cull Off

        // SCREEN blend
        Blend One OneMinusSrcColor

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            float _Intensity;

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                half4 grain = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);

                grain.rgb *= _Intensity;

                return grain;
            }

            ENDHLSL
        }
    }
}