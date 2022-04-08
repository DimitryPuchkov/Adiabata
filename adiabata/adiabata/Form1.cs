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
using GlmNet;
using SharpGL.Shaders;


namespace adiabata
{
   public partial class Form1 : Form
   {
      OpenGL gl;
      Camera camera;
      List<int> PositionStart = new List<int> { -1, -1 };
      float rotationSpeed = 0.005f;
      mat4 projectionMatrix;
      mat4 viewMatrix;
      mat4 modelMatrix;

      vec3 cameraPos = new vec3(0.0f, -2.0f, 3.0f);
      vec3 cameraFront = new vec3(0.0f, 0.0f, -1.0f);
      vec3 cameraUp = new vec3(0.0f, 1.0f, 0.0f);
      bool firstMouse = true;
      float yaw = -90.0f;  // yaw is initialized to -90.0 degrees since a yaw of 0.0 results in a direction vector pointing to the right so we initially rotate a bit to the left.
      float pitch = 0.0f;
      float lastX = 800.0f / 2.0f;
      float lastY = 600.0f / 2.0f;
      float fov = 45.0f;


      LoaderModel table;
      LoaderModel pump;
      ColorModel kolba;

      float Xalfa, Zalfa, X, Y;
      ShaderProgram TextShader; // шейдер для отрисовки объектов с текстурами
      ShaderProgram ColorShader; // шейдер для отрисовки объектов определенным цветом
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
         gl.Enable(GL_BLEND);
         gl.BlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
         Xalfa = 0.0f; Zalfa = 0.0f;
         X = 0; Y = 0;
         gl.Enable(GL_DEPTH_TEST);
         var vertexShaderSource = ManifestResourceLoader.LoadTextFile("Shader.vert");
         var fragmentShaderSource = ManifestResourceLoader.LoadTextFile("Shader.frag");
         TextShader = new ShaderProgram();
         TextShader.Create(gl, vertexShaderSource, fragmentShaderSource, null);
         TextShader.AssertValid(gl);
         var vertexShaderSource1 = ManifestResourceLoader.LoadTextFile("Col.vert");
         var fragmentShaderSource1 = ManifestResourceLoader.LoadTextFile("Col.frag");
         ColorShader = new ShaderProgram();
         ColorShader.Create(gl, vertexShaderSource1, fragmentShaderSource1, null);
         ColorShader.AssertValid(gl);

         //  Create a perspective projection matrix.
         const float rads = (60.0f / 360.0f) * (float)Math.PI * 2.0f;
         projectionMatrix = glm.perspective(rads, Width / Height, 0.1f, 100.0f);

         //  Create a view matrix to move us back a bit.
         viewMatrix = glm.translate(new mat4(1.0f), new vec3(0.0f, 0.0f, -3.0f));

         //  Create a model matrix to make the model a little bigger.
         modelMatrix = glm.scale(new mat4(1.0f), new vec3(2.5f));

         table = new LoaderModel(gl, "table.obj", "1.jpg", 1);
         pump = new LoaderModel(gl, "pump.obj", "2.jpg", 2);
         kolba = new ColorModel(gl, "kolba.obj", new vec4(1.0f, 1.0f, 1.0f, 0.6f), 3);         
         
      }

      private void openGLControl1_OpenGLDraw_1(object sender, SharpGL.RenderEventArgs args)
      {
         gl.ClearColor(0.369f, 0.8f, 0.949f, 1); // Цвет очистки экрана
         gl.Clear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); // очистка буфера цвета и глубины
        
         TextShader.Bind(gl);
         viewMatrix = glm.lookAt(cameraPos, cameraPos + cameraFront, cameraUp);
         TextShader.SetUniformMatrix4(gl, "projectionMatrix", projectionMatrix.to_array());
         TextShader.SetUniformMatrix4(gl, "viewMatrix", viewMatrix.to_array());
         TextShader.SetUniformMatrix4(gl, "modelMatrix", modelMatrix.to_array());
         gl.Enable(GL_DEPTH_TEST);
         mat4 view1 = glm.rotate(viewMatrix, glm.radians(90.0f), new vec3(1.0f, 0.0f, 0.0f));
         TextShader.SetUniformMatrix4(gl, "viewMatrix", view1.to_array());
         table.Draw();


         //отрисовка колбы
         view1 = glm.translate(view1, new vec3(0.0f, 2.0f, 0.0f));
         view1 = glm.rotate(view1, glm.radians(180.0f), new vec3(0.0f, 1.0f, 0.0f));
         //TextShader.SetUniformMatrix4(gl, "viewMatrix", view1.to_array());
         ColorShader.Bind(gl);
         ColorShader.SetUniformMatrix4(gl, "projectionMatrix", projectionMatrix.to_array());
         ColorShader.SetUniformMatrix4(gl, "viewMatrix", view1.to_array());
         ColorShader.SetUniformMatrix4(gl, "modelMatrix", modelMatrix.to_array());
         gl.Enable(GL_DEPTH_TEST);
         kolba.Draw();

         TextShader.Bind(gl);
         //var view2 = gl,;
         mat4 mod1 = glm.scale(new mat4(1.0f), new vec3(0.3f));
         TextShader.SetUniformMatrix4(gl, "viewMatrix", view1.to_array());
         TextShader.SetUniformMatrix4(gl, "modelMatrix", mod1.to_array());
         pump.Draw();
         


         gl.Flush();
      }

      private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.KeyValue)
         {
            case 'W': { cameraPos += 0.1f * cameraFront; } break;
            case 'S': { cameraPos -= 0.1f * cameraFront; } break;
            case 'A': { cameraPos -= glm.normalize(glm.cross(cameraFront, cameraUp)) * 0.1f; } break;
            case 'D': { cameraPos += glm.normalize(glm.cross(cameraFront, cameraUp)) * 0.1f; } break;
         }
      }

      private void openGLControl1_KeyUp(object sender, KeyEventArgs e)
      {
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
         PositionStart[0] = -1;
         PositionStart[1] = -1;
         Cons.Text += "\nLeave\n";
      }

      private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
      {
         if (PositionStart[0] != -1 && PositionStart[0] != -1)
         {

            float xoffset = PositionStart[0] - e.X;
            float yoffset = e.Y - PositionStart[1]; // reversed since y-coordinates go from bottom to top
            PositionStart[0] = e.X;
            PositionStart[1] = e.Y;
            float sensitivity = 0.1f; // change this value to your liking
            xoffset *= sensitivity;
            yoffset *= sensitivity;

            yaw += xoffset;
            pitch += yoffset;

            // make sure that when pitch is out of bounds, screen doesn't get flipped
            if (pitch > 89.0f)
               pitch = 89.0f;
            if (pitch < -89.0f)
               pitch = -89.0f;

            vec3 front;
            front.x = (float)(Math.Cos(glm.radians(yaw)) * Math.Cos(glm.radians(pitch)));
            front.y = (float)Math.Sin(glm.radians(pitch));
            front.z = (float)(Math.Sin(glm.radians(yaw)) * Math.Cos(glm.radians(pitch)));
            cameraFront = glm.normalize(front);
         }
      }

      private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
      {
         PositionStart[0] = -1;
         PositionStart[1] = -1;
      }

   }
}
