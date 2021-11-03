using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace pascariu_cosmin_3134A
{
    class CreateCube
    {
        private double[,] v; // Tablou multidimesional ce stocheaza coordonatele vertexurilor din fisier

        private double r = 1, g = 1, b = 1, a = 1; // variabile utilizate la schimbarea culorii unei fete a cubului
        private Color color1 = Color.Green, color2 = Color.Green, color3 = Color.Green;
        private RandomColor randomColor;

        // Declarare variabila controller pentru mofidicarea culorilor triunghiurilor
        private ColorControl cubeColor;

        public CreateCube(string Fisier)
        {
            v = new double[3, 36];
            int contor = 0;
            string line;
            ///Citirea coordonatelor vertexurilor din fisierul text
            System.IO.StreamReader file = new System.IO.StreamReader(@Fisier); 
            while ((line = file.ReadLine()) != null)
            {
                string[] lines = line.Split(',');

                for (int i = 0; i < lines.Length; i++)
                    v[contor, i] = Convert.ToDouble(lines[i]);
                contor++;
            }

            cubeColor = new ColorControl();
            randomColor = new RandomColor(); 
        }

        public void SetColor()
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            // Apelare metoda pentru verificarea starii tastaturii si setarea culorilor de pe fiecare canal
            cubeColor.SetColor(keyboard, ref r, ref g,ref  b,ref  a);
            cubeColor.SetVertexColor(keyboard, ref color1, ref color2, ref color3);
        }
        public void Draw()
        {
            GL.Begin(PrimitiveType.Triangles); //Desenarea unui triunghi
            for (int i = 0; i < 22; i = i + 3)
            {
                GL.Color3(Color.Purple);
                if (i == 18) GL.Color3(color1);
                GL.Vertex3(v[0, i], v[1, i], v[2, i]);
                GL.Color3(Color.Red);
                if (i == 18) GL.Color3(color2);
                GL.Vertex3(v[0, i + 1], v[1, i + 1], v[2, i + 1]);
                GL.Color3(Color.Gold);
                if (i == 18) GL.Color3(color3);
                GL.Vertex3(v[0, i + 2], v[1, i + 2], v[2, i + 2]);
            }
            for (int i = 21; i < 28; i = i + 3) //////////////// Cerinta 1 - Modificarea culorilor unei laturi a cubului 
            {
                GL.Color4(r, g, b, a);

                GL.Vertex3(v[0, i], v[1, i], v[2, i]);
                GL.Vertex3(v[0, i + 1], v[1, i + 1], v[2, i + 1]);
                GL.Vertex3(v[0, i + 2], v[1, i + 2], v[2, i + 2]);
            }
            for (int i = 27; i < 35; i = i + 3)
            {
                GL.Color3(Color.Red);
                GL.Vertex3(v[0, i], v[1, i], v[2, i]);
                GL.Color3(Color.Purple);
                GL.Vertex3(v[0, i + 1], v[1, i + 1], v[2, i + 1]);
                GL.Color3(Color.Gold);
                GL.Vertex3(v[0, i + 2], v[1, i + 2], v[2, i + 2]);
            }
            GL.End();
        }
    }
}
