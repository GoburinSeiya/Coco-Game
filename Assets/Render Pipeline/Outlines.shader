Shader "Outlines/BackFaceOutlines"
{
    Properties
    {
        _Tickness("Thickness", Float) = 1
        _Color("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RedenderPipeline" = "UniversalPipeline"}
        LOD 100

        Pass
        {
            Name "Outlines"
            Cull Front

            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x

            #pragma vertex Vertex
            #pragma fragment Fragment
            
            #include "BackFaceOutlines.hlsl"

            ENDHLSL
        }
    }
}
