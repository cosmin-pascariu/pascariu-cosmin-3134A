using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pascariu_cosmin_3134A
{
    class Camera
    {
        private Vector3 eye = new Vector3(0, 10, 30);
        private Vector3 target = new Vector3(0, 0, 0);
        private Vector3 up = new Vector3(0, 1, 0);
        private const int MOVEMENT_UNIT = 1;
            
        ///Initializarea metodei
        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);;
        }

        ///Metoda pentru realizarea schimbarii unghiului spre dreapta
        public void RotateRight()
        {
            if (eye.X < 40 && eye.Z >= 40)
            {
                eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else if (eye.X >= 40 && eye.Z > -40)
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            }
            else if (eye.X > -40 && eye.Z <= -40)
            {
                eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            }
            SetCamera();
        }
        ///Metoda pentru realizarea schimbarii unghiului spre stanga
        public void RotateLeft()
        {
            if (eye.X > -40 && eye.Z >= 40)
            {
                eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else if (eye.X <= -40 && eye.Z > -40)
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            }
            else if (eye.X < 40 && eye.Z <= -40)
            {
                eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            }
            SetCamera();
        }

       
    }
}


