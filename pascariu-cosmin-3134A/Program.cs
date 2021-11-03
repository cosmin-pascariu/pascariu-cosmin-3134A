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
       
        [STAThread]
        static void Main(string[] args)
        {
            using (Window example = new Window())
            {
                example.Run(30.0, 0.0);
            }

        }
    }

}
