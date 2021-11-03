using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace pascariu_cosmin_3134A
{
    class Axes // Clasa ce realizeaza desenarea axelor Ox,Oy si Oz
    {
        public const int XYZ_SIZE = 25;

        public void Draw()
        {
            GL.LineWidth(2.0f);

            GL.Begin(PrimitiveType.Lines);
            // Desenează axa Ox
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            // Desenează axa Oy.
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, XYZ_SIZE, 0);
            // Desenează axa Oz.
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }
    }
}
