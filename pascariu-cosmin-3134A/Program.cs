using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace pascariu_cosmin_3134A
{
    class Program : GameWindow
    {
        //declararea vectorului care stocheaza coordonatele triunghiului
        private double[,] v = new double[3,3];
        private double r=1, g=1, b=1 ,a=1;
        private const double MIN = 0;
        private const double MAX = 1;
        private const double step = 0.025;
        private Camera camera;
        private Color color1, color2, color3;

        System.IO.StreamReader file = new System.IO.StreamReader(@"./../../date.txt"); /// Citirea din fisier pentru cerinta 8

        public Program() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";
            int contor = 0;
            string line;

            camera = new Camera();
            ///Citirea coordonatelor vertexurilor din fisierul text
            while ((line = file.ReadLine()) != null)
            {
                string[] lines = line.Split(',');
                for (int i = 0; i < lines.Length; i++)
                    v[contor,i] = Convert.ToDouble(lines[i]);
                contor++;
            }

            //Crearea culorilor pentru cel de-al doilea triunghi - cerinta 9
            color1 = Color.White;
            color2 = Color.White;
            color3 = Color.White;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black); //Am schimbat culoarea fundalului pentru a iesi in evidenta schimbarea culorilor triunghiului
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height); //Am dat alte valori pentru a plasa triunghiul in centrul ferestrei

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(0, 0, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            ///apelare metoda pentru initializarea pozitiei camerei
            camera.SetCamera();
        }
        
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            #region rgbaValuesFromKeyboard
            ////Modificarea unghiului camerei prin intermediul mouse-ului
            if (mouse[OpenTK.Input.MouseButton.Left] && mouse.X > 100)
            {
                camera.RotateRight();
            }
            else if (mouse[OpenTK.Input.MouseButton.Left] && mouse.X < 100)
            {
                camera.RotateLeft();
            }
            /////////////////////////
            

            ///////Schimbarea canalelor de culoare a primului triunghi - cerinta 8
            if (keyboard[Key.R] && keyboard[Key.Up])
            {
                if(r >= MIN && r < MAX-0.1)
                    r += step;
               
            }
            if (keyboard[Key.R] && keyboard[Key.Down])
            {
                
                if(r > MIN+0.1 && r <=MAX)
                    r -= step;
               
            }
            if (keyboard[Key.G] && keyboard[Key.Up])
            {
                if (g >= MIN && g < MAX-0.1)
                {
                    g += step;
                }
            }
            if (keyboard[Key.G] && keyboard[Key.Down])
            {
                if (g > MIN+0.1 && g <= MAX)
                {
                    g -= step;
                }
            }
            if (keyboard[Key.B] && keyboard[Key.Up])
            {
                if (b >= MIN && b < MAX-0.1)
                {
                    b += step;
                }
            }
            if (keyboard[Key.B] && keyboard[Key.Down])
            {
                if (b > MIN+0.1 && b <= MAX)
                {
                    b -= step;
                }
            }
            if (keyboard[Key.A] && keyboard[Key.Up])
            {
                if (a >= MIN && a < MAX-0.1)
                {
                    a += step;
                }
            }
            if (keyboard[Key.A] && keyboard[Key.Down])
            {
                if (a > MIN+0.1 && a <= MAX)
                {
                    a -= step;
                }
            }
            /////////////////////////
            #endregion

            Color vert1 = color1;
            Color vert2 = color2;
            Color vert3 = color3;
            ///Schimbarea culorilor celui de-al doilea triunghi
            if(keyboard[Key.Number1])
            {
                color1 = Color.FromArgb(255, 255, 0, 255);
            }
            if (keyboard[Key.Number2])
            {
                color1 = Color.FromArgb(255,0, 0, 255);
            }
            if (keyboard[Key.Number3])
            {
                color2 = Color.FromArgb(255, 120, 120, 25);
            }
            if (keyboard[Key.Number4])
            {
                color2 = Color.FromArgb(255, 10, 70, 251);
            }
            if (keyboard[Key.Number5])
            {
                color3 = Color.FromArgb(255, 10, 250, 0);
            }
            if (keyboard[Key.Number6])
            {
                color3 = Color.FromArgb(255, 100, 170, 21);
            }
            /////////////////////////////////////
            ///
            ////Afisarea culorilor rgb in consola
            if(vert1 != color1)
            {
                Console.WriteLine("Vertex1: " + vert1);
            }
            if (vert2 != color2)
            {
                Console.WriteLine("Vertex2: " + vert3);
            }
            if (vert3 != color3)
            {
                Console.WriteLine("Vertex3: " + vert3);
            }
            if (keyboard[Key.Escape])
            {
                Exit();
                file.Close();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            DrawAxes();

            DrawObjects();

            SwapBuffers();
        }

        private void DrawAxes()
        {
            GL.LineWidth(1.0f);

            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(75, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 75, 0); ;
            GL.End();

            //// Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 75);
            GL.End();
        }
        private void DrawObjects()
        {
            //////Desenare folosind un singur apel GL.Begin
            ///Desenarea primului triunghi
            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(r, g, b, a);
            GL.Vertex3(v[0, 0], v[0, 1], v[0, 2]);
            GL.Vertex3(v[1, 0], v[1, 1], v[1, 2]);
            GL.Vertex3(v[2, 0], v[2, 1], v[2, 2]);
           
            ////Desenarea celui de-al doilea triunghi
            GL.LineWidth(1.0f);
            GL.Color3(color1);
            GL.Vertex3(0,0,0);
            GL.Color3(color2);
            GL.Vertex3(10,0,0);
            GL.Color3(color3);
            GL.Vertex3(5,0,10);
            GL.End();
            /////////////////////////////
        }


        [STAThread]
        static void Main(string[] args)
        {

            /**Utilizarea cuvântului-cheie "using" va permite dealocarea memoriei o dată ce obiectul nu mai este
               în uz (vezi metoda "Dispose()").
               Metoda "Run()" specifică cerința noastră de a avea 30 de evenimente de tip UpdateFrame per secundă
               și un număr nelimitat de evenimente de tip randare 3D per secundă (maximul suportat de subsistemul
               grafic). Asta nu înseamnă că vor primi garantat respectivele valori!!!
               Ideal ar fi ca după fiecare UpdateFrame să avem si un RenderFrame astfel încât toate obiectele generate
               în scena 3D să fie actualizate fără pierderi (desincronizări între logica aplicației și imaginea randată
               în final pe ecran). */
            using (Program example = new Program())
            {
                example.Run(30.0, 0.0);
            }

           
        }
    }

}
