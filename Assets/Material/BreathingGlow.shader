Shader "Custom/SmoothGlowingTransparentShader"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,1,1,1)
        _GlowColor ("Glow Color", Color) = (1,1,0,1) // Yellow Glow
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 1
        _Alpha ("Alpha Transparency", Range(0,1)) = 0.5
        _GlowSpeed ("Glow Speed", Range(0, 5)) = 2
        _GlowInterval ("Glow Interval", Range(0, 5)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // Enable Transparency
            ZWrite Off // Disable depth writing for transparency
            Cull Back
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata_t
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            // Properties
            float4 _BaseColor;
            float4 _GlowColor;
            float _GlowIntensity;
            float _Alpha;
            float _GlowSpeed;
            float _GlowInterval;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.position = TransformObjectToHClip(v.position.xyz);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // Smooth Glow Effect Over Time
                float timeFactor = _Time.y * _GlowSpeed;
                float smoothGlow = (sin(timeFactor) + 1) * 0.5; // Normalized sine wave (0 to 1)

                // Smooth interval effect using cosine for easing
                float intervalFactor = (cos(frac(_Time.y / _GlowInterval) * 3.1416 * 2) + 1) * 0.5; 

                // Final glow intensity
                float glow = smoothGlow * intervalFactor;

                // Apply glow effect
                float4 finalColor = _BaseColor;
                finalColor.rgb += _GlowColor.rgb * _GlowIntensity * glow; // Smooth glow effect
                finalColor.a = _Alpha; // Apply transparency

                return finalColor;
            }
            ENDHLSL
        }
    }
}