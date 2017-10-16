// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Encrypted Key Shader"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color1("Color 1", Color) = (0.04249566,0.9251356,0.9632353,0)
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		[IntRange]_Float2("Float 2", Range( 1 , 20)) = 5
		_ColorPulseIntensity("Color Pulse Intensity", Range( 0 , 0.8)) = 3
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
		uniform float _Float2;
		uniform float _ColorPulseIntensity;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 appendResult26 = float2( _Float2 , _Float2 );
			o.texcoord_0.xy = v.texcoord.xy * appendResult26 + float2( 0,0 );
		}

		inline fixed4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return fixed4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float mulTime22 = _Time.y * 1.5;
			o.Emission = ( ( _Color1 * tex2D( _TextureSample1, i.texcoord_0 ) ) * ( ( sin( mulTime22 ) + 1.5 ) * _ColorPulseIntensity ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13201
1543;29;1522;788;1387.4;241.1875;1.3;True;True
Node;AmplifyShaderEditor.RangedFloatNode;23;-988.043,296.2697;Float;False;Constant;_Float0;Float 0;1;0;1.5;0;5;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;25;-1649.277,-418.932;Float;False;Property;_Float2;Float 2;6;1;[IntRange];5;1;20;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleTimeNode;22;-685.043,351.2697;Float;False;1;0;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.AppendNode;26;-1309.277,-394.932;Float;False;FLOAT2;0;0;0;0;4;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.SinOpNode;21;-463.0429,392.2697;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;27;-1099.634,-253.89;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;5;-754.7961,527.577;Float;False;Property;_ColorPulseIntensity;Color Pulse Intensity;9;0;3;0;0.8;0;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;28;-782.421,-460.0555;Float;False;Property;_Color1;Color 1;0;0;0.04249566,0.9251356,0.9632353,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;29;-803.525,-269.2862;Float;True;Property;_TextureSample1;Texture Sample 1;1;0;Assets/UdacityVR/Art/Textures/walls.png;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-460.0429,252.2697;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;1.5;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-428.1249,-301.286;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-291.0429,315.2697;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-219.0429,72.2697;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Encrypted Key Shader;False;False;False;False;True;True;True;True;True;True;True;True;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;False;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;14;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;22;0;23;0
WireConnection;26;0;25;0
WireConnection;26;1;25;0
WireConnection;21;0;22;0
WireConnection;27;0;26;0
WireConnection;29;1;27;0
WireConnection;20;0;21;0
WireConnection;30;0;28;0
WireConnection;30;1;29;0
WireConnection;16;0;20;0
WireConnection;16;1;5;0
WireConnection;12;0;30;0
WireConnection;12;1;16;0
WireConnection;0;2;12;0
ASEEND*/
//CHKSM=83F2E39CD3A4A199524E55B01D01FB14ED0AADDA