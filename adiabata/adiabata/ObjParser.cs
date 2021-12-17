using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using static SharpGL.OpenGL;
using System.IO;

namespace adiabata1
{
   class ObjParser
   {
      private OpenGL gl;
      private List<Point> vertexes;
      private List<Point> normals;
      private List<List<double>> tex;
      public ObjParser(OpenGL gl)
      {
         this.gl = gl;
         vertexes = new List<Point>();
         normals = new List<Point>();
         tex = new List<List<double>>();
      }
      public bool Load(string path)
      {
         using (StreamReader reader = new StreamReader(path))
         {
            //  Read line by line.
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
               if (line.StartsWith("#"))
                  continue;
               if (line.StartsWith("vt"))
               {
                  //  Get the texture coord strings.
                  string[] values = line.Substring(3).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                  //  Parse texture coordinates.
                  tex.Add(new List<double>(2) { float.Parse(values[0]), float.Parse(values[1]) });
                  continue;
               }
               if (line.StartsWith("vn"))
               {
                  //  Get the normal coord strings.
                  string[] values = line.Substring(3).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                  //  Parse normal coordinates.
                  float x = float.Parse(values[0]);
                  float y = float.Parse(values[1]);
                  float z = float.Parse(values[2]);
                  normals.Add(new Point(x, y, z));

                  continue;
               }
               if (line.StartsWith("v"))
               {
                  //  Get the vertex coord strings.
                  string[] values = line.Substring(2).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                  //  Parse vertex coordinates.
                  float x = float.Parse(values[0]);
                  float y = float.Parse(values[1]);
                  float z = float.Parse(values[2]);
                  //   Add the vertices.
                  vertexes.Add(new Point(x, y, z));

                  continue;
               }
               if (line.StartsWith("f"))
               {
                  //Face face = new Face();

                  //  Get the face indices
                  string[] indices = line.Substring(2).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                  //  Add each index.
                  foreach (var index in indices)
                  {
                     //  Split the parts.
                     string[] parts = index.Split(new char[] { '/' }, StringSplitOptions.None);

                     //  Add each part.
                  }



                  //  Add the face.
                  

                  continue;
               }
            }
         }
               return true;
      }
   }

   public struct Point
   {
      public double X, Y, Z;
      public Point(double x, double y, double z)
      {
         X = x;
         Y = y;
         Z = z;
      }
   }
   public struct Face
   {
      public List<int> vertexes;
      public List<int> textcoords;
      public List<int> normal;

      public Face(int v1, int v2, int v3, int t1, int t2, int t3,  int n1, int n2, int n3)
      {
         vertexes = new List<int>(3) { v1, v2, v3 };
         textcoords = new List<int>(3) { t1, t2, t3};
         normal = new List<int>(3) { n1, n2, n3 };
      }
      public Face(int v1, int v2, int v3, int v4,  int t1, int t2, int t3, int t4, int n1, int n2, int n3, int n4)
      {
         vertexes = new List<int>(4) { v1, v2, v3, v4 };
         textcoords = new List<int>(4) { t1, t2, t3, t4 };
         normal = new List<int>(4) { n1, n2, n3, n4 };
      }
   }
}
