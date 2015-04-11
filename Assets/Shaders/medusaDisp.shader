Shader "Custom/medusa Displacement" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Color2 ("Color 2", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		
		_Phase ("Movement Phase", Float) = 1.0
		_Decal("Decal", Float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert vertex:vert 

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 height;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _Color2;
		
		float _Phase;
		float _Decal;
		
		//uniform const float pi = 3,14159;
		
		 struct appdata {
		 
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
        };
		
		
		void vert(inout appdata v, out Input data)
		{
			UNITY_INITIALIZE_OUTPUT(Input, data);
			const float PI = 3.14159;
			
			float dist = (abs(v.vertex.x) + abs(v.vertex.y)) * 0.5;
		
			float ph = sin(_Decal + _Time.y * _Phase + PI * (1 - dist) * (1 - dist) * 3);
			
			v.vertex.xyz += v.normal * ph * 0.1;
			
			data.height = 1 - (ph * 0.3);
		}
		

		void surf (Input IN, inout SurfaceOutput o) {

			o.Emission = lerp(_Color.rgb, _Color2.rgb, IN.height);
			
			o.Alpha = 1.0;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
