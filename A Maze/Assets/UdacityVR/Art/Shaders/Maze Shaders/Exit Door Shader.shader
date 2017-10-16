// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Exit Door Shader"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color1("Color 1", Color) = (0.04249566,0.9251356,0.9632353,0)
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		[IntRange]_PatternSize("Pattern Size", Range( 1 , 20)) = 5
		_GlowIntensity("Glow Intensity", Range( 0 , 0.8)) = 3
		_PatternSpeed("Pattern Speed", Range( -10 , 10)) = 3
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
		uniform float _PatternSize;
		uniform float _PatternSpeed;
		uniform float _GlowIntensity;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 appendResult2 = float2( _PatternSize , _PatternSize );
			float2 appendResult10 = float2( 1 , ( _Time * _PatternSpeed ).x );
			o.texcoord_0.xy = v.texcoord.xy * appendResult2 + appendResult10;
		}

		inline fixed4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return fixed4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float mulTime23 = _Time.y * 1.5;
			o.Emission = ( ( _Color1 * tex2D( _TextureSample1, i.texcoord_0 ) ) * ( ( sin( mulTime23 ) + 1.5 ) * _GlowIntensity ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13201
1543;29;1522;788;2071.84;636.0781;2.043891;True;True
Node;AmplifyShaderEditor.RangedFloatNode;18;-1574.908,673.609;Float;False;Property;_PatternSpeed;Pattern Speed;9;0;3;-10;10;0;1;FLOAT
Node;AmplifyShaderEditor.TimeNode;17;-1501.316,480.454;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;22;-865.5613,682.9898;Float;False;Constant;_GlowSpeed;Glow Speed;1;0;1.5;0;5;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-1258.78,603.8679;Float;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.RangedFloatNode;1;-1485.234,-38.20172;Float;False;Property;_PatternSize;Pattern Size;6;1;[IntRange];5;1;20;0;1;FLOAT
Node;AmplifyShaderEditor.Vector2Node;12;-1296.453,347.229;Float;False;Constant;_Vector1;Vector 1;6;0;0,1;0;3;FLOAT2;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleTimeNode;23;-562.5613,737.9898;Float;False;1;0;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.AppendNode;10;-1017.853,461.828;Float;False;FLOAT2;0;0;0;0;4;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.AppendNode;2;-1145.234,-14.20172;Float;False;FLOAT2;0;0;0;0;4;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.SinOpNode;24;-340.5612,778.9898;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-935.591,126.8403;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;25;-632.3144,914.2971;Float;False;Property;_GlowIntensity;Glow Intensity;9;0;3;0;0.8;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;5;-639.482,111.4441;Float;True;Property;_TextureSample1;Texture Sample 1;1;0;Assets/UdacityVR/Art/Textures/walls.png;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;4;-618.378,-79.32523;Float;False;Property;_Color1;Color 1;0;0;0.04249566,0.9251356,0.9632353,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;26;-337.5612,638.9898;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;1.5;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-168.5612,701.9898;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-264.0819,79.44427;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-96.5612,458.9898;Float;False;2;2;0;COLOR;0;False;1;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Exit Door Shader;False;False;False;False;True;True;True;True;True;True;True;True;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;False;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;14;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;19;0;17;0
WireConnection;19;1;18;0
WireConnection;23;0;22;0
WireConnection;10;0;12;2
WireConnection;10;1;19;0
WireConnection;2;0;1;0
WireConnection;2;1;1;0
WireConnection;24;0;23;0
WireConnection;3;0;2;0
WireConnection;3;1;10;0
WireConnection;5;1;3;0
WireConnection;26;0;24;0
WireConnection;27;0;26;0
WireConnection;27;1;25;0
WireConnection;6;0;4;0
WireConnection;6;1;5;0
WireConnection;21;0;6;0
WireConnection;21;1;27;0
WireConnection;0;2;21;0
ASEEND*/
//CHKSM=738AA2BF21C76FF93B67FB0ECEC95D7AC951824A