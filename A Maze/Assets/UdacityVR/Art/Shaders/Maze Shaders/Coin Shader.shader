// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Coin Shader"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color1("Color 1", Color) = (0.04249566,0.9251356,0.9632353,0)
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		[IntRange]_Float1("Float 1", Range( 1 , 20)) = 5
		_Float5("Float 5", Range( 0 , 2)) = 3
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha noshadow noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd vertex:vertexDataFunc 
		struct Input
		{
			float2 texcoord_0;
		};

		uniform float4 _Color1;
		uniform sampler2D _TextureSample1;
		uniform float _Float1;
		uniform float _Float5;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 appendResult3 = float2( _Float1 , _Float1 );
			o.texcoord_0.xy = v.texcoord.xy * appendResult3 + float2( 0,0 );
		}

		inline fixed4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return fixed4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float mulTime4 = _Time.y * 2.963272;
			o.Emission = ( ( _Color1 * tex2D( _TextureSample1, i.texcoord_0 ) ) * ( ( sin( mulTime4 ) + 1.5 ) * _Float5 ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13201
1543;29;1522;788;1580.636;-0.5453138;1.3;True;True
Node;AmplifyShaderEditor.RangedFloatNode;1;-1735.175,-328.3023;Float;False;Property;_Float1;Float 1;6;1;[IntRange];5;1;20;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;2;-1073.942,386.8994;Float;False;Constant;_Float3;Float 3;1;0;2.963272;0;5;0;1;FLOAT
Node;AmplifyShaderEditor.AppendNode;3;-1395.175,-304.3022;Float;False;FLOAT2;0;0;0;0;4;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.SimpleTimeNode;4;-770.9424,441.8994;Float;False;1;0;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;5;-1185.533,-163.2602;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SinOpNode;6;-548.942,482.8994;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;7;-545.942,342.8994;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;1.5;False;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;9;-889.4245,-178.6564;Float;True;Property;_TextureSample1;Texture Sample 1;1;0;Assets/UdacityVR/Art/Textures/walls.png;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;10;-868.3205,-369.4258;Float;False;Property;_Color1;Color 1;0;0;0.04249566,0.9251356,0.9632353,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;8;-840.6956,618.2065;Float;False;Property;_Float5;Float 5;9;0;3;0;2;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-514.024,-210.6562;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-376.9419,405.8994;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-304.9419,162.8995;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Coin Shader;False;False;False;False;True;True;True;True;True;True;True;True;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;False;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;14;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;1;0
WireConnection;3;1;1;0
WireConnection;4;0;2;0
WireConnection;5;0;3;0
WireConnection;6;0;4;0
WireConnection;7;0;6;0
WireConnection;9;1;5;0
WireConnection;11;0;10;0
WireConnection;11;1;9;0
WireConnection;12;0;7;0
WireConnection;12;1;8;0
WireConnection;13;0;11;0
WireConnection;13;1;12;0
WireConnection;0;2;13;0
ASEEND*/
//CHKSM=AE8CB9FAFBF83B3FE8104E75D8C58FA13210AA18