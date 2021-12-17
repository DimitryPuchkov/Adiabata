using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Primitives;
using Index = SharpGL.SceneGraph.Index;
using static SharpGL.OpenGL;
using static adiabata.Functions;

namespace adiabata
{
   class Pump
   {
      private Polygon pump, handle;
      private Texture pumpTex;
      private OpenGL gl;
      public byte dir;
      private double handleY, handleYMax;
      public Pump(OpenGL gl, string pumpPath, string handlePath, string pImg)
      {
         this.gl = gl;
         pump = LoadData(pumpPath);
         handle = LoadData(handlePath);
         if (!(pImg == ""))
         {
            pumpTex = new Texture();
            pumpTex.Create(gl, new Bitmap(pImg));
         }
         handleY = 0;
         handleYMax = 0.5;
         dir = 1;
      }

      public void Draw()
      {
         gl.Scale(0.1, 0.1, 0.1);
         if (pumpTex != null)
         {
            gl.Enable(GL_TEXTURE_2D);
            pumpTex.Bind(gl);
         }
         else gl.Disable(GL_TEXTURE_2D);
         DrawPump();
         DrawHandle();
      }
      
      private void DrawPump()
      {
         //gl.Color(0.0, 0.5, 0);
         if (pumpTex == null)
            for (int i = 0; i < pump.Faces.Count; i++)
            {
               gl.Begin(GL_POLYGON);
               for (int j = 0; j < pump.Faces[i].Count; j++)
                     gl.Vertex(pump.Vertices[pump.Faces[i].Indices[j].Vertex]);
               gl.End();
            }
         else
            for (int i = 0; i < pump.Faces.Count; i++)
            {
               gl.Begin(GL_POLYGON);
               for (int j = 0; j < pump.Faces[i].Count; j++)
                  {gl.TexCoord(pump.UVs[pump.Faces[i].Indices[j].UV]); gl.Vertex(pump.Vertices[pump.Faces[i].Indices[j].Vertex]);}
               gl.End();
            }

      }
      private void DrawHandle()
      {
         switch(dir)
         {
            case 0: { handleY = 0; }break;
            case 1: { handleY += 0.1; if (handleY >= handleYMax) dir = 2; }break;
            case 2: { handleY -= 0.1; if (handleY <= 0) { dir = 0; handleY = 0; } } break;
         }
         gl.Translate(0, handleY, 0);
         gl.Color(0.5, 0.0, 0);
         for (int i = 0; i < handle.Faces.Count; i++)
         {
            gl.Begin(GL_POLYGON);
            for (int j = 0; j < handle.Faces[i].Count; j++)
               gl.Vertex(handle.Vertices[handle.Faces[i].Indices[j].Vertex]);
            gl.End();
         }
      }
   }
}
