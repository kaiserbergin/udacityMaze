// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Decryption Fragment Shader"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color1("Color 1", Color) = (0.04249566,0.9251356,0.9632353,0)
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		[IntRange]_DecryptPatternSize("Decrypt Pattern Size", Range( 1 , 20)) = 5
		_DecryptPatternIntensity("Decrypt Pattern Intensity", Range( 0 , 0.8)) = 3
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
		uniform float _DecryptPatternSize;
		uniform float _DecryptPatternIntensity;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 appendResult4 = float2( _DecryptPatternSize , _DecryptPatternSize );
			o.texcoord_0.xy = v.texcoord.xy * appendResult4 + float2( 0,0 );
		}

		inline fixed4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return fixed4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float mulTime3 = _Time.y * 1.5;
			o.Emission = ( ( _Color1 * tex2D( _TextureSample1, i.texcoord_0 ) ) * ( ( sin( mulTime3 ) + 1.5 ) * _DecryptPatternIntensity ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13201
1543;29;1522;788;2446.301;728.7371;2.125637;True;True
Node;AmplifyShaderEditor.RangedFloatNode;2;-1710.963,-335.7309;Float;False;Property;_DecryptPatternSize;Decrypt Pattern Size;6;1;[IntRange];5;1;20;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;1;-1049.73,379.4709;Float;False;Constant;_DecyptTimeMultiplier;Decypt Time Multiplier;1;0;1.5;0;5;0;1;FLOAT
Node;AmplifyShaderEditor.AppendNode;4;-1370.963,-311.7308;Float;False;FLOAT2;0;0;0;0;4;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.SimpleTimeNode;3;-746.7302,434.4709;Float;False;1;0;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;6;-1161.321,-170.6888;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SinOpNode;5;-524.7298,475.4708;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;10;-521.7298,335.4709;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;1.5;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;9;-816.4834,610.778;Float;False;Property;_DecryptPatternIntensity;Decrypt Pattern Intensity;9;0;3;0;0.8;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;8;-865.2123,-186.085;Float;True;Property;_TextureSample1;Texture Sample 1;1;0;Assets/UdacityVR/Art/Textures/walls.png;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;7;-844.1083,-376.8543;Float;False;Property;_Color1;Color 1;0;0;0.04249566,0.9251356,0.9632353,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-489.8118,-218.0848;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-352.7297,398.4709;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-280.7297,155.4709;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Decryption Fragment Shader;False;False;False;False;True;True;True;True;True;True;True;True;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;False;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;14;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;2;0
WireConnection;4;1;2;0
WireConnection;3;0;1;0
WireConnection;6;0;4;0
WireConnection;5;0;3;0
WireConnection;10;0;5;0
WireConnection;8;1;6;0
WireConnection;12;0;7;0
WireConnection;12;1;8;0
WireConnection;11;0;10;0
WireConnection;11;1;9;0
WireConnection;13;0;12;0
WireConnection;13;1;11;0
WireConnection;0;2;13;0
ASEEND*/
//CHKSM=63BF68E064AF240F0672D12636659A6A360625D5