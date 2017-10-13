// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ASESampleShaders/TextureArray"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_TextureArrayAlbedo("Texture Array Albedo", 2DArray ) = "" {}
		_TextureArrayNormal("Texture Array Normal", 2DArray ) = "" {}
		_NormalScale("Normal Scale", Float) = 1
		_RoughScale("Rough Scale", Range( 0 , 1)) = 0.1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.5
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform UNITY_DECLARE_TEX2DARRAY( _TextureArrayNormal );
		uniform float4 _TextureArrayNormal_ST;
		uniform float _NormalScale;
		uniform UNITY_DECLARE_TEX2DARRAY( _TextureArrayAlbedo );
		uniform float4 _TextureArrayAlbedo_ST;
		uniform float _RoughScale;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_TextureArrayNormal = i.uv_texcoord * _TextureArrayNormal_ST.xy + _TextureArrayNormal_ST.zw;
			float3 texArray103 = UnpackScaleNormal( UNITY_SAMPLE_TEX2DARRAY(_TextureArrayNormal, float3(uv_TextureArrayNormal, 0.0)  ) ,_NormalScale );
			o.Normal = texArray103;
			float2 uv_TextureArrayAlbedo = i.uv_texcoord * _TextureArrayAlbedo_ST.xy + _TextureArrayAlbedo_ST.zw;
			float4 texArray108 = UNITY_SAMPLE_TEX2DARRAY(_TextureArrayAlbedo, float3(uv_TextureArrayAlbedo, 3.0)  );
			o.Albedo = texArray108.xyz;
			float4 texArray105 = UNITY_SAMPLE_TEX2DARRAY(_TextureArrayAlbedo, float3(uv_TextureArrayAlbedo, 0.0)  );
			o.Smoothness = ( texArray105.x * _RoughScale );
			float4 texArray104 = UNITY_SAMPLE_TEX2DARRAY(_TextureArrayAlbedo, float3(uv_TextureArrayAlbedo, 1.0)  );
			o.Occlusion = texArray104.x;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13201
1580;55;1522;788;579.103;347.1375;1;True;True
Node;AmplifyShaderEditor.RangedFloatNode;109;-560,64;Float;False;Constant;_RoughnessIndex;Roughness Index;1;0;0;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;111;-560,-176;Float;False;Constant;_NormalIndex;Normal Index;1;0;0;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;123;-560,-80;Float;False;Property;_NormalScale;Normal Scale;2;0;1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;118;-304,240;Float;False;Property;_RoughScale;Rough Scale;3;0;0.1;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;110;-544,320;Float;False;Constant;_OcclusionIndex;Occlusion Index;1;0;1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.TextureArrayNode;105;-310.502,63.60038;Float;True;Property;_TextureArray2;Texture Array 2;1;0;None;0;Instance;108;Auto;False;7;6;SAMPLER2D;;False;0;FLOAT2;0,0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;1.0;False;4;FLOAT2;0,0;False;5;FLOAT2;0,0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;113;-553.9034,-373.3005;Float;False;Constant;_AlbedoIndex;Albedo Index;1;0;3;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.TextureArrayNode;104;-320,320;Float;True;Property;_TextureArray3;Texture Array 3;1;0;None;0;Instance;108;Auto;False;7;6;SAMPLER2D;;False;0;FLOAT2;0,0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;1.0;False;4;FLOAT2;0,0;False;5;FLOAT2;0,0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TextureArrayNode;108;-306.7961,-432.2489;Float;True;Property;_TextureArrayAlbedo;Texture Array Albedo;0;0;None;0;Object;-1;Auto;False;7;6;SAMPLER2D;;False;0;FLOAT2;0,0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;1.0;False;4;FLOAT2;0,0;False;5;FLOAT2;0,0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;117;99.54906,25.52966;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureArrayNode;103;-304,-192;Float;True;Property;_TextureArrayNormal;Texture Array Normal;1;0;None;0;Object;-1;Auto;True;7;6;SAMPLER2D;;False;0;FLOAT2;0,0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;1.0;False;4;FLOAT2;0,0;False;5;FLOAT2;0,0;False;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;407.6068,-183.0747;Float;False;True;3;Float;ASEMaterialInspector;0;0;StandardSpecular;ASESampleShaders/TextureArray;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0;False;11;FLOAT3;0.0,0,0;False;12;FLOAT3;0.0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;105;1;109;0
WireConnection;104;1;110;0
WireConnection;108;1;113;0
WireConnection;117;0;105;1
WireConnection;117;1;118;0
WireConnection;103;1;111;0
WireConnection;103;3;123;0
WireConnection;0;0;108;0
WireConnection;0;1;103;0
WireConnection;0;4;117;0
WireConnection;0;5;104;1
ASEEND*/
//CHKSM=822C56E9C71C7A0E4759C9D2CCAE949849838B02