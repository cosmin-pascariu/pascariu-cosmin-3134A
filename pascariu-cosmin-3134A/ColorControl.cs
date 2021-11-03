using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace pascariu_cosmin_3134A
{
    class ColorControl
    {

        private const double step = 0.025;
        private const double MIN = -0.1;
        private const double MAX = 1.1;
        private double r = 1, g = 1, b = 1, a = 1; //Variabile pentru modificarea culorii unei laturi a cubului 3D

        private KeyboardState lastKeyPressed;

        private RandomColor randomColor = new RandomColor(); 
        //Argumentele de tip ref sunt utilizate pentru a modifica direct variabila(referinta) trimisa ca parametru
        public void SetColor(KeyboardState keyboard, ref double r, ref double g, ref double b, ref double a)
        {
            //////////////////////////////////////// Cerinta 1 - modificarea unei fete a unui cub 3D intre valorile minime si maxime
            if (keyboard[Key.R] && keyboard[Key.Up])
            {
                if (r >= MIN && r < MAX - 0.1)
                    r += step;

            }
            if (keyboard[Key.R] && keyboard[Key.Down])
            {

                if (r > MIN + 0.1 && r <= MAX)
                    r -= step;

            }
            if (keyboard[Key.G] && keyboard[Key.Up])
            {
                if (g >= MIN && g < MAX - 0.1)
                {
                    g += step;
                }
            }
            if (keyboard[Key.G] && keyboard[Key.Down])
            {
                if (g > MIN + 0.1 && g <= MAX)
                {
                    g -= step;
                }
            }
            if (keyboard[Key.B] && keyboard[Key.Up])
            {
                if (b >= MIN && b < MAX - 0.1)
                {
                    b += step;
                }
            }
            if (keyboard[Key.B] && keyboard[Key.Down])
            {
                if (b > MIN + 0.1 && b <= MAX)
                {
                    b -= step;
                }
            }
            if (keyboard[Key.A] && keyboard[Key.Up])
            {
                if (a >= MIN && a < MAX - 0.1)
                {
                    a += step;
                }
            }
            if (keyboard[Key.A] && keyboard[Key.Down])
            {
                if (a > MIN + 0.1 && a <= MAX)
                {
                    a -= step;
                }
            }


        }

        public void SetVertexColor(KeyboardState keyboard, ref Color color1, ref Color color2, ref Color color3)
        {
            ///Declararea a trei culori pentru a stoca valorile random de culori corespunzatoare vertexurilor unui triunghi
            Color vert1 = color1;
            Color vert2 = color2;
            Color vert3 = color3;

            // Cerinta 2 si 3- manipularea valorilor RGB pentru ficecare vertex ce defineste un triunghi, si utilizarea unui mecanism random de modificare a culorilor
            if (keyboard != lastKeyPressed)
            {
                if (keyboard[Key.Number1]) // verifica daca tasta cu numarul 1 este apasata
                {
                    color1 = randomColor.Generate(); // apelarea functiei ce va genera o culoare random
                    Console.WriteLine("Vertex1: " + vert1); // afisarea culorii respective in consola
                }
                if (keyboard[Key.Number2])// verifica daca tasta cu numarul 2 este apasata
                {
                    color2 = randomColor.Generate(); // apelarea functiei ce va genera o culoare random
                    Console.WriteLine("Vertex2: " + vert2);// afisarea culorii respective in consola
                }
                if (keyboard[Key.Number3])// verifica daca tasta cu numarul 3 este apasata
                {
                    color3 = randomColor.Generate();// apelarea functiei ce va genera o culoare random
                    Console.WriteLine("Vertex3: " + vert3);// afisarea culorii respective in consola
                }
            }
            lastKeyPressed = keyboard;
            
        }
    }
}
