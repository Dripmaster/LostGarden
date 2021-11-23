Shader "Custom/BackObject"
{
   SubShader{

	  Pass{
            Stencil{
                Ref 1
                Comp Equal
            }
        }
   }
}
