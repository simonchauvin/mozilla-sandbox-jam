Shader "Simple Additive" {
    Properties {
        _MainTex ("Texture to blend", 2D) = "black" {}
    }
    SubShader {
        Tags { "Queue" = "Transparent" }
        Pass {
            Blend DstColor Zero
            SetTexture [_MainTex] { combine texture }
        }
    }
}