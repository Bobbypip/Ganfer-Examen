using System;
using System.Collections.Generic;
using System.Text;

namespace Ganfer_Examen
{
    class Ejercicio2
    {
        static void Main(string[] args)
        {
            string sucesion = "";
            int[] progresion = { 0, 0, 0 };
            string[] sucesionArr;
            List<Progresion> progresiones = new List<Progresion>();
            Console.WriteLine("Digita tu sucesion a1, a2, a3");

            while (sucesion != "0,0,0")
            {
                sucesion = Console.ReadLine();
                sucesion = sucesion.Replace(" ", "");
                sucesionArr = sucesion.Split(',');

                for (int i = 0; i < sucesionArr.Length; i++)
                {
                    progresion[i] = Int32.Parse(sucesionArr[i]);
                }

                int[] progre = new int[] { progresion[0], progresion[1], progresion[2] };

                if (sucesion != "0,0,0")
                {
                    progresiones.Add(new Progresion(progre));
                }
            }

            foreach (var x in progresiones)
            {
                if (!x.proAritmetica())
                {
                    x.proGeometrica();
                }
                Console.WriteLine(x.progresion[0] + " " + x.progresion[1] + " " + x.progresion[2] + "\t" + x.resultado + " " + x.siguiente);
            }

            Console.ReadLine();
        }
    }

    class Progresion
    {
        public int[] progresion;
        public int siguiente = 0;
        public string resultado = "";

        public Progresion(int[] progresion)
        {
            this.progresion = progresion;
        }

        //Regresara true la secuencia es un progresion arimetica
        public bool proAritmetica()
        {
            int[] progre = this.progresion;
            Boolean ret = true;
            int cero_uno = Math.Abs(progre[1] - progre[0]);
            int uno_dos = Math.Abs(progre[2] - progre[1]);

            if (cero_uno != uno_dos)
            {
                ret = false;
            }
            else
            {
                this.siguiente = progre[2] + uno_dos;
            }
            if (ret)
            {
                resultado = "AP";
            }
            return ret;
        }

        public bool proGeometrica()
        {
            int[] progre = this.progresion;
            Boolean ret = true;
            int cero_uno = progre[1] / progre[0];
            int uno_dos = progre[2] / progre[1];

            if (
                (cero_uno != uno_dos) &&
                cero_uno >= 2
                )
            {
                ret = false;
            }
            else
            {
                this.siguiente = progre[2] * uno_dos;
            }
            if (ret)
            {
                resultado = "GP";
            }

            return ret;
        }


    }
}
