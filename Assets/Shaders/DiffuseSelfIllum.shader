Shader "Custom/DiffuseSelfIllum" {
	Properties {
		//_MainTex ("Base (RGB)", 2D) = "white" {}
		_IllumColor("Illum Color", Color) = (1,1,1,1)
		_Color1 ("Pattern Color", Color) = (1,1,1,1)
		_Illum ("Illum (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		//sampler2D _MainTex;
		sampler2D _Illum;
		fixed4 _Color1;
		fixed4 _Color2;
		fixed4 _IllumColor;
		

		struct Input {
			float2 uv_Illum;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_Illum, IN.uv_Illum);
			
			//o.Albedo = lerp (_Color1.rgb, _Color2.rgb, IN.fog) * (1 - c.a) + c.rgb * c.a;
			o.Emission = _Color1.rgb * (1 - c.a) + _IllumColor.rgb * c.a;
			o.Alpha = 1.0;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
