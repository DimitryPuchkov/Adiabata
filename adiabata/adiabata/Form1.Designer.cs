
namespace adiabata
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.openGLControl1 = new SharpGL.OpenGLControl();
         this.label1 = new System.Windows.Forms.Label();
         this.splitter1 = new System.Windows.Forms.Splitter();
         this.trackBar1 = new System.Windows.Forms.TrackBar();
         this.trackBar2 = new System.Windows.Forms.TrackBar();
         this.trackBar3 = new System.Windows.Forms.TrackBar();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.Cons = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
         this.SuspendLayout();
         // 
         // openGLControl1
         // 
         this.openGLControl1.DrawFPS = true;
         this.openGLControl1.FrameRate = 100;
         this.openGLControl1.Location = new System.Drawing.Point(9, 0);
         this.openGLControl1.Name = "openGLControl1";
         this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL3_0;
         this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
         this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
         this.openGLControl1.Size = new System.Drawing.Size(869, 646);
         this.openGLControl1.TabIndex = 0;
         this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw_1);
         this.openGLControl1.Load += new System.EventHandler(this.openGLControl1_Load);
         this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
         this.openGLControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyUp);
         this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseDown);
         this.openGLControl1.MouseLeave += new System.EventHandler(this.openGLControl1_MouseLeave);
         this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseMove);
         this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseUp);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(884, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(155, 20);
         this.label1.TabIndex = 1;
         this.label1.Text = "Концентрация газа";
         // 
         // splitter1
         // 
         this.splitter1.Location = new System.Drawing.Point(0, 0);
         this.splitter1.Name = "splitter1";
         this.splitter1.Size = new System.Drawing.Size(3, 650);
         this.splitter1.TabIndex = 2;
         this.splitter1.TabStop = false;
         // 
         // trackBar1
         // 
         this.trackBar1.Location = new System.Drawing.Point(925, 52);
         this.trackBar1.Maximum = 100;
         this.trackBar1.Name = "trackBar1";
         this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.trackBar1.Size = new System.Drawing.Size(399, 45);
         this.trackBar1.TabIndex = 4;
         this.trackBar1.UseWaitCursor = true;
         // 
         // trackBar2
         // 
         this.trackBar2.Location = new System.Drawing.Point(925, 103);
         this.trackBar2.Maximum = 100;
         this.trackBar2.Name = "trackBar2";
         this.trackBar2.Size = new System.Drawing.Size(399, 45);
         this.trackBar2.TabIndex = 5;
         // 
         // trackBar3
         // 
         this.trackBar3.Location = new System.Drawing.Point(925, 154);
         this.trackBar3.Maximum = 100;
         this.trackBar3.Name = "trackBar3";
         this.trackBar3.Size = new System.Drawing.Size(399, 45);
         this.trackBar3.TabIndex = 6;
         this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(884, 61);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(30, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "1 ат.";
         this.label2.Click += new System.EventHandler(this.label2_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(884, 112);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(30, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "2 ат.";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(884, 163);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(30, 13);
         this.label4.TabIndex = 9;
         this.label4.Text = "3 ат.";
         // 
         // label5
         // 
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(1330, 52);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(30, 25);
         this.label5.TabIndex = 10;
         this.label5.Text = "20%";
         this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label6
         // 
         this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(1330, 103);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(30, 25);
         this.label6.TabIndex = 11;
         this.label6.Text = "20%";
         this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label7
         // 
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(1330, 154);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(30, 25);
         this.label7.TabIndex = 12;
         this.label7.Text = "60%";
         this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(1366, 58);
         this.label8.Name = "label8";
         this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.label8.Size = new System.Drawing.Size(22, 13);
         this.label8.TabIndex = 13;
         this.label8.Text = "AR";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(1366, 109);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(21, 13);
         this.label9.TabIndex = 14;
         this.label9.Text = "O2";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(1366, 160);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(28, 13);
         this.label10.TabIndex = 15;
         this.label10.Text = "CO2";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(903, 218);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(502, 23);
         this.button1.TabIndex = 16;
         this.button1.Text = "Настройки по умолчанию";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(903, 247);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(502, 23);
         this.button2.TabIndex = 17;
         this.button2.Text = "Начать  эксперимент";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // Cons
         // 
         this.Cons.AutoSize = true;
         this.Cons.Location = new System.Drawing.Point(939, 316);
         this.Cons.Name = "Cons";
         this.Cons.Size = new System.Drawing.Size(0, 13);
         this.Cons.TabIndex = 18;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1464, 650);
         this.Controls.Add(this.Cons);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label10);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.trackBar3);
         this.Controls.Add(this.trackBar2);
         this.Controls.Add(this.trackBar1);
         this.Controls.Add(this.splitter1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.openGLControl1);
         this.Name = "Form1";
         this.Text = "Метод Клемана и Дезорма";
         ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private SharpGL.OpenGLControl openGLControl1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Splitter splitter1;
      private System.Windows.Forms.TrackBar trackBar1;
      private System.Windows.Forms.TrackBar trackBar2;
      private System.Windows.Forms.TrackBar trackBar3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Label Cons;
   }
}

