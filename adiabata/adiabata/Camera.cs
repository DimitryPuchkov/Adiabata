using System;
using System.Collections.Generic;
using System.Text;
using SharpGL;
using static SharpGL.OpenGL;
using GlmNet;

namespace adiabata
{
   class Camera
   {
      OpenGL gl;
      private float xalfa;
      private float zalfa;
      private float X;
      private float Y;
      public float Speed;
      public float Fi{ get; set; }
      public float Xalfa 
      {
         get => xalfa;
         set
         {
            if (value > (float)Math.PI * 2)
               xalfa = value - (float)Math.PI * 2;
            else if (value < -(float)Math.PI * 2)
               xalfa = value + (float)Math.PI * 2;
            else
               xalfa = value;
         } 
      }
      public float Zalfa 
      {
         get => zalfa;
         set
         {
            if (value > (float)Math.PI * 2)
               zalfa = value - (float)Math.PI * 2;
            else if (zalfa < -(float)Math.PI * 2)
               zalfa = value + (float)Math.PI * 2;
            else
               zalfa = value;
         }
      }

      public Camera(OpenGL gl, float xalfa, float zalfa)
      {
         this.gl = gl;
         Xalfa = xalfa;
         Zalfa = zalfa;
         X = 0;
         Y = 0;
      }
      public mat4 Move(mat4 viewMatrix)
      {
         float fi = -Zalfa / 180 * (float)Math.PI;
         //fi += Fi;
         X += (float)Math.Sin(fi) * Speed;
         Y += (float)Math.Cos(fi) * Speed;
         viewMatrix = glm.rotate(viewMatrix, -Xalfa, new vec3(1.0f, 0.0f, 0.0f));
         viewMatrix = glm.rotate(viewMatrix, -Zalfa, new vec3(0.0f, 0.0f, 1.0f));
         viewMatrix = glm.translate(viewMatrix, new vec3(-X, -Y, -3.0f));
         //Fi = 0;
         return viewMatrix;
      }

   }

}
