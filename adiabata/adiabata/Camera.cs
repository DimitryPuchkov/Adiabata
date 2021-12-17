using System;
using System.Collections.Generic;
using System.Text;
using SharpGL;
using static SharpGL.OpenGL;

namespace adiabata
{
   class Camera
   {
      OpenGL gl;
      private double xalfa;
      private double zalfa;
      private double X;
      private double Y;
      public double Speed;
      public double Fi{ get; set; }
      public double Xalfa 
      {
         get => xalfa;
         set
         {
            if (value > 360)
               xalfa = value - 360;
            else if (value < -360)
               xalfa = value + 360;
            else
               xalfa = value;
         } 
      }
      public double Zalfa 
      {
         get => zalfa;
         set
         {
            if (value > 360)
               zalfa = value - 360;
            else if (zalfa < -360)
               zalfa = value + 360;
            else
               zalfa = value;
         }
      }

      public Camera(OpenGL gl, double xalfa, double zalfa)
      {
         this.gl = gl;
         Xalfa = xalfa;
         Zalfa = zalfa;
         X = 0;
         Y = 0;
      }
      public void Move()
      {
         double fi = -Zalfa / 180 * Math.PI;
         fi += Fi;
         X += Math.Sin(fi) * Speed;
         Y += Math.Cos(fi) * Speed;
         gl.Rotate(-Xalfa, 1, 0, 0);
         gl.Rotate(-Zalfa, 0, 0, 1);
         gl.Translate(-X, -Y, -3);
      }

   }

}
