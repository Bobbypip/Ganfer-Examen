using System;
using System.Collections.Generic;
using System.Text;

namespace Ganfer_Examen
{
    class Ejercicio3
    {
        static void Main(string[] args)
        {
            //Inicial;izar variables
            List<double> denominacionesList = new List<double>();
            string[] denominaciones;
            string denominacioes_ = "";

            List<double> salarios = new List<double>();
            double salario = 1;

            List<Salario> salariosList = new List<Salario>();

            //Pedir las denominaciones por medio de un string
            Console.WriteLine("Escribe tus denominaciones de la siguiente manera: a1, a2, a2");
            denominacioes_ = Console.ReadLine();
            denominacioes_ = denominacioes_.Replace(" ", "");
            denominaciones = denominacioes_.Split(',');

            //Convertir denominaciones a datos tipo Double
            for (int i = 0; i < denominaciones.Length; i++)
            {
                denominacionesList.Add(Convert.ToDouble(denominaciones[i]));
            }

            //Organizar denominaciones
            double[] denominacionesArr = denominacionesList.ToArray();
            Array.Sort(denominacionesArr);
            Array.Reverse(denominacionesArr);

            //Pedir los salarios por medio de un string
            Console.WriteLine("Escribe tus salarios uno por uno, presionar enter despues de cada entrada, escribe el salario con valor de 0 para terminar:");
            while (salario != 0)
            {
                salario = Convert.ToDouble(Console.ReadLine());
                if (salario != 0)
                {
                    salariosList.Add(new Salario(salario, denominacionesArr));
                }
            }

            List<double> denominacionesCuenta = new List<double>();

            for (int i = 0; i < denominacionesArr.Length; i++)
            {
                denominacionesCuenta.Add(0);
            }

            double[] denCuenta = denominacionesCuenta.ToArray();

            foreach (var x in salariosList)
            {
                int i = 0;
                foreach (var y in x.denominacionesResult())
                {
                    denCuenta[i] = denCuenta[i] + y;
                    i++;
                }
            }

            Console.WriteLine("\nCantidad de denominanciones: ");
            for (int i = 0; i < denCuenta.Length; i++)
            {
                Console.WriteLine(denominacionesArr[i] + ": \t" + denCuenta[i]);
            }

            Console.ReadLine();
        }
    }

    class Salario
    {
        public double salario_original = 0;
        public double salario = 0;
        public double centavos = 0;

        public double[] denominaciones;

        public Salario(double salario, double[] denominaciones)
        {
            this.salario = salario;
            this.salario_original = salario;
            this.denominaciones = denominaciones;
            this.centavos_();
            this._centavo();
        }

        //Regresa true si tiene centavos.
        private bool centavos_()
        {
            double salario = this.salario;
            Boolean ret = true;

            if (salario != Math.Truncate(salario))
            {
                ret = false;
            }

            return !ret;
        }

        //Resta centavos y agrega cuantas denominaciones(centavo) regresar
        public void _centavo()
        {
            if (this.centavos_())
            {
                this.centavos = this.salario - Math.Truncate(this.salario);
                this.salario = Math.Truncate(this.salario);
            }
        }

        //Resta denominaciones y agrega cuantas denominaciones(individuales) regresar
        public double[] denominacionesResult()
        {
            double[] denoIn = this.denominaciones;

            List<double> denominacionesList = new List<double>();

            for (int i = 0; i < denoIn.Length; i++)
            {
                denominacionesList.Add(0);
            }

            double[] denoOut = denominacionesList.ToArray();

            if (this.centavos > 0)
            {
                denoOut[denoOut.Length - 1] = 1;
            }

            //double salario = this.salario;

            for (int i = 0; i < denoIn.Length; i++)
            {
                if (this.salario >= denoIn[i])
                {
                    denoOut[i] = Math.Truncate(this.salario / denoIn[i]);
                    this.salario = this.salario - (denoIn[i] * denoOut[i]);
                }
            }
            return denoOut;
        }
    }
}
