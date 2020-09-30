Shader "Unlit/GlitchMob"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_TintColor("Tint Color", Color) = (1,1,1,1)
		_Transparency("Transparency", Range(0.0, 0.5)) = 0.25
		_CutoutThresh("Cutout Threshold", Range(0.0, 1.0)) = 1
		_Distance("Distance", Float) = 1
		_Amplitude("Amplitude", Range(0.0, 1.0)) = 1
		_Speed("Speed", Float) = 1
		_Amount("Amount", Float) = 1
    }


    SubShader
    {
		// render queue: Background > Geometry > Alphatest > Transparent > overlay
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
		
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha		// blend pixles together using the alpha channel

        Pass
        {
            CGPROGRAM
            #pragma vertex vert		// we're going to have a vertext function called 'vert', processing the data of your mesh filter. object space > display space 
            #pragma fragment frag	// we're going to have a fragment function called frag, colors the pixels that lie insdie the mesh's trianlges

			           

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;	
                float2 uv : TEXCOORD0;		
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _TintColor;
			float _Transparency;
			float _CutoutThresh;
			float _Distance;
			float _Amplitude;
			float _Speed;
			float _Amount;

            v2f vert (appdata v)
            {
				// create a new v2f struct 'o'
                v2f o;

				// apply sin wave movement in the x axis
				v.vertex.x += sin(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;
                
				// local space (object space) > world space > view space (eye space) > clip space > screen space
				o.vertex = UnityObjectToClipPos(v.vertex);


				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) + _TintColor;

				col.a = _Transparency;

				clip(col.r = _CutoutThresh);

                return col;
            }
            ENDCG
        }
    }
}
