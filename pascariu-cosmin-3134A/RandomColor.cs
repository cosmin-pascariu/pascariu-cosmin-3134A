using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pascariu_cosmin_3134A
{
    class RandomColor  ////Clasa ce realizeaza generarea unei culori random
    {
        private Random random;

        public RandomColor()
        {
            random = new Random();
        }

        public Color Generate()
        {
            ////Variabile corespunzatoare culorilor RGB in care se vor stoca valori random de culoare
            int red = random.Next(0, 255);
            int green = random.Next(0, 255);
            int blue = random.Next(0, 255);

            Color color = Color.FromArgb(red, green, blue);

            return color;
        }
    }
}
