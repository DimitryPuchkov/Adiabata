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

namespace adiabata
{
   class Functions
   {
      public static Polygon LoadData(string name)
      {
         string line;
         Polygon polygon = new Polygon();
         using (StreamReader reader = new StreamReader(name))
         {
            while ((line = reader.ReadLine()) != null)
            {
               //  Do we have a texture coordinate?
               if (line.StartsWith("vt"))
               {
                  //  Get the texture coord strings.
                  string[] values = line.Split(' ');
                  float x = float.Parse(values[1], CultureInfo.InvariantCulture);
                  float y = float.Parse(values[2], CultureInfo.InvariantCulture);

                  //  Parse texture coordinates.
                  float u = x;
                  float v = 1.0f - y;

                  //  Add the texture coordinate.
                  polygon.UVs.Add(new UV(u, v));
                  continue;
               }

               //  Do we have a normal coordinate?
               if (line.StartsWith("v "))
               {
                  //  Get the normal coord strings.
                  string[] values = line.Split(' ');

                  //  Parse normal coordinates.
                  float x = float.Parse(values[1], CultureInfo.InvariantCulture);
                  float y = float.Parse(values[2], CultureInfo.InvariantCulture);
                  float z = float.Parse(values[3], CultureInfo.InvariantCulture);

                  //  Add the normal.
                  polygon.Vertices.Add(new Vertex(x, y, z));
                  continue;
               }
               if (line.StartsWith("f"))
               {
                  Face face = new Face();
                  string[] indices = line.Substring(2).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                  foreach (var index in indices)
                  {

                     string[] parts = index.Split(new char[] { '/' }, StringSplitOptions.None);

                     face.Indices.Add(new Index(
                         (parts.Length > 0 && parts[0].Length > 0) ? int.Parse(parts[0], CultureInfo.InvariantCulture) - 1 : -1,
                         (parts.Length > 1 && parts[1].Length > 0) ? int.Parse(parts[1], CultureInfo.InvariantCulture) - 1 : -1,
                         (parts.Length > 2 && parts[2].Length > 0) ? int.Parse(parts[2], CultureInfo.InvariantCulture) - 1 : -1));
                  }

                  //  Add the face.
                  polygon.Faces.Add(face);
                  continue;
               }
            }

         }
         return polygon;
      }
   }
}
