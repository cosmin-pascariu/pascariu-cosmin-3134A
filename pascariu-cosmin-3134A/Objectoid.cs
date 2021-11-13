using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace pascariu_cosmin_3134A
{
    public class Objectoid
    {
        /// <summary>
        /// Obiectul acesta va fi plasat im mediul 3D. Sub influenta "gravitatiei", va cadea "in jos" 
        /// </summary>
        private bool visibility;
        private bool isGravityBound;
        private Color colour;
        private Color colour1;
        private List<Vector3> coordList;
        private Randomizer rando;
        private float[,] v;

        private const int GRAVITY_OFFSET = 1;

        /// <summary>
        /// Constructor. Initializarile vor fi plasate aici.
        /// 
        /// Cerinta 3 - Citirea din fisier a coordonatelor obiectului
        /// </summary>
        public Objectoid(bool gravity_status, string Fisier)
        {
            v = new float[3, 18];

            rando = new Randomizer();

            visibility = true;
            isGravityBound = gravity_status;
            colour = rando.RandomColor();
            colour1 = rando.RandomColor();
            int size_offset = rando.RandomInt(5, 10);     // permite crearea de obiecte cu un mic offset de dimensiune (variabile ca dimensiune);
            int heigh_offeset = rando.RandomInt(40, 60); // permite crearea de obiecte plasate la un mic offset de inaltime(diverse inaltimi);  
            int radial_offset = rando.RandomInt(5, 15);  // permite crearea de obiecte cu un mic offset pe directia Ox - Oz pozitive;
            int contor = 0;
            string line;
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(Fisier);
                while ((line = file.ReadLine()) != null)
                {
                    string[] lines = line.Split(',');

                    for (int i = 0; i < lines.Length; i++)
                    {
                        v[contor, i] = float.Parse(lines[i]);
                    }
                    contor++;
                }

                coordList = new List<Vector3>();
                for (int i = 0; i < 18; i++)
                    coordList.Add(new Vector3(v[0, i] * size_offset + radial_offset, v[1, i] * size_offset + heigh_offeset, v[2, i] * size_offset + radial_offset));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

        public void Draw()
        {
            int contor = 0;
            if (visibility)
            {
                GL.Begin(PrimitiveType.QuadStrip);
                foreach (Vector3 v in coordList)
                {
                    contor++;
                    if (contor % 2 == 0)
                        GL.Color3(colour);
                    else
                        GL.Color3(colour1);
                    GL.Vertex3(v);
                }
                GL.End();
            }
        }

        public void UpdatePosition(bool gravity_status)
        {
            if (visibility && gravity_status && !GroundCollisionDetected())
            {
                for (int i = 0; i < coordList.Count; i++)
                    coordList[i] = new Vector3(coordList[i].X, coordList[i].Y - GRAVITY_OFFSET, coordList[i].Z);
            }
        }

        public bool GroundCollisionDetected()
        {
            foreach (Vector3 v in coordList)
                if (v.Y <= 0)
                    return true;
            return false;
        }

        public void ToogleVisibility()
        {
            visibility = !visibility;
        }

        public void ToogleGravity()
        {
            isGravityBound = !isGravityBound;
        }

        public void SetGravity()
        {
            isGravityBound = true;
        }

        public void UnsetGravity()
        {
            isGravityBound = false;
        }


    }
}
