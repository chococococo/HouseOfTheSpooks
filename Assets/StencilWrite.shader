Shader "Custom/StencilWrite" {
    Properties {
    }
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry+1"}
        LOD 200
        ZWrite Off
        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }
        ColorMask 0
   
        Pass{}
        Pass{ Tags {"LightMode"="ShadowCaster"} }
    }
}