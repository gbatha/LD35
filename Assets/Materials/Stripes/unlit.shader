// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33009,y:32607,varname:node_3138,prsc:2|emission-8614-OUT,alpha-2608-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32553,y:32332,ptovrint:False,ptlb:ColorA,ptin:_ColorA,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9705882,c2:0.2711938,c3:0.9512947,c4:1;n:type:ShaderForge.SFN_Tex2d,id:884,x:32549,y:32771,varname:node_884,prsc:2,tex:35709de68c5b34546bc0b052e1999e7e,ntxv:3,isnm:False|UVIN-2277-OUT,TEX-4503-TEX;n:type:ShaderForge.SFN_ValueProperty,id:1430,x:31859,y:32552,ptovrint:False,ptlb:u speed,ptin:_uspeed,varname:node_1430,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:8537,x:31859,y:32632,ptovrint:False,ptlb:v speed,ptin:_vspeed,varname:node_8537,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:2264,x:32047,y:32564,varname:node_2264,prsc:2|A-1430-OUT,B-8537-OUT;n:type:ShaderForge.SFN_Multiply,id:9746,x:32218,y:32623,varname:node_9746,prsc:2|A-2264-OUT,B-3343-T;n:type:ShaderForge.SFN_Time,id:3343,x:32047,y:32750,varname:node_3343,prsc:2;n:type:ShaderForge.SFN_Add,id:2277,x:32386,y:32521,varname:node_2277,prsc:2|A-6178-UVOUT,B-9746-OUT;n:type:ShaderForge.SFN_ScreenPos,id:242,x:32005,y:32259,varname:node_242,prsc:2,sctp:1;n:type:ShaderForge.SFN_Tex2dAsset,id:4503,x:32330,y:32815,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_4503,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:35709de68c5b34546bc0b052e1999e7e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:9561,x:32539,y:32521,ptovrint:False,ptlb:ColorB,ptin:_ColorB,varname:node_9561,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9574036,c3:0.3823529,c4:1;n:type:ShaderForge.SFN_Lerp,id:8614,x:32848,y:32497,varname:node_8614,prsc:2|A-7241-RGB,B-9561-RGB,T-884-R;n:type:ShaderForge.SFN_Rotator,id:6178,x:32322,y:32316,varname:node_6178,prsc:2|UVIN-242-UVOUT,ANG-3708-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3708,x:32111,y:32441,ptovrint:False,ptlb:UV rotation,ptin:_UVrotation,varname:node_3708,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:2608,x:32810,y:32860,varname:node_2608,prsc:2|A-7241-A,B-9561-A,T-884-R;proporder:7241-9561-1430-8537-4503-3708;pass:END;sub:END;*/

Shader "Gregs Shaders/unlit" {
    Properties {
        _ColorA ("ColorA", Color) = (0.9705882,0.2711938,0.9512947,1)
        _ColorB ("ColorB", Color) = (1,0.9574036,0.3823529,1)
        _uspeed ("u speed", Float ) = 0.1
        _vspeed ("v speed", Float ) = 0
        _Texture ("Texture", 2D) = "white" {}
        _UVrotation ("UV rotation", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ColorA;
            uniform float _uspeed;
            uniform float _vspeed;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _ColorB;
            uniform float _UVrotation;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
////// Lighting:
////// Emissive:
                float node_6178_ang = _UVrotation;
                float node_6178_spd = 1.0;
                float node_6178_cos = cos(node_6178_spd*node_6178_ang);
                float node_6178_sin = sin(node_6178_spd*node_6178_ang);
                float2 node_6178_piv = float2(0.5,0.5);
                float2 node_6178 = (mul(float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg-node_6178_piv,float2x2( node_6178_cos, -node_6178_sin, node_6178_sin, node_6178_cos))+node_6178_piv);
                float4 node_3343 = _Time + _TimeEditor;
                float2 node_2277 = (node_6178+(float2(_uspeed,_vspeed)*node_3343.g));
                float4 node_884 = tex2D(_Texture,TRANSFORM_TEX(node_2277, _Texture));
                float3 emissive = lerp(_ColorA.rgb,_ColorB.rgb,node_884.r);
                float3 finalColor = emissive;
                return fixed4(finalColor,lerp(_ColorA.a,_ColorB.a,node_884.r));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
