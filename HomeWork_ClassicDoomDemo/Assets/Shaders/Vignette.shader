Shader "Custom/PostProcess" 
{
    Properties 
    {
        _MainTex("Texture", 2D) = "white" {}
        _VRadius("Vignette Radius", Range(0.0, 1.0)) = 1.0 
        _VSoft("Vignette Softness", Range(0.0, 1.0)) = 0.5 
        _Color("Color", Color) = (1, 0, 0, 1)
    }

    SubShader 
    {
        Pass 
        {
              CGPROGRAM
              #pragma vertex vert_img
              #pragma fragment frag
              #include "UnityCG.cginc"
        
              sampler2D _MainTex;
              float _VRadius;
              float _VSoft;
              float4 _Color;
        
              float4 frag(v2f_img input) : COLOR 
              {
                   float4 base = tex2D(_MainTex, input.uv);
                   
                   float distFromCenter = distance(input.uv.xy, float2(0.5, 0.5));
                   float vignette = smoothstep(_VRadius * (1 + sin(_Time.y) / 2), _VRadius - _VSoft, distFromCenter);
                   base = saturate(base + _Color * ( 1 - vignette));
                   return base;
              }
              ENDCG
        }
    }
}
