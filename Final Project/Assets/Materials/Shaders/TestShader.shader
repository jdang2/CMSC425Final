Shader "Custom/TestShader"
{
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Detail ("Detail", 2D) = "gray" {}
        _StencilVal ("Stencil Value", Range(0, 255)) = 1
    }
    SubShader {
        Tags { "RenderType" = "Opaque" "Queue"="Transparent+1"}
        ZWrite Off

        Stencil
		{
			Ref [_StencilVal]
			Comp Always
			Pass replace
		}

        CGPROGRAM
        #pragma surface surf Lambert
        struct Input {
            float2 uv_MainTex;
            float4 screenPos;
        };
        sampler2D _MainTex;
        sampler2D _Detail;
        void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
            float2 screenUV = IN.screenPos.xy / (IN.screenPos.w + 1);
            screenUV *= float2(8,6);
            o.Albedo *= tex2D (_Detail, screenUV).rgb * 2;
        }
        ENDCG
    } 
    Fallback "Diffuse"
}
