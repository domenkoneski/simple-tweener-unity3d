//	Written by Domen Koneski

Shader "Koneski/Gradient Skybox"
{
    Properties
    {
        _UpperColor ("Upper Gradient Color", Color) = (1, 1, 1, 0)
        _BottomColor ("Bottom Gradient Color", Color) = (1, 1, 1, 0)
        _GradientIntesity ("Gradient Intensity", Float) = 1.0
	}

	SubShader
	{
		Tags
		{ 
			"Queue" = "Background" 
			"RenderType" = "Background" 
			"PreviewType" = "Skybox" 
		}

		Cull Off ZWrite Off

		Pass
		{
			CGPROGRAM

			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct v2f
			{
				float4 position : SV_POSITION;
				float3 vertex : TEXCOORD0;
			};
    
			//	Gradient coloring
			half4 _UpperColor;
			half4 _BottomColor;
			half _GradientIntesity;

			fixed3 GradientColor(float y)
			{
				return lerp(_BottomColor.rgb, _UpperColor.rgb, y) * _GradientIntesity;
			}

			v2f vert (appdata_base v)
			{
				v2f o;

				o.position = UnityObjectToClipPos (v.vertex);
				o.vertex = v.vertex;

				return o;
			} 
    
			fixed4 frag (v2f i) : SV_Target
			{
				half3 color;

				half3 gradientColor = GradientColor(i.vertex.y);
				color = gradientColor;

				return half4(color, 1);
			}

			ENDCG
		}
	}
}