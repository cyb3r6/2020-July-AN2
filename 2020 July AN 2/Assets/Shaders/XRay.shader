Shader "ZackAlmighty/XRay"
{   
    SubShader
    {
        Tags { "Queue" = "Transparent +1" }     // render after all transparent objects (queue = 3000)
        Pass { Blend Zero One }                 // makes the object transparent
    }
}
