Shader "HDRP SHADOWS SM CLOUDS FULL VOLUME HDRP10_2A"
    {
        Properties
        {

			//v0.1 NASOS HDRP CLOUD SHADOWS
			_CloudMap("_CloudMap", 2D) = "white" {}
			_CloudMap1("_CloudMap1", 2D) = "white" {}
			_PaintMap("_PaintMap", 2D) = "white" {}
			_Density("_Density", Float) = 0.1
			_Coverage("_Coverage", Float) = 0.1
			_CutHeight("_CutHeight", Float) = 0.1
			_CoverageOffset("_CoverageOffset", Float) = 0.1
			_Transparency("_Transparency", Float) = 0.1
			_TranspOffset("_TranspOffset", Float) = 0.1
			Thickness("Thickness", Float) = 0.1
			_Cutoff("_Cutoff", Float) = 0.1
			_Velocity1("_Velocity1", Vector) = (1, 1 ,0, 0)
			_Velocity2("_Velocity2", Vector) = (1, 1,0, 0)
			_EdgeFactors("_EdgeFactors", Vector) = (1, 1,0, 0)

				//CHOOSE MODE, 0 = 2D noise shader clouds, 1 = image effect 3D noise clouds
				_shadowMode("Shadow Mode (0,1)", Float) = 0

				//FULL VOLUME SHADOWS
				//v3.5 clouds
				_SampleCount0("Sample Count (min)", Float) = 30
				_SampleCount1("Sample Count (max)", Float) = 90
				_SampleCountL("Sample Count (light)", Int) = 16
				[Space]
				_NoiseTex1("Noise Volume", 3D) = ""{}
				_NoiseTex2("Noise Volume", 3D) = ""{}
				_NoiseFreq1("Frequency 1", Float) = 3.1
				_NoiseFreq2("Frequency 2", Float) = 35.1
				_NoiseAmp1("Amplitude 1", Float) = 5
				_NoiseAmp2("Amplitude 2", Float) = 1
				_NoiseBias("Bias", Float) = -0.2
				[Space]
				_Scroll1("Scroll Speed 1", Vector) = (0.01, 0.08, 0.06, 0)
				_Scroll2("Scroll Speed 2", Vector) = (0.01, 0.05, 0.03, 0)
				timeDelay("timeDelay", Float) = 0
				[Space]
				_Altitude0("Altitude (bottom)", Float) = 1500
				_Altitude1("Altitude (top)", Float) = 3500
				_FarDist("Far Distance", Float) = 30000
					//v3.5 clouds
					_BackShade("Back shade of cloud top", Float) = 1
					_UndersideCurveFactor("Underside Curve Factor", Float) = 0
					//v3.5.3
					_InteractTexture("_Interact Texture", 2D) = "white" {}
					_InteractTexturePos("Interact Texture Pos", Vector) = (1 ,1, 0, 0)
					_InteractTextureAtr("Interact Texture Attributes - 2multi 2offset", Vector) = (1 ,1, 0, 0)
					_InteractTextureOffset("Interact Texture offsets", Vector) = (0 ,0, 0, 0) //v4.0
					 //v3.5.1
					_NearZCutoff("Away from camera Cutoff", Float) = -2
					_HorizonYAdjust("Adjust horizon Height", Float) = 0
					_FadeThreshold("Fade Near", Float) = 0
						//v5.0c
						_LocalLightPos("Local Light Pos & Intensity", Vector) = (0 ,0, 0, 0) //local light position (x,y,z) and intensity (w)


						//FULL VOLUME CLOUDS
						_WeatherMap("_WeatherMap", 2D) = "white" {}
						_WeatherScale("_WeatherScale", Float) = 0
						_CoverageA("_CoverageA", Float) = 0
						_WindSpeed("_WindSpeed", Float) = 0
						_WindDirection("_WindDirection", Vector) = (0 ,0, 0, 0)
						_WindOffset("_WindOffset", Vector) = (0 ,0, 0, 0)
						_CoverageWindOffset("_CoverageWindOffset", Vector) = (0 ,0, 0, 0)

            [NoScaleOffset]Texture2D_5343010B("Texture2D", 2D) = "white" {}
            Vector1_4F56884("Vector1", Float) = 0
            [HideInInspector]_EmissionColor("Color", Color) = (1, 1, 1, 1)
            [HideInInspector]_RenderQueueType("Float", Float) = 4
            [HideInInspector][ToggleUI]_AddPrecomputedVelocity("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_DepthOffsetEnable("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_TransparentWritingMotionVec("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_AlphaCutoffEnable("Boolean", Float) = 1
            [HideInInspector]_TransparentSortPriority("_TransparentSortPriority", Float) = 0
            [HideInInspector][ToggleUI]_UseShadowThreshold("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_DoubleSidedEnable("Boolean", Float) = 1
            [HideInInspector][Enum(Flip, 0, Mirror, 1, None, 2)]_DoubleSidedNormalMode("Float", Float) = 2
            [HideInInspector]_DoubleSidedConstants("Vector4", Vector) = (1, 1, -1, 0)
            [HideInInspector][ToggleUI]_TransparentDepthPrepassEnable("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_TransparentDepthPostpassEnable("Boolean", Float) = 0
            [HideInInspector]_SurfaceType("Float", Float) = 1
            [HideInInspector]_BlendMode("Float", Float) = 0
            [HideInInspector]_SrcBlend("Float", Float) = 1
            [HideInInspector]_DstBlend("Float", Float) = 0
            [HideInInspector]_AlphaSrcBlend("Float", Float) = 1
            [HideInInspector]_AlphaDstBlend("Float", Float) = 0
            [HideInInspector][ToggleUI]_AlphaToMask("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_AlphaToMaskInspectorValue("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_ZWrite("Boolean", Float) = 1
            [HideInInspector][ToggleUI]_TransparentZWrite("Boolean", Float) = 1
            [HideInInspector]_CullMode("Float", Float) = 2
            [HideInInspector][ToggleUI]_EnableFogOnTransparent("Boolean", Float) = 1
            [HideInInspector]_CullModeForward("Float", Float) = 2
            [HideInInspector][Enum(Front, 1, Back, 2)]_TransparentCullMode("Float", Float) = 2
            [HideInInspector][Enum(UnityEditor.Rendering.HighDefinition.OpaqueCullMode)]_OpaqueCullMode("Float", Float) = 2
            [HideInInspector]_ZTestDepthEqualForOpaque("Float", Int) = 4
            [HideInInspector][Enum(UnityEngine.Rendering.CompareFunction)]_ZTestTransparent("Float", Float) = 4
            [HideInInspector][ToggleUI]_TransparentBackfaceEnable("Boolean", Float) = 0
            [HideInInspector][ToggleUI]_EnableBlendModePreserveSpecularLighting("Boolean", Float) = 0
            [HideInInspector]_StencilRef("Float", Int) = 0
            [HideInInspector]_StencilWriteMask("Float", Int) = 6
            [HideInInspector]_StencilRefDepth("Float", Int) = 0
            [HideInInspector]_StencilWriteMaskDepth("Float", Int) = 8
            [HideInInspector]_StencilRefMV("Float", Int) = 32
            [HideInInspector]_StencilWriteMaskMV("Float", Int) = 40
            [HideInInspector]_StencilRefDistortionVec("Float", Int) = 4
            [HideInInspector]_StencilWriteMaskDistortionVec("Float", Int) = 4
            [HideInInspector]_StencilWriteMaskGBuffer("Float", Int) = 14
            [HideInInspector]_StencilRefGBuffer("Float", Int) = 2
            [HideInInspector]_ZTestGBuffer("Float", Int) = 4
            [HideInInspector][NoScaleOffset]unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
            [HideInInspector][NoScaleOffset]unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
            [HideInInspector][NoScaleOffset]unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
        }
        SubShader
        {
            Tags
            {
                "RenderPipeline"="HDRenderPipeline"
                "RenderType"="HDUnlitShader"
                "Queue"="Transparent+0"
            }
            Pass
            {
                Name "ShadowCaster"
                Tags
                {
                    "LightMode" = "ShadowCaster"
                }
    
                // Render State
                Cull [_CullMode]
                ZWrite On
                ColorMask 0
                ZClip [_ZClip]
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
                #pragma multi_compile_instancing
                #pragma instancing_options renderinglayer
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_SHADOWS
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)


					//v0.1 NASOS
					float _Density = 0.1;
				float _Coverage = 0.1;
				float _CutHeight = 0.1;
				float _CoverageOffset = 0.1;
				float _Transparency = 0.1;
				float _TranspOffset = 0.1;
				float Thickness = 0.1;
				float _Cutoff = 0.2;
				float2 _Velocity1 = float2(1.0, 1.0);
				float2 _Velocity2 = float2(1.0, 1.0);
				float2 _EdgeFactors = float2(1.0, 1.0);

				float _shadowMode;

				//////////// IMAGE EFFECT CLOUDS v0.2
				float _SampleCount0 = 2;
				float _SampleCount1 = 3;
				int _SampleCountL = 4;
				float _NoiseFreq1 = 3.1;
				float _NoiseFreq2 = 35.1;
				float _NoiseAmp1 = 5;
				float _NoiseAmp2 = 1;
				float _NoiseBias = -0.2;
				float3 _Scroll1 = float3 (0.01, 0.08, 0.06);
				float3 _Scroll2 = float3 (0.01, 0.05, 0.03);
				float timeDelay;
				float _Altitude0 = 1500;
				float _Altitude1 = 3500;
				float _FarDist = 30000;
				//v3.5.3
				//sampler2D _InteractTexture;
				float4 _InteractTexturePos;
				float4 _InteractTextureAtr;
				float4 _InteractTextureOffset; //v4.0
											   //v3.5.1
				float _NearZCutoff;
				float _HorizonYAdjust;
				float _FadeThreshold;
				float _BackShade;
				float _UndersideCurveFactor;
				//v5.0c
				float4 _LocalLightPos;
				//////////// END IMAGE EFFECT CLOUDS v0.2


                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                


                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);






				TEXTURE2D(_CloudMap); SAMPLER(sampler_CloudMap); float4 _CloudMap_TexelSize;
				TEXTURE2D(_CloudMap1); SAMPLER(sampler_CloudMap1); float4 _CloudMap1_TexelSize;
				TEXTURE2D(_PaintMap); SAMPLER(sampler_PaintMap); float4 _PaintMap_TexelSize;

				//FULL VOLUME CLOUDS
				TEXTURE2D(_WeatherMap); SAMPLER(sampler_WeatherMap); float4 _WeatherMap_TexelSize; //_WeatherMap

				//////////// IMAGE EFFECT CLOUDS v0.2
				//sampler3D _NoiseTex1;
				//sampler3D _NoiseTex2;
				//sampler2D _InteractTexture;
				TEXTURE3D(_NoiseTex1); SAMPLER(sampler_NoiseTex1); float4 _NoiseTex1_TexelSize;
				TEXTURE3D(_NoiseTex2); SAMPLER(sampler_NoiseTex2); float4 _NoiseTex2_TexelSize;
				TEXTURE2D(_InteractTexture); SAMPLER(sampler_InteractTexture); float4 _InteractTexture_TexelSize;
				//v3.5 clouds
				float UVRandom(float2 uv)
				{
					float f = dot(float2(12.9898, 78.233), uv);
					return frac(43758.5453 * sin(f));
				}
				float SampleNoise(float3 uvw, float _Altitude1, float _NoiseAmp1, float Alpha)//v3.5.3
				{
					float AlphaFactor = clamp(Alpha*_InteractTextureAtr.w, _InteractTextureAtr.x, 1);
					const float baseFreq = 1e-5;
					float4 uvw1 = float4(uvw * _NoiseFreq1 * baseFreq, 0);
					float4 uvw2 = float4(uvw * _NoiseFreq2 * baseFreq, 0);
					uvw1.xyz += _Scroll1.xyz * (_Time.x + timeDelay);
					uvw2.xyz += _Scroll2.xyz * (_Time.x + timeDelay);

					//float n1 = tex3Dlod(_NoiseTex1, uvw1).a;
					//float n2 = tex3Dlod(_NoiseTex2, uvw2).a;
					//v0.2
					float n1 = SAMPLE_TEXTURE3D(_NoiseTex1, sampler_NoiseTex1, uvw1).a;
					float n2 = SAMPLE_TEXTURE3D(_NoiseTex1, sampler_NoiseTex1, uvw2).a;

					float n = n1 * _NoiseAmp1*AlphaFactor + n2 * _NoiseAmp2;//v3.5.3
					n = saturate(n + _NoiseBias);
					float y = uvw.y - _Altitude0;
					float h = _Altitude1 * 1 - _Altitude0;//v3.5.3
					n *= smoothstep(0, h * (0.1 + _UndersideCurveFactor), y);
					n *= smoothstep(0, h * 0.4, h - y);
					return n;
				}
				float BeerPowder(float depth)
				{
					float _Extinct = 0.01;
					return exp(-_Extinct * depth) * (1 - exp(-_Extinct * 2 * depth));
				}
				float Beer(float depth)
				{
					float _Extinct = 0.01;
					return exp(-_Extinct * depth * _BackShade);  // return exp(-_Extinct * depth); //_BackShade v3.5
				}
				//////////// END IMAGE EFFECT CLOUDS v0.2







    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float Alpha;
                    float AlphaClipThreshold;
                };
                




				//FULLVOLUME CLOUDS
					//uniform float _Coverage;
				uniform float _WeatherScale;
				uniform float _CoverageA;
				uniform float _WindSpeed;
				uniform float3 _WindDirection;
				uniform float3 _WindOffset;
				uniform float2 _CoverageWindOffset;
				// samples weather texture
				float3 sampleWeather(float3 pos) {
					//float3 weatherData = tex2Dlod(_WeatherMap, float4((pos.xz + _CoverageWindOffset) * _WeatherScale, 0, 0)).rgb;
					//float3 weatherData = tex2D(_WeatherMap, float2((pos.xz + _CoverageWindOffset) * _WeatherScale)).rgb;
					//float3 weatherData = SAMPLE_TEXTURE2D(_WeatherMap, sampler_WeatherMap, float2((pos.xz + _CoverageWindOffset) * _WeatherScale*0.1)).rgb;
					float3 weatherData = SAMPLE_TEXTURE2D(_WeatherMap, sampler_WeatherMap,
						float2((pos.xz + _CoverageWindOffset) * _WeatherScale*0.1) + float2(_WindDirection.x*_Time.y*_WindSpeed, _WindDirection.z*_Time.y*_WindSpeed)).rgb;
					weatherData.r = saturate(weatherData.r - _CoverageA);

					//v0.2
					//float4 texInteract = tex2Dlod(_InteractTexture, 0.0003*float4(
					//	_InteractTexturePos.x*pos.x + _InteractTexturePos.z * _Time.x + _InteractTextureOffset.x,
					//	_InteractTexturePos.y*pos.z + _InteractTexturePos.w * _Time.x + _InteractTextureOffset.y,
					//	0, 0));
					float4 texInteract = SAMPLE_TEXTURE2D(_InteractTexture, sampler_InteractTexture, float2(
						_InteractTexturePos.x*pos.x + _InteractTexturePos.z * _Time.x + _InteractTextureOffset.x,
						_InteractTexturePos.y*pos.z + _InteractTexturePos.w * _Time.x + _InteractTextureOffset.y));
					float3 _LocalLightPos = float3(0, 0, 0);
					float diffPos = length(_LocalLightPos.xyz - pos);
					texInteract.a = texInteract.a + clamp(_InteractTextureAtr.z * 0.1*(1 - 0.00024*diffPos), -1.5, 0);
					weatherData = weatherData * clamp(texInteract.a*_InteractTextureAtr.w, _InteractTextureAtr.y, 1);

					return weatherData;
				}










                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;




					////// NASOS HDRP SHADOWS						
					if (_shadowMode == 0) {
						float3 woeldPos = IN.WorldSpacePosition + _WorldSpaceCameraPos; // MAKE CAMERA RELATIVE !!! for HDRP
						float change_h = _CutHeight;
						float PosDiff = 0.0006*(woeldPos.y - change_h); //float PosDiff = 0.0006*(i.worldPos.y - change_h);
						float2 UVs = _Density * float2(woeldPos.x, woeldPos.z);
						float4 TimingF = 0.0012;
						float2 UVs1 = _Velocity1 * TimingF*_Time.y + UVs;
						//float4 cloudTexture = tex2D(_CloudMap, UVs1 + _CloudMap_ST);
						//float4 cloudTexture1 = tex2D(_CloudMap1, UVs1 + _CloudMap1_ST);
						//float4 paintTexture1 = tex2D(_PaintMap, UVs1*_PaintMap_ST.xy + _PaintMap_ST.zw);
						float4 cloudTexture = SAMPLE_TEXTURE2D(_CloudMap, sampler_CloudMap, UVs1);
						float4 cloudTexture1 = SAMPLE_TEXTURE2D(_CloudMap1, sampler_CloudMap1, UVs1);
						float4 paintTexture1 = SAMPLE_TEXTURE2D(_PaintMap, sampler_PaintMap, UVs1);

						float2 UVs2 = (_Velocity2*TimingF*_Time.y / 1.4 + float2(_EdgeFactors.x, _EdgeFactors.y) + UVs);
						//float4 Texture1 = tex2D(_CloudMap, UVs2 + _CloudMap_ST);
						//float4 Texture2 = tex2D(_CloudMap1, UVs2 + _CloudMap1_ST);
						float4 Texture1 = SAMPLE_TEXTURE2D(_CloudMap, sampler_CloudMap, UVs2);
						float4 Texture2 = SAMPLE_TEXTURE2D(_CloudMap1, sampler_CloudMap1, UVs2);

						float DER = woeldPos.y*0.001;
						float3 normalA = (((DER*((_Coverage + _CoverageOffset) + ((cloudTexture.rgb * 2) - 1))) - (1 - (Texture1.rgb * 2))));
						float3 normalN = normalize(normalA);

						float DER1 = -(woeldPos.y - 0) * 1;
						float PosTDiff = woeldPos.y * 1;
						if (woeldPos.y > change_h) {
							DER1 = (1 - cloudTexture1.a) *  PosTDiff;
						}
						float shaper = ((_Transparency + _TranspOffset) - 0.48 + 0.0)*((DER1*(((_Coverage + _CoverageOffset) + cloudTexture1.a)))*Texture2.a);
						change_h = 10;
						PosDiff = Thickness * 0.0006*(woeldPos.y - change_h);
						PosTDiff = woeldPos.y*PosDiff;
						DER1 = -(woeldPos.y + 0)*PosDiff;
						if (woeldPos.y > change_h) {
							DER1 = (1 - cloudTexture1.a) *  PosTDiff;
						}
						if (woeldPos.y > 150) { 																																///////////////////////////// 650
							DER1 = (1 - cloudTexture1.a) *  PosTDiff*0.07;
							shaper = shaper * shaper;
						}
						//clip(shaper*paintTexture1 - _Cutoff + 0.4);
						///SHADOW_CASTER_FRAGMENT(i)
						//surface.AlphaClipThreshold = 1- (saturate(shaper) - _Cutoff + 0.4);// saturate(shaper * 0.001);
						surface.AlphaClipThreshold = 1 - (((shaper)*paintTexture1) - _Cutoff + 0.4);
						surface.Alpha = 0;// _Cutoff + 0.4;// -_Cutoff + 0.4;
						///// END NASOS HDRP SHADOWS
					}

					if (_shadowMode == 1) {
						//FULL VOLUME CLOUD SHADOWS
						float3 pos = IN.WorldSpacePosition + _WorldSpaceCameraPos;// i.worldPos;
						int samples = 2;
						float depth = 0;

						float3 PixelWorld = pos + _WorldSpaceCameraPos + float3(0, _HorizonYAdjust, 0);
						float3 ray = PixelWorld;

						float dist0 = _Altitude0 / ray.y;
						float dist1 = _Altitude1 / ray.y;
						float stride = (dist1 - dist0) / samples;

						float2 uv = IN.uv0 + _Time.x;
						float offs = UVRandom(uv) * (dist1 - dist0) / samples;

						float3 acc = 0;

						//v4.0			
						//float4 texInteract = tex2Dlod(_InteractTexture, 0.0003*float4(
						//	_InteractTexturePos.x*pos.x + _InteractTexturePos.z*-_Scroll1.x * (_Time.x + timeDelay) + _InteractTextureOffset.x,
						//	_InteractTexturePos.y*pos.z + _InteractTexturePos.w*-_Scroll1.z * (_Time.x + timeDelay) + _InteractTextureOffset.y,
						//	0, 0));
						//SAMPLE_TEXTURE3D(_NoiseTex1, sampler_NoiseTex1, uvw1)
						float4 texInteract = SAMPLE_TEXTURE2D(_InteractTexture, sampler_InteractTexture, 0.0003*float4(
							_InteractTexturePos.x*pos.x + _InteractTexturePos.z*-_Scroll1.x * (_Time.x + timeDelay) + _InteractTextureOffset.x,
							_InteractTexturePos.y*pos.z + _InteractTexturePos.w*-_Scroll1.z * (_Time.x + timeDelay) + _InteractTextureOffset.y,
							0, 0));

						timeDelay = 21110;//offset time 

						UNITY_LOOP for (int s = 0; s < samples; s++)
						{
							//v5.0c - add local light
							float diffPos = length(_LocalLightPos.xyz - pos);

							//texInteract.a = texInteract.a + clamp(_InteractTextureAtr.z * 0.1*(1 - 0.00024*diffPos), -1112.5, 10);// CHANGED IN HDRP to -_InteractTextureAtr.z
							texInteract.a = texInteract.a + clamp(_InteractTextureAtr.z * 0.1*(1 - 0.00024*diffPos), -1112.5, 10);

							_NoiseAmp2 = _NoiseAmp2 * clamp(texInteract.a*_InteractTextureAtr.w, _InteractTextureAtr.y, 2);

							float n = SampleNoise(pos, _Altitude1, _NoiseAmp1, texInteract.a);
							if (n > 0)
							{
								float density = n * stride;
								float rand = UVRandom(uv + s + 1);
								float scatter = 0.1;
								//acc += _LightColor0 * scatter* BeerPowder(depth) + BeerPowder(depth) * scatter;//v2.1.19
								acc += 1 * scatter* BeerPowder(depth) + BeerPowder(depth) * scatter;//v2.1.19
								depth += density;
							}
							pos += ray * stride;
						}
						acc += Beer(depth) * 1 + 1 * 1 * acc;
						acc = lerp(acc, 1 * 0.96, saturate(((dist0) / (_FarDist*0.5))) + 0.03);
						float4 finalColor = float4(acc, 1);

						//v4.0
						pos = IN.WorldSpacePosition + _WorldSpaceCameraPos;
						float n2 = SampleNoise(pos, _Altitude1, _NoiseAmp1, (texInteract.a)*0.0001*(1 - _InteractTextureAtr.x + 0.6));
						float n22 = SampleNoise(pos + float3(0, 2000, 0), _Altitude1 + 1050, _NoiseAmp1, 1);
						float n33 = SampleNoise(pos + float3(0, 0, 0), _Altitude1 + 0, _NoiseAmp1, 1);
						//clip(-((1111 + ((1 - texInteract.a) * 1) * 31111 * (1 - _InteractTextureAtr.x)) - (n22 + n22) * 18100) - _Cutoff + 0.4);//v5.0c

						//CHANGED IN HDRP by remove (1-) - ADDED SATURATE !!!
						surface.AlphaClipThreshold = 1 - (-((1111 + ((1 - saturate(texInteract.a)) * 1) * 31111 * (1 - _InteractTextureAtr.x)) - (n22 + n22) * 18100) - _Cutoff + 0.4);
						//surface.AlphaClipThreshold = (((1111 + ((1 - saturate(texInteract.a)) * 1) * 31111 * (1 - _InteractTextureAtr.x)) - (n22 + n22) * 18100) - _Cutoff + 0.4);

						surface.Alpha = 1;
						//SHADOW_CASTER_FRAGMENT(i)
					}

					//FULL VOLUME SHADOWS
					if (_shadowMode == 2) {
						float3 woeldPos = IN.WorldSpacePosition + _WorldSpaceCameraPos; // MAKE CAMERA RELATIVE !!! for HDRP
						float change_h = _CutHeight;
						float PosDiff = 0.0006*(woeldPos.y - change_h); //float PosDiff = 0.0006*(i.worldPos.y - change_h);
						float2 UVs = _Density * float2(woeldPos.x, woeldPos.z);
						float4 TimingF = 0.0012;
						float2 UVs1 = _Velocity1 * TimingF*_Time.y + UVs;

						float4 cloudTexture = SAMPLE_TEXTURE2D(_WeatherMap, sampler_WeatherMap, UVs1);
						float4 cloudTexture1 = SAMPLE_TEXTURE2D(_WeatherMap, sampler_WeatherMap, UVs1);
						float4 paintTexture1 = SAMPLE_TEXTURE2D(_PaintMap, sampler_PaintMap, UVs1);




						float2 UVs2 = (_Velocity2*TimingF*_Time.y / 1.4 + float2(_EdgeFactors.x, _EdgeFactors.y) + UVs);

						float4 Texture1 = SAMPLE_TEXTURE2D(_WeatherMap, sampler_WeatherMap, UVs2);
						float4 Texture2 = SAMPLE_TEXTURE2D(_WeatherMap, sampler_WeatherMap, UVs2);

						//FULL VOLUME
						cloudTexture.rgb = sampleWeather(1 * float3(woeldPos.x, 0, woeldPos.z));
						cloudTexture1.rgb = sampleWeather(1 * float3(woeldPos.x, 0, woeldPos.z));
						Texture1.rgb = sampleWeather(1 * float3(woeldPos.x, 0, woeldPos.z));
						Texture2.rgb = sampleWeather(1 * float3(woeldPos.x, 0, woeldPos.z));
						Texture1.a = Texture1.r + Texture1.g * 1 + Texture1.b * 0;
						Texture2.a = Texture2.r + Texture2.g * 1 + Texture2.b * 0;
						cloudTexture.a = cloudTexture.r + cloudTexture.g * 1 + cloudTexture.b * 0;
						cloudTexture1.a = cloudTexture1.r + cloudTexture1.g * 1 + cloudTexture1.b * 0;

						float DER = woeldPos.y*0.001;
						float3 normalA = (((DER*((_Coverage + _CoverageOffset) + ((cloudTexture.rgb * 2) - 1))) - (1 - (Texture1.rgb * 2))));
						float3 normalN = normalize(normalA);

						float DER1 = -(woeldPos.y - 0) * 1;
						float PosTDiff = woeldPos.y * 1;
						if (woeldPos.y > change_h) {
							DER1 = (1 - cloudTexture1.a) *  PosTDiff;
						}
						float shaper = ((_Transparency + _TranspOffset) - 0.48 + 0.0)*((DER1*(((_Coverage + _CoverageOffset) + cloudTexture1.a)))*Texture2.a);
						change_h = 10;
						PosDiff = Thickness * 0.0006*(woeldPos.y - change_h);
						PosTDiff = woeldPos.y*PosDiff;
						DER1 = -(woeldPos.y + 0)*PosDiff;
						if (woeldPos.y > change_h) {
							DER1 = (1 - cloudTexture1.a) *  PosTDiff;
						}
						if (woeldPos.y > 150) { 																																///////////////////////////// 650
							DER1 = (1 - cloudTexture1.a) *  PosTDiff*0.07;
							shaper = shaper * shaper;
						}


						//NEW
						//shaper = 1.6 * Texture2.r;// *(1 - Texture2.g);
						shaper = 1.5 *(Texture2.r) - 1.5*Texture2.b - 1.5*Texture2.g;

						//NEW
						//float3 weather = sampleWeather(float3(woeldPos.x, 0, woeldPos.z));
						//shaper = weather.r * shaper;

						//surface.AlphaClipThreshold = 1 - (((shaper)*paintTexture1) - _Cutoff + 0.4);
						surface.AlphaClipThreshold = 1 - (((shaper) * 1) - 0.45 + 0.4);
						surface.Alpha = 0;// _Cutoff + 0.4;// -_Cutoff + 0.4;
										  ///// END NASOS HDRP SHADOWS
					}




                    //surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    //surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "META"
                Tags
                {
                    "LightMode" = "META"
                }
    
                // Render State
                Cull Off
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
                #pragma multi_compile_instancing
                #pragma instancing_options renderinglayer
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define ATTRIBUTES_NEED_TEXCOORD1
                #define ATTRIBUTES_NEED_TEXCOORD2
                #define ATTRIBUTES_NEED_COLOR
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_LIGHT_TRANSPORT
                #define RAYTRACING_SHADER_GRAPH_DEFAULT
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    float4 uv1 : TEXCOORD1;
                    float4 uv2 : TEXCOORD2;
                    float4 color : COLOR;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassLightTransport.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "ScenePickingPass"
                Tags
                {
                    "LightMode" = "Picking"
                }
    
                // Render State
                Cull [_CullMode]
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
                #pragma multi_compile_instancing
                #pragma editor_sync_compilation
                #pragma instancing_options renderinglayer
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_DEPTH_ONLY
                #define SCENEPICKINGPASS
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/PickingSpaceTransforms.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "SceneSelectionPass"
                Tags
                {
                    "LightMode" = "SceneSelectionPass"
                }
    
                // Render State
                Cull Off
                ColorMask 0
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
                #pragma multi_compile_instancing
                #pragma editor_sync_compilation
                #pragma instancing_options renderinglayer
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_DEPTH_ONLY
                #define RAYTRACING_SHADER_GRAPH_DEFAULT
                #define SCENESELECTIONPASS
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "MotionVectors"
                Tags
                {
                    "LightMode" = "MotionVectors"
                }
    
                // Render State
                Cull [_CullMode]
                ZWrite On
                ColorMask [_ColorMaskNormal] 1
                ColorMask 0 2
                Stencil
                    {
                        WriteMask [_StencilWriteMaskMV]
                        Ref [_StencilRefMV]
                        CompFront Always
                        PassFront Replace
                        CompBack Always
                        PassBack Replace
                    }
                AlphaToMask [_AlphaToMask]
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
                #pragma multi_compile_instancing
                #pragma instancing_options renderinglayer
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature_local _ _ALPHATOMASK_ON
                #pragma multi_compile _ WRITE_MSAA_DEPTH
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define ATTRIBUTES_NEED_TEXCOORD1
                #define ATTRIBUTES_NEED_TEXCOORD2
                #define ATTRIBUTES_NEED_TEXCOORD3
                #define ATTRIBUTES_NEED_COLOR
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TANGENT_TO_WORLD
                #define VARYINGS_NEED_TEXCOORD0
                #define VARYINGS_NEED_TEXCOORD1
                #define VARYINGS_NEED_TEXCOORD2
                #define VARYINGS_NEED_TEXCOORD3
                #define VARYINGS_NEED_COLOR
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_MOTION_VECTORS
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    float4 uv1 : TEXCOORD1;
                    float4 uv2 : TEXCOORD2;
                    float4 uv3 : TEXCOORD3;
                    float4 color : COLOR;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float3 normalWS;
                    float4 tangentWS;
                    float4 texCoord0;
                    float4 texCoord1;
                    float4 texCoord2;
                    float4 texCoord3;
                    float4 color;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float3 interp1 : TEXCOORD1;
                    float4 interp2 : TEXCOORD2;
                    float4 interp3 : TEXCOORD3;
                    float4 interp4 : TEXCOORD4;
                    float4 interp5 : TEXCOORD5;
                    float4 interp6 : TEXCOORD6;
                    float4 interp7 : TEXCOORD7;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyz =  input.normalWS;
                    output.interp2.xyzw =  input.tangentWS;
                    output.interp3.xyzw =  input.texCoord0;
                    output.interp4.xyzw =  input.texCoord1;
                    output.interp5.xyzw =  input.texCoord2;
                    output.interp6.xyzw =  input.texCoord3;
                    output.interp7.xyzw =  input.color;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.normalWS = input.interp1.xyz;
                    output.tangentWS = input.interp2.xyzw;
                    output.texCoord0 = input.interp3.xyzw;
                    output.texCoord1 = input.interp4.xyzw;
                    output.texCoord2 = input.interp5.xyzw;
                    output.texCoord3 = input.interp6.xyzw;
                    output.color = input.interp7.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
                    output.texCoord0 = input.texCoord0;
                    output.texCoord1 = input.texCoord1;
                    output.texCoord2 = input.texCoord2;
                    output.texCoord3 = input.texCoord3;
                    output.color = input.color;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassMotionVectors.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "DepthForwardOnly"
                Tags
                {
                    "LightMode" = "DepthForwardOnly"
                }
    
                // Render State
                Cull [_CullMode]
                ZWrite On
                ColorMask [_ColorMaskNormal]
                ColorMask 0 1
                Stencil
                    {
                        WriteMask [_StencilWriteMaskDepth]
                        Ref [_StencilRefDepth]
                        CompFront Always
                        PassFront Replace
                        CompBack Always
                        PassBack Replace
                    }
                AlphaToMask [_AlphaToMask]
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
                #pragma multi_compile_instancing
                #pragma instancing_options renderinglayer
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature_local _ _ALPHATOMASK_ON
                #pragma multi_compile _ WRITE_MSAA_DEPTH
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define ATTRIBUTES_NEED_TEXCOORD1
                #define ATTRIBUTES_NEED_TEXCOORD2
                #define ATTRIBUTES_NEED_TEXCOORD3
                #define ATTRIBUTES_NEED_COLOR
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TANGENT_TO_WORLD
                #define VARYINGS_NEED_TEXCOORD0
                #define VARYINGS_NEED_TEXCOORD1
                #define VARYINGS_NEED_TEXCOORD2
                #define VARYINGS_NEED_TEXCOORD3
                #define VARYINGS_NEED_COLOR
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_DEPTH_ONLY
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    float4 uv1 : TEXCOORD1;
                    float4 uv2 : TEXCOORD2;
                    float4 uv3 : TEXCOORD3;
                    float4 color : COLOR;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float3 normalWS;
                    float4 tangentWS;
                    float4 texCoord0;
                    float4 texCoord1;
                    float4 texCoord2;
                    float4 texCoord3;
                    float4 color;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float3 interp1 : TEXCOORD1;
                    float4 interp2 : TEXCOORD2;
                    float4 interp3 : TEXCOORD3;
                    float4 interp4 : TEXCOORD4;
                    float4 interp5 : TEXCOORD5;
                    float4 interp6 : TEXCOORD6;
                    float4 interp7 : TEXCOORD7;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyz =  input.normalWS;
                    output.interp2.xyzw =  input.tangentWS;
                    output.interp3.xyzw =  input.texCoord0;
                    output.interp4.xyzw =  input.texCoord1;
                    output.interp5.xyzw =  input.texCoord2;
                    output.interp6.xyzw =  input.texCoord3;
                    output.interp7.xyzw =  input.color;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.normalWS = input.interp1.xyz;
                    output.tangentWS = input.interp2.xyzw;
                    output.texCoord0 = input.interp3.xyzw;
                    output.texCoord1 = input.interp4.xyzw;
                    output.texCoord2 = input.interp5.xyzw;
                    output.texCoord3 = input.interp6.xyzw;
                    output.color = input.interp7.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.tangentToWorld = BuildTangentToWorld(input.tangentWS, input.normalWS);
                    output.texCoord0 = input.texCoord0;
                    output.texCoord1 = input.texCoord1;
                    output.texCoord2 = input.texCoord2;
                    output.texCoord3 = input.texCoord3;
                    output.color = input.color;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassDepthOnly.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "ForwardOnly"
                Tags
                {
                    "LightMode" = "ForwardOnly"
                }
    
                // Render State
                Cull [_CullModeForward]
                Blend [_SrcBlend] [_DstBlend], [_AlphaSrcBlend] [_AlphaDstBlend]
                ZTest [_ZTestDepthEqualForOpaque]
                ZWrite [_ZWrite]
                ColorMask [_ColorMaskTransparentVel] 1
                Stencil
                    {
                        WriteMask [_StencilWriteMask]
                        Ref [_StencilRef]
                        CompFront Always
                        PassFront Replace
                        CompBack Always
                        PassBack Replace
                    }
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
                #pragma multi_compile_instancing
                #pragma instancing_options renderinglayer
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                #pragma multi_compile _ DEBUG_DISPLAY
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_FORWARD_UNLIT
                #define RAYTRACING_SHADER_GRAPH_DEFAULT
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                    float4 VTPackedFeedback;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    {
                        surface.VTPackedFeedback = float4(1.0f,1.0f,1.0f,.0f);
                    }
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
                    builtinData.vtPackedFeedback = surfaceDescription.VTPackedFeedback;
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassForwardUnlit.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "FullScreenDebug"
                Tags
                {
                    "LightMode" = "FullScreenDebug"
                }
    
                // Render State
                Cull [_CullMode]
                ZTest LEqual
                ZWrite Off
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 4.5
                #pragma vertex Vert
                #pragma fragment Frag
                #pragma only_renderers d3d11 playstation xboxone vulkan metal switch
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_FULL_SCREEN_DEBUG
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Debug/DebugDisplay.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassFullScreenDebug.hlsl"
    
                ENDHLSL
            }
        }
        SubShader
        {
            Tags
            {
                "RenderPipeline"="HDRenderPipeline"
                "RenderType"="HDUnlitShader"
                "Queue"="Transparent+0"
            }
            Pass
            {
                Name "IndirectDXR"
                Tags
                {
                    "LightMode" = "IndirectDXR"
                }
    
                // Render State
                // RenderState: <None>
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 5.0
                #pragma raytracing surface_shader
                #pragma only_renderers d3d11
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                #pragma multi_compile _ DEBUG_DISPLAY
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_RAYTRACING_INDIRECT
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/UnlitRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingCommon.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRaytracingIndirect.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "VisibilityDXR"
                Tags
                {
                    "LightMode" = "VisibilityDXR"
                }
    
                // Render State
                // RenderState: <None>
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 5.0
                #pragma raytracing surface_shader
                #pragma only_renderers d3d11
    
                // Keywords
                #pragma multi_compile _ TRANSPARENT_COLOR_SHADOW
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_RAYTRACING_VISIBILITY
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/UnlitRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingCommon.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRaytracingVisibility.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "ForwardDXR"
                Tags
                {
                    "LightMode" = "ForwardDXR"
                }
    
                // Render State
                // RenderState: <None>
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 5.0
                #pragma raytracing surface_shader
                #pragma only_renderers d3d11
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                #pragma multi_compile _ DEBUG_DISPLAY
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_RAYTRACING_FORWARD
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/UnlitRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingCommon.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassRaytracingForward.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "GBufferDXR"
                Tags
                {
                    "LightMode" = "GBufferDXR"
                }
    
                // Render State
                // RenderState: <None>
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 5.0
                #pragma raytracing surface_shader
                #pragma only_renderers d3d11
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                #pragma multi_compile _ DEBUG_DISPLAY
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_RAYTRACING_GBUFFER
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/Deferred/RaytracingIntersectonGBuffer.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/NormalBuffer.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/StandardLit/StandardLit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/UnlitRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingCommon.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderpassRaytracingGBuffer.hlsl"
    
                ENDHLSL
            }
            Pass
            {
                Name "PathTracingDXR"
                Tags
                {
                    "LightMode" = "PathTracingDXR"
                }
    
                // Render State
                // RenderState: <None>
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma target 5.0
                #pragma raytracing surface_shader
                #pragma only_renderers d3d11
    
                // Keywords
                #pragma shader_feature_local _ _ALPHATEST_ON
                #pragma shader_feature _ _SURFACE_TYPE_TRANSPARENT
                #pragma shader_feature_local _BLENDMODE_OFF _BLENDMODE_ALPHA _BLENDMODE_ADD _BLENDMODE_PRE_MULTIPLY
                #pragma shader_feature_local _ _ADD_PRECOMPUTED_VELOCITY
                #pragma shader_feature_local _ _TRANSPARENT_WRITES_MOTION_VEC
                #pragma shader_feature_local _ _ENABLE_FOG_ON_TRANSPARENT
                // GraphKeywords: <None>
    
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/FragInputs.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPass.cs.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl" // Required to be include before we include properties as it define DECLARE_STACK_CB
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphHeader.hlsl" // Need to be here for Gradient struct definition
    
                // --------------------------------------------------
                // Defines
    
                // Attribute
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_POSITION_WS
                #define VARYINGS_NEED_TEXCOORD0
    
                #define HAVE_MESH_MODIFICATION
    
    
                #define SHADERPASS SHADERPASS_PATH_TRACING
    
                // Following two define are a workaround introduce in 10.1.x for RaytracingQualityNode
                // The ShaderGraph don't support correctly migration of this node as it serialize all the node data
                // in the json file making it impossible to uprgrade. Until we get a fix, we do a workaround here
                // to still allow us to rename the field and keyword of this node without breaking existing code.
                #ifdef RAYTRACING_SHADER_GRAPH_DEFAULT 
                #define RAYTRACING_SHADER_GRAPH_HIGH
                #endif
    
                #ifdef RAYTRACING_SHADER_GRAPH_RAYTRACED
                #define RAYTRACING_SHADER_GRAPH_LOW
                #endif
                // end
    
                #ifndef SHADER_UNLIT
                // We need isFrontFace when using double sided - it is not required for unlit as in case of unlit double sided only drive the cullmode
                // VARYINGS_NEED_CULLFACE can be define by VaryingsMeshToPS.FaceSign input if a IsFrontFace Node is included in the shader graph.
                #if defined(_DOUBLESIDED_ON) && !defined(VARYINGS_NEED_CULLFACE)
                    #define VARYINGS_NEED_CULLFACE
                #endif
                #endif
    
                // Specific Material Define
            // Setup a define to say we are an unlit shader
                #define SHADER_UNLIT
                
                // Following Macro are only used by Unlit material
                #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                #define LIGHTLOOP_DISABLE_TILE_AND_CLUSTER
                #define HAS_LIGHTLOOP
                #endif
                
                // Caution: we can use the define SHADER_UNLIT onlit after the above Material include as it is the Unlit template who define it
    
                // To handle SSR on transparent correctly with a possibility to enable/disable it per framesettings
                // we should have a code like this:
                // if !defined(_DISABLE_SSR_TRANSPARENT)
                // pragma multi_compile _ WRITE_NORMAL_BUFFER
                // endif
                // i.e we enable the multicompile only if we can receive SSR or not, and then C# code drive
                // it based on if SSR transparent in frame settings and not (and stripper can strip it).
                // this is currently not possible with our current preprocessor as _DISABLE_SSR_TRANSPARENT is a keyword not a define
                // so instead we used this and chose to pay the extra cost of normal write even if SSR transaprent is disabled.
                // Ideally the shader graph generator should handle it but condition below can't be handle correctly for now.
                #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                #if !defined(_DISABLE_SSR_TRANSPARENT) && !defined(SHADER_UNLIT)
                    #define WRITE_NORMAL_BUFFER
                #endif
                #endif
    
                #ifndef DEBUG_DISPLAY
                    // In case of opaque we don't want to perform the alpha test, it is done in depth prepass and we use depth equal for ztest (setup from UI)
                    // Don't do it with debug display mode as it is possible there is no depth prepass in this case
                    #if !defined(_SURFACE_TYPE_TRANSPARENT) && defined(_ALPHATEST)
                        #if SHADERPASS == SHADERPASS_FORWARD
                        #define SHADERPASS_FORWARD_BYPASS_ALPHA_TEST
                        #elif SHADERPASS == SHADERPASS_GBUFFER
                        #define SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST
                        #endif
                    #endif
                #endif
    
                // Translate transparent motion vector define
                #if defined(_TRANSPARENT_WRITES_MOTION_VEC) && defined(_SURFACE_TYPE_TRANSPARENT)
                    #define _WRITE_TRANSPARENT_MOTION_VECTOR
                #endif
    
                // Dots Instancing
                // DotsInstancingOptions: <None>
    
                // Various properties
    
                // HybridV1InjectedBuiltinProperties: <None>
    
                // -- Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 _EmissionColor;
                float _UseShadowThreshold;
                float4 _DoubleSidedConstants;
                float _BlendMode;
                float _EnableBlendModePreserveSpecularLighting;
                float4 Texture2D_5343010B_TexelSize;
                float Vector1_4F56884;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_5343010B);
                SAMPLER(samplerTexture2D_5343010B);
                SAMPLER(_SampleTexture2D_f444104b475abc87a1478258608bc741_Sampler_3_Linear_Repeat);
    
                // -- Property used by ScenePickingPass
                #ifdef SCENEPICKINGPASS
                float4 _SelectionID;
                #endif
    
                // -- Properties used by SceneSelectionPass
                #ifdef SCENESELECTIONPASS
                int _ObjectId;
                int _PassValue;
                #endif
    
                // Includes
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingMacros.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Material.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracing.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/ShaderVariablesRaytracingLightLoop.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingIntersection.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/Unlit/Unlit.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/BuiltinUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/Material/MaterialUtilities.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/Raytracing/Shaders/RaytracingCommon.hlsl"
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/ShaderLibrary/ShaderGraphFunctions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct AttributesMesh
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct VaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 positionRWS;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpacePosition;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                    float3 ObjectSpaceNormal;
                    float3 ObjectSpaceTangent;
                    float3 ObjectSpacePosition;
                };
                struct PackedVaryingsMeshToPS
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                };
    
                PackedVaryingsMeshToPS PackVaryingsMeshToPS (VaryingsMeshToPS input)
                {
                    PackedVaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.positionRWS;
                    output.interp1.xyzw =  input.texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
                VaryingsMeshToPS UnpackVaryingsMeshToPS (PackedVaryingsMeshToPS input)
                {
                    VaryingsMeshToPS output;
                    output.positionCS = input.positionCS;
                    output.positionRWS = input.interp0.xyz;
                    output.texCoord0 = input.interp1.xyzw;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
    
                // Graph Functions
                
                void Unity_Add_float3(float3 A, float3 B, out float3 Out)
                {
                    Out = A + B;
                }
    
                // Graph Vertex
                struct VertexDescription
                {
                    float3 Position;
                    float3 Normal;
                    float3 Tangent;
                };
                
                VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
                {
                    VertexDescription description = (VertexDescription)0;
                    description.Position = IN.ObjectSpacePosition;
                    description.Normal = IN.ObjectSpaceNormal;
                    description.Tangent = IN.ObjectSpaceTangent;
                    return description;
                }
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float3 BaseColor;
                    float3 Emission;
                    float Alpha;
                    float AlphaClipThreshold;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float4 _UV_bb43917631d547dab72a6a1a3c3f0151_Out_0 = IN.uv0;
                    float3 _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2;
                    Unity_Add_float3(IN.WorldSpacePosition, (_UV_bb43917631d547dab72a6a1a3c3f0151_Out_0.xyz), _Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2);
                    float4 _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_5343010B, samplerTexture2D_5343010B, (_Add_624de42a79cf426ca9ac22a6acb12dd7_Out_2.xy));
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_R_4 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.r;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_G_5 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.g;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_B_6 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.b;
                    float _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7 = _SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.a;
                    float _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0 = Vector1_4F56884;
                    surface.BaseColor = (_SampleTexture2D_f444104b475abc87a1478258608bc741_RGBA_0.xyz);
                    surface.Emission = float3(0, 0, 0);
                    surface.Alpha = _SampleTexture2D_f444104b475abc87a1478258608bc741_A_7;
                    surface.AlphaClipThreshold = _Property_a88d4b8f9720ca87ba16c1af1c4d7f43_Out_0;
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                
                VertexDescriptionInputs AttributesMeshToVertexDescriptionInputs(AttributesMesh input)
                {
                    VertexDescriptionInputs output;
                    ZERO_INITIALIZE(VertexDescriptionInputs, output);
                
                    output.ObjectSpaceNormal =           input.normalOS;
                    output.ObjectSpaceTangent =          input.tangentOS.xyz;
                    output.ObjectSpacePosition =         input.positionOS;
                
                    return output;
                }
                
                AttributesMesh ApplyMeshModification(AttributesMesh input, float3 timeParameters)
                {
                    // build graph inputs
                    VertexDescriptionInputs vertexDescriptionInputs = AttributesMeshToVertexDescriptionInputs(input);
                    // Override time paramters with used one (This is required to correctly handle motion vector for vertex animation based on time)
                
                    // evaluate vertex graph
                    VertexDescription vertexDescription = VertexDescriptionFunction(vertexDescriptionInputs);
                
                    // copy graph output to the results
                    input.positionOS = vertexDescription.Position;
                    input.normalOS = vertexDescription.Normal;
                    input.tangentOS.xyz = vertexDescription.Tangent;
                
                    return input;
                }
                
                FragInputs BuildFragInputs(VaryingsMeshToPS input)
                {
                    FragInputs output;
                    ZERO_INITIALIZE(FragInputs, output);
                
                    // Init to some default value to make the computer quiet (else it output 'divide by zero' warning even if value is not used).
                    // TODO: this is a really poor workaround, but the variable is used in a bunch of places
                    // to compute normals which are then passed on elsewhere to compute other values...
                    output.tangentToWorld = k_identity3x3;
                    output.positionSS = input.positionCS;       // input.positionCS is SV_Position
                
                    output.positionRWS = input.positionRWS;
                    output.texCoord0 = input.texCoord0;
                
                    return output;
                }
                
                SurfaceDescriptionInputs FragInputsToSurfaceDescriptionInputs(FragInputs input, float3 viewWS)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                    #if defined(SHADER_STAGE_RAY_TRACING)
                    #else
                    #endif
                    output.WorldSpacePosition =          input.positionRWS;
                    output.uv0 =                         input.texCoord0;
                
                    return output;
                }
                
                // existing HDRP code uses the combined function to go directly from packed to frag inputs
                FragInputs UnpackVaryingsMeshToFragInputs(PackedVaryingsMeshToPS input)
                {
                    UNITY_SETUP_INSTANCE_ID(input);
                    VaryingsMeshToPS unpacked= UnpackVaryingsMeshToPS(input);
                    return BuildFragInputs(unpacked);
                }
                
    
                // --------------------------------------------------
                // Build Surface Data (Specific Material)
    
            void BuildSurfaceData(FragInputs fragInputs, inout SurfaceDescription surfaceDescription, float3 V, PositionInputs posInput, out SurfaceData surfaceData)
                {
                    // setup defaults -- these are used if the graph doesn't output a value
                    ZERO_INITIALIZE(SurfaceData, surfaceData);
                
                    // copy across graph values, if defined
                    surfaceData.color = surfaceDescription.BaseColor;
                
                    #ifdef WRITE_NORMAL_BUFFER
                    // When we need to export the normal (in the depth prepass, we write the geometry one)
                    surfaceData.normalWS = fragInputs.tangentToWorld[2];
                    #endif
                
                    #if defined(DEBUG_DISPLAY)
                    if (_DebugMipMapMode != DEBUGMIPMAPMODE_NONE)
                    {
                        // TODO
                    }
                    #endif
                
                    #if defined(_ENABLE_SHADOW_MATTE) && SHADERPASS == SHADERPASS_FORWARD_UNLIT
                        HDShadowContext shadowContext = InitShadowContext();
                        float shadow;
                        float3 shadow3;
                        // We need to recompute some coordinate not computed by default for shadow matte
                        posInput = GetPositionInput(fragInputs.positionSS.xy, _ScreenSize.zw, fragInputs.positionSS.z, UNITY_MATRIX_I_VP, UNITY_MATRIX_V);
                        float3 upWS = normalize(fragInputs.tangentToWorld[1]);
                        uint renderingLayers = GetMeshRenderingLightLayer();
                        ShadowLoopMin(shadowContext, posInput, upWS, asuint(_ShadowMatteFilter), renderingLayers, shadow3);
                        shadow = dot(shadow3, float3(1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0));
                
                        float4 shadowColor = (1.0 - shadow) * surfaceDescription.ShadowTint.rgba;
                        float  localAlpha  = saturate(shadowColor.a + surfaceDescription.Alpha);
                
                        // Keep the nested lerp
                        // With no Color (bsdfData.color.rgb, bsdfData.color.a == 0.0f), just use ShadowColor*Color to avoid a ring of "white" around the shadow
                        // And mix color to consider the Color & ShadowColor alpha (from texture or/and color picker)
                        #ifdef _SURFACE_TYPE_TRANSPARENT
                            surfaceData.color = lerp(shadowColor.rgb * surfaceData.color, lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow), surfaceDescription.Alpha);
                        #else
                            surfaceData.color = lerp(lerp(shadowColor.rgb, surfaceData.color, 1.0 - surfaceDescription.ShadowTint.a), surfaceData.color, shadow);
                        #endif
                        localAlpha = ApplyBlendMode(surfaceData.color, localAlpha).a;
                
                        surfaceDescription.Alpha = localAlpha;
                    #endif
                }
                
    
                // --------------------------------------------------
                // Get Surface And BuiltinData
    
                void GetSurfaceAndBuiltinData(FragInputs fragInputs, float3 V, inout PositionInputs posInput, out SurfaceData surfaceData, out BuiltinData builtinData RAY_TRACING_OPTIONAL_PARAMETERS)
                {
                    // Don't dither if displaced tessellation (we're fading out the displacement instead to match the next LOD)
                    #if !defined(SHADER_STAGE_RAY_TRACING) && !defined(_TESSELLATION_DISPLACEMENT)
                    #ifdef LOD_FADE_CROSSFADE // enable dithering LOD transition if user select CrossFade transition in LOD group
                    LODDitheringTransition(ComputeFadeMaskSeed(V, posInput.positionSS), unity_LODFade.x);
                    #endif
                    #endif
    
                    #ifndef SHADER_UNLIT
                    #ifdef _DOUBLESIDED_ON
                        float3 doubleSidedConstants = _DoubleSidedConstants.xyz;
                    #else
                        float3 doubleSidedConstants = float3(1.0, 1.0, 1.0);
                    #endif
    
                    ApplyDoubleSidedFlipOrMirror(fragInputs, doubleSidedConstants); // Apply double sided flip on the vertex normal
                    #endif // SHADER_UNLIT
    
                    SurfaceDescriptionInputs surfaceDescriptionInputs = FragInputsToSurfaceDescriptionInputs(fragInputs, V);
                    SurfaceDescription surfaceDescription = SurfaceDescriptionFunction(surfaceDescriptionInputs);
    
                    // Perform alpha test very early to save performance (a killed pixel will not sample textures)
                    // TODO: split graph evaluation to grab just alpha dependencies first? tricky..
                    #ifdef _ALPHATEST_ON
                        float alphaCutoff = surfaceDescription.AlphaClipThreshold;
                        #if SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_PREPASS
                        // The TransparentDepthPrepass is also used with SSR transparent.
                        // If an artists enable transaprent SSR but not the TransparentDepthPrepass itself, then we use AlphaClipThreshold
                        // otherwise if TransparentDepthPrepass is enabled we use AlphaClipThresholdDepthPrepass
                        #elif SHADERPASS == SHADERPASS_TRANSPARENT_DEPTH_POSTPASS
                        // DepthPostpass always use its own alpha threshold
                        alphaCutoff = surfaceDescription.AlphaClipThresholdDepthPostpass;
                        #elif (SHADERPASS == SHADERPASS_SHADOWS) || (SHADERPASS == SHADERPASS_RAYTRACING_VISIBILITY)
                        // If use shadow threshold isn't enable we don't allow any test
                        #endif
    
                        GENERIC_ALPHA_TEST(surfaceDescription.Alpha, alphaCutoff);
                    #endif
    
                    #if !defined(SHADER_STAGE_RAY_TRACING) && _DEPTHOFFSET_ON
                    ApplyDepthOffsetPositionInput(V, surfaceDescription.DepthOffset, GetViewForwardDir(), GetWorldToHClipMatrix(), posInput);
                    #endif
    
                    #ifndef SHADER_UNLIT
                    float3 bentNormalWS;
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData, bentNormalWS);
    
                    // Builtin Data
                    // For back lighting we use the oposite vertex normal
                    InitBuiltinData(posInput, surfaceDescription.Alpha, bentNormalWS, -fragInputs.tangentToWorld[2], fragInputs.texCoord1, fragInputs.texCoord2, builtinData);
    
                    #else
                    BuildSurfaceData(fragInputs, surfaceDescription, V, posInput, surfaceData);
    
                    ZERO_INITIALIZE(BuiltinData, builtinData); // No call to InitBuiltinData as we don't have any lighting
                    builtinData.opacity = surfaceDescription.Alpha;
    
                    #if defined(DEBUG_DISPLAY)
                        // Light Layers are currently not used for the Unlit shader (because it is not lit)
                        // But Unlit objects do cast shadows according to their rendering layer mask, which is what we want to
                        // display in the light layers visualization mode, therefore we need the renderingLayers
                        builtinData.renderingLayers = GetMeshRenderingLightLayer();
                    #endif
    
                    #endif // SHADER_UNLIT
    
                    #ifdef _ALPHATEST_ON
                        // Used for sharpening by alpha to mask - Alpha to covertage is only used with depth only and forward pass (no shadow pass, no transparent pass)
                        builtinData.alphaClipTreshold = alphaCutoff;
                    #endif
    
                    // override sampleBakedGI - not used by Unlit
    
                    builtinData.emissiveColor = surfaceDescription.Emission;
    
                    // Note this will not fully work on transparent surfaces (can check with _SURFACE_TYPE_TRANSPARENT define)
                    // We will always overwrite vt feeback with the nearest. So behind transparent surfaces vt will not be resolved
                    // This is a limitation of the current MRT approach.
    
                    #if _DEPTHOFFSET_ON
                    builtinData.depthOffset = surfaceDescription.DepthOffset;
                    #endif
    
                    // TODO: We should generate distortion / distortionBlur for non distortion pass
                    #if (SHADERPASS == SHADERPASS_DISTORTION)
                    builtinData.distortion = surfaceDescription.Distortion;
                    builtinData.distortionBlur = surfaceDescription.DistortionBlur;
                    #endif
    
                    #ifndef SHADER_UNLIT
                    // PostInitBuiltinData call ApplyDebugToBuiltinData
                    PostInitBuiltinData(V, posInput, surfaceData, builtinData);
                    #else
                    ApplyDebugToBuiltinData(builtinData);
                    #endif
    
                    RAY_TRACING_OPTIONAL_ALPHA_TEST_PASS
                }
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/ShaderPassPathTracing.hlsl"
    
                ENDHLSL
            }
        }
        CustomEditor "Rendering.HighDefinition.HDUnlitGUI"
        FallBack "Hidden/Shader Graph/FallbackError"
    }