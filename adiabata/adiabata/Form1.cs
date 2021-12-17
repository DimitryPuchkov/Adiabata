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
   public partial class Form1 : Form
   {
      OpenGL gl;
      Camera camera;
      List<int> PositionStart = new List<int> { -1, -1 };
      double rotationSpeed = 0.15f;
      SharpGL.Serialization.Wavefront.ObjFileFormat model = new SharpGL.Serialization.Wavefront.ObjFileFormat();
      Polygon table;
      Polygon kolba;
      Polygon klapan;
      Polygon manometr;
      //Polygon pump, pump_handle;
      Pump pump;
      Texture tableTex = new Texture();
      Texture klapanTex = new Texture();
      Bitmap Image, Image1, Image2;
      public Form1()
      {
         InitializeComponent();
      }

      private void trackBar3_Scroll(object sender, EventArgs e)
      {

      }

      private void label2_Click(object sender, EventArgs e)
      {

      }

      private void openGLControl1_Load(object sender, EventArgs e)
      {
         gl = this.openGLControl1.OpenGL;
         camera = new Camera(gl, 50, 0);
         gl.Enable(GL_DEPTH_TEST);
         gl.Enable(GL_BLEND);
         gl.BlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
         gl.Frustum(-1, 1, -1, 1, 2, 8);
         table = LoadData("table.obj");
         kolba = LoadData("kolba.obj");
         manometr = LoadData("man.obj");
         pump = new Pump(gl, "pump.obj", "pump_handle.obj", "2.jpg");
         //pump = LoadData("pump.obj");
         //pump_handle = LoadData("pump_handle.obj");
         klapan = LoadData("klapan.obj");
         Image = new Bitmap("1.jpg");
         tableTex.Create(gl, Image);
         Image1 = new Bitmap("2.jpg");
         klapanTex.Create(gl, Image1);
         //this.openGLControl1.
         //Scene a = new Scene();
         // Cons.Text = a.ToString();
      }

      private void openGLControl1_OpenGLDraw_1(object sender, SharpGL.RenderEventArgs args)
      {
         gl.ClearColor(0.369f, 0.8f, 0.949f, 1); // Цвет очистки экрана
         gl.Clear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); // очистка буфера цвета и глубины
         gl.LoadIdentity(); // загружаем единичную матрицу

         camera.Move();

         //for (int i = -5; i < 5; i++)
         //   for (int j = -5; j < 5; j++)
         //   {
         //      gl.PushMatrix();
         //      if ((i + j) % 2 == 0) gl.Color(0, 0.5, 0);
         //      else gl.Color(1.0f, 1.0f, 1.0f);
         //      gl.Translate(i * 2, j * 2, 0);
         //      gl.Begin(OpenGL.GL_TRIANGLE_FAN);
         //      gl.Vertex(1, 1, 0);
         //      gl.Vertex(1, -1, 0);
         //      gl.Vertex(-1, -1, 0);
         //      gl.Vertex(-1, 1, 0);
         //      gl.End();
         //      gl.PopMatrix();
         //   }
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         //Отрисовка стола
         tableTex.Bind(gl);
         gl.PushMatrix();
         gl.Translate(0, 2, 0);
         gl.Rotate(90.0, 1, 0, 0);
         gl.Scale(2, 2, 3);
         gl.Color(1.0, 1.0, 1.0);
         gl.Begin(GL_QUADS);
         for (int i = 0; i < table.Faces.Count; i++)
         {
            gl.TexCoord(table.UVs[table.Faces[i].Indices[0].UV]);   gl.Vertex(table.Vertices[table.Faces[i].Indices[0].Vertex]);
            gl.TexCoord(table.UVs[table.Faces[i].Indices[1].UV]);   gl.Vertex(table.Vertices[table.Faces[i].Indices[1].Vertex]);
            gl.TexCoord(table.UVs[table.Faces[i].Indices[2].UV]);   gl.Vertex(table.Vertices[table.Faces[i].Indices[2].Vertex]);
            gl.TexCoord(table.UVs[table.Faces[i].Indices[3].UV]);   gl.Vertex(table.Vertices[table.Faces[i].Indices[3].Vertex]);
         }
         gl.End();
         //Отрисовка колбы
         gl.Disable(GL_TEXTURE_2D);
         gl.Translate(0, 0.82, 0);
         gl.Begin(GL_QUADS);
         gl.Color(0.9, 0.9, 0.9, 0.5);
         for (int i = 0; i < kolba.Faces.Count; i++)
         {
            gl.Vertex(kolba.Vertices[kolba.Faces[i].Indices[0].Vertex]);
            gl.Vertex(kolba.Vertices[kolba.Faces[i].Indices[1].Vertex]);
            gl.Vertex(kolba.Vertices[kolba.Faces[i].Indices[2].Vertex]);
            gl.Vertex(kolba.Vertices[kolba.Faces[i].Indices[3].Vertex]);
         }
         gl.End();

         //Отрисовка клапана
         gl.Enable(GL_TEXTURE_2D);
         klapanTex.Bind(gl);
         gl.PushMatrix();
         gl.Translate(0, 0.25, 0);
         gl.Begin(GL_QUADS);
         gl.Color(0.9, 0.9, 0.9);
         for (int i = 0; i < klapan.Faces.Count; i++)
         {
            gl.Vertex(klapan.Vertices[klapan.Faces[i].Indices[0].Vertex]);
            gl.Vertex(klapan.Vertices[klapan.Faces[i].Indices[1].Vertex]);
            gl.Vertex(klapan.Vertices[klapan.Faces[i].Indices[2].Vertex]);
            gl.Vertex(klapan.Vertices[klapan.Faces[i].Indices[3].Vertex]);
         }
         gl.End();
         

         // Отрисовка манометра
         gl.Disable(GL_TEXTURE_2D);
         //gl.Translate(0, 0.8, 0);
         gl.Rotate(50, 0, 1, 0);
         gl.Translate(-0.1, -0.08, 0.08);
         gl.Scale(0.02, 0.02, 0.02);
         gl.Color(0.9, 0.9, 0.9, 0.8);
         for (int i = 0; i < manometr.Faces.Count; i++)
         {
            gl.Begin(GL_POLYGON);
            for (int j = 0; j < manometr.Faces[i].Count; j++)
               gl.Vertex(manometr.Vertices[manometr.Faces[i].Indices[j].Vertex]);
            gl.End();
         }
         gl.PopMatrix();
         //Отрисовка Насоса

         gl.Translate(0.2, -0.1, 0);
         pump.Draw();
         gl.PopMatrix();






         gl.Flush();
      }

      private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyValue)
         {
            case 'W': { camera.Speed = 0.1; camera.Fi = 0; } break;
            case 'S': { camera.Speed = 0.1; camera.Fi = Math.PI; } break;
            case 'A': { camera.Speed = 0.1; camera.Fi = -0.5 * Math.PI; } break;
            case 'D': { camera.Speed = 0.1; camera.Fi = +0.5 * Math.PI; } break;
         }
      }

      private void openGLControl1_KeyUp(object sender, KeyEventArgs e)
      {
         switch (e.KeyValue)
         {
            case 'W': { camera.Speed = 0; camera.Fi = 0; } break;
            case 'S': { camera.Speed = 0; camera.Fi = 0; } break;
            case 'A': { camera.Speed = 0; camera.Fi = 0; } break;
            case 'D': { camera.Speed = 0; camera.Fi = 0; } break;
         }
      }

      private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button.ToString() == "Right")
         {
            PositionStart[0] = e.X;
            PositionStart[1] = e.Y;
         }
         Cons.Text = $"X:{e.X}  Y:{e.Y}";
      }

      private void openGLControl1_MouseLeave(object sender, EventArgs e)
      {
         //PositionStart[0] = -1;
         //PositionStart[1] = -1;
         Cons.Text += "\nLeave\n";
      }

      private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
      { 
         if(PositionStart[0] != -1 && PositionStart[0] != -1)
         {
            camera.Xalfa += (e.Y - PositionStart[1]) * rotationSpeed;
            camera.Zalfa += (e.X - PositionStart[0]) * rotationSpeed;
            PositionStart[0] = e.X;
            PositionStart[1] = e.Y;
         }
      }

      private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
      {
         PositionStart[0] = -1;
         PositionStart[1] = -1;
      }

      //Polygon LoadData(string name)
      //{
      //   string line;
      //   Polygon polygon = new Polygon();
      //   using (StreamReader reader = new StreamReader(name))
      //   {
      //      while ((line = reader.ReadLine()) != null)
      //      {
      //         //  Do we have a texture coordinate?
      //         if (line.StartsWith("vt"))
      //         {
      //            //  Get the texture coord strings.
      //            string[] values = line.Split(' ');
      //            float x = float.Parse(values[1], CultureInfo.InvariantCulture);
      //            float y = float.Parse(values[2], CultureInfo.InvariantCulture);

      //            //  Parse texture coordinates.
      //            float u = x;
      //            float v = 1.0f - y;

      //            //  Add the texture coordinate.
      //            polygon.UVs.Add(new UV(u, v));
      //            continue;
      //         }

      //         //  Do we have a normal coordinate?
      //         if (line.StartsWith("v "))
      //         {
      //            //  Get the normal coord strings.
      //            string[] values = line.Split(' ');

      //            //  Parse normal coordinates.
      //            float x = float.Parse(values[1], CultureInfo.InvariantCulture);
      //            float y = float.Parse(values[2], CultureInfo.InvariantCulture);
      //            float z = float.Parse(values[3], CultureInfo.InvariantCulture);

      //            //  Add the normal.
      //            polygon.Vertices.Add(new Vertex(x, y, z));
      //            continue;
      //         }
      //         if (line.StartsWith("f"))
      //         {
      //            Face face = new Face();
      //            string[] indices = line.Substring(2).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


      //            foreach (var index in indices)
      //            {

      //               string[] parts = index.Split(new char[] { '/' }, StringSplitOptions.None);

      //               face.Indices.Add(new Index(
      //                   (parts.Length > 0 && parts[0].Length > 0) ? int.Parse(parts[0], CultureInfo.InvariantCulture) - 1 : -1,
      //                   (parts.Length > 1 && parts[1].Length > 0) ? int.Parse(parts[1], CultureInfo.InvariantCulture) - 1 : -1,
      //                   (parts.Length > 2 && parts[2].Length > 0) ? int.Parse(parts[2], CultureInfo.InvariantCulture) - 1 : -1));
      //            }

      //            //  Add the face.
      //            polygon.Faces.Add(face);
      //            continue;
      //         }
      //      }

      //   }
      //   return polygon;
      //}
   }
}
