using System;
using System.Collections.Generic;
using System.Text;
using GlmNet;
using SharpGL;
using SharpGL.Shaders;
using SharpGL.VertexBuffers;
using static SharpGL.OpenGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Primitives;
using System.IO;
using System.Globalization;
using SharpGL.SceneGraph;
using Index = SharpGL.SceneGraph.Index;
using System.Drawing;

namespace adiabata
{
   class ColorModel
   {
      OpenGL gl;
      uint[] VBO = new uint[1];//Буффер вершин
      uint[] VAO = new uint[1];//Массив из вершин и индексов
      uint[] EBO = new uint[1];//Буффер индексов
      int BufID; // Идентификатор общего буффера
      Texture texture; //текстура
      int triangles;
      public ColorModel(OpenGL _gl, string pathToModel, vec4 clor, int bufID)
      {
         this.gl = _gl;
         Polygon polygon = LoadPplygon(pathToModel); // модель вначале загружается в вспомогательную структуру Polygon
         long n = polygon.Faces.Count * 3 * 7;
         BufID = bufID;
         // Вид массива:
         // вершина   тексткоордината
         // x y z    u v
         var vertices = new float[n]; //массив вершин и тексткоодринат
         triangles = polygon.Faces.Count * 3;

         //var vertices = new float[polygon.Vertices.Count *3];
         //var texcoords = new float[polygon.UVs.Count *2];
         //for (int i = 0; i < polygon.Vertices.Count; i+=3)
         //{
         //   vertices[i] = polygon.Vertices[i/3].X;
         //   vertices[i+1] = polygon.Vertices[i/3].Y;
         //   vertices[i+2] = polygon.Vertices[i/3].Z;
         //}
         //for (int i = 0; i < polygon.UVs.Count; i += 2)
         //{
         //   vertices[i] = polygon.UVs[i / 2].U;
         //   vertices[i + 1] = polygon.UVs[i / 2].V;
         //}
         //var indices = new ushort[6];
         for (int i = 0; i < n; i += 21)
         {
            vertices[i] = polygon.Vertices[polygon.Faces[i / 21].Indices[0].Vertex].X;
            vertices[i + 1] = polygon.Vertices[polygon.Faces[i / 21].Indices[0].Vertex].Y;
            vertices[i + 2] = polygon.Vertices[polygon.Faces[i / 21].Indices[0].Vertex].Z;
            vertices[i + 3] = clor[0];
            vertices[i + 4] = clor[1];
            vertices[i + 5] = clor[2];
            vertices[i + 6] = clor[3];


            vertices[i + 7] = polygon.Vertices[polygon.Faces[i / 21].Indices[1].Vertex].X;
            vertices[i + 8] = polygon.Vertices[polygon.Faces[i / 21].Indices[1].Vertex].Y;
            vertices[i + 9] = polygon.Vertices[polygon.Faces[i / 21].Indices[1].Vertex].Z;
            vertices[i + 10] = clor[0];
            vertices[i + 11] = clor[1];
            vertices[i + 12] = clor[2];
            vertices[i + 13] = clor[3];

            vertices[i + 14] = polygon.Vertices[polygon.Faces[i / 21].Indices[2].Vertex].X;
            vertices[i + 15] = polygon.Vertices[polygon.Faces[i / 21].Indices[2].Vertex].Y;
            vertices[i + 16] = polygon.Vertices[polygon.Faces[i / 21].Indices[2].Vertex].Z;
            vertices[i + 17] = clor[0];
            vertices[i + 18] = clor[1];
            vertices[i + 19] = clor[2];
            vertices[i + 20] = clor[3];


         }
         n = polygon.Faces.Count * 3;
         var indices = new ushort[n]; //массив индексов
         for (ushort i = 0; i < n; i++)
            indices[i] = i;
         //Cоздание буфферов
         gl.GenVertexArrays(BufID, VAO);
         gl.GenBuffers(BufID, VBO);
         gl.GenBuffers(BufID, EBO);
         //привязка буфферов и заполнение их данными 
         gl.BindVertexArray(VAO[0]);
         gl.BindBuffer(GL_ARRAY_BUFFER, VBO[0]);
         gl.BufferData(GL_ARRAY_BUFFER, vertices, GL_STATIC_DRAW);
         gl.BindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO[0]);
         gl.BufferData(GL_ELEMENT_ARRAY_BUFFER, indices, GL_STATIC_DRAW);
         //передача аттрибутов в шейдер вершин
         gl.VertexAttribPointer(0, 3, GL_FLOAT, false, 7 * 4, IntPtr.Zero);
         gl.EnableVertexAttribArray(0);
         IntPtr c = new IntPtr(3*4);
         gl.VertexAttribPointer(2, 4, GL_FLOAT, false, 7 * 4, c);
         gl.EnableVertexAttribArray(2);
         //Привязка стандартного буффера тк работа с буфферами завершена
         gl.BindBuffer(GL_ARRAY_BUFFER, 0);
         gl.BindVertexArray(0);
         //инициализация текстуры

      }
      public void Draw()
      {
         gl.BindVertexArray(VAO[0]);
         gl.DrawElements(GL_TRIANGLES, triangles, GL_UNSIGNED_SHORT, IntPtr.Zero);
         gl.BindVertexArray(0);
      }
      public static Polygon LoadPplygon(string path)
      {
         string line;
         Polygon polygon = new Polygon();
         using (StreamReader reader = new StreamReader(path))
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
