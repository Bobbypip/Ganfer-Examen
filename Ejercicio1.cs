using System;
using System.Collections.Generic;
using System.Text;

namespace Ganfer_Examen
{
    class Ejercicio1
    {
        static void Main(string[] args)
        {
            string gettexto = "";
            string resultado = "";
            List<Password> passwords = new List<Password>();

            Console.WriteLine("Escribe tus passwords:");

            while (gettexto != "end")
            {
                gettexto = Console.ReadLine();
                if (gettexto != "end")
                {
                    passwords.Add(new Password(gettexto));
                }
            }

            Console.WriteLine("\n");
            foreach (var x in passwords)
            {
                Boolean contenerVocal = x.contenerVocal();
                Boolean no_Contener_Tres_AlfaConsecutivos = true;
                if (x.texto.Length >= 3)
                {
                    no_Contener_Tres_AlfaConsecutivos = x.no_Contener_Tres_AlfaConsecutivos();
                }
                Boolean solo_oo_ee = true;
                if (x.texto.Length >= 2)
                {
                    solo_oo_ee = x.solo_ee_oo();
                }
                Boolean longitud_uno_a_veinte = x.longitud_uno_a_veinte();
                Boolean soloLetrasMinusculas = x.soloLetrasMinusculas();

                if (
                    contenerVocal &&
                    no_Contener_Tres_AlfaConsecutivos &&
                    solo_oo_ee &&
                    longitud_uno_a_veinte &&
                    soloLetrasMinusculas
                    )
                {
                    resultado = "OK";
                }
                else
                {
                    resultado = "NO";
                }

                Console.WriteLine(x.texto + "\t\t\t" + resultado);
            }

            Console.WriteLine("Presiona ENTER para salir");
            Console.ReadLine();

        }
    }

    class Password
    {

        public string texto;
        public string[] vocals = { "a", "e", "i", "o", "u" };
        public string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "ñ", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
        public string[] consec = { "ee", "oo" };

        public Password(string texto)
        {
            this.texto = texto;
        }

        //Regresa true si el string contiene una vocal
        public bool contenerVocal()
        {
            string password = this.texto;
            Boolean ret = true;
            int i = 0;

            while (ret && (i < vocals.Length))
            {
                if (password.Contains(vocals[i]))
                {
                    ret = false;
                }
                else
                {
                    i++;
                }
            }

            return !ret;
        }

        //Regresa true si el caracter es una vocal minuscula
        private bool esVocal(string c)
        {
            Boolean ret = false;
            int i = 0;

            if (c.Length < 2)
            {
                while (!ret && (i < vocals.Length))
                {
                    if (c == vocals[i])
                    {

                        ret = true;
                    }
                    i++;
                }
            }

            return ret;
        }

        //Regresa true si el caracter es una consonante minuscula
        private bool esConsonante(string c)
        {
            Boolean ret = false;
            int i = 0;

            if (c.Length < 2)
            {
                while (!ret && (i < consonants.Length))
                {
                    if (c == consonants[i])
                    {

                        ret = true;
                    }
                    i++;
                }
            }

            return ret;
        }

        //Regresa true si el string tiene 3 letras consecutivas vocales o consonantes, para strings de 3 caracteres o mas
        public bool no_Contener_Tres_AlfaConsecutivos()
        {
            string password = this.texto;
            Boolean ret = true;
            int i = 0;

            while (ret && i < password.Length - 2)
            {
                //Condicion para saber si son 3 vocales consecutivas
                if (this.esVocal(Convert.ToString(password[i])))
                {
                    if ((this.esVocal(Convert.ToString(password[i + 1]))) && (this.esVocal(Convert.ToString(password[i + 2]))))
                    {
                        //Son tres vocales consecutivas
                        ret = false;
                    }
                }

                //Condicion para saber si son 3 consonantes consecutivas
                if (this.esConsonante(Convert.ToString(password[i])))
                {
                    if ((this.esConsonante(Convert.ToString(password[i + 1]))) && (this.esConsonante(Convert.ToString(password[i + 2]))))
                    {
                        //Son tres consonates consecutivas
                        ret = false;
                    }
                }

                i++;
            }
            return ret;
        }

        //Regresa true si tiene dos ocurrencias consecutivas de la misma letra excepto "oo" o "ee", para string de 2 o mas caracteres
        public bool solo_ee_oo()
        {
            string password = this.texto;
            Boolean ret = true;
            int i = 0;

            while (ret && i < password.Length - 1)
            {
                Boolean c = (password[i] == password[i + 1]);
                Boolean ce = (password[i] == 'e');
                Boolean co = (password[i] == 'o');
                if (c)
                {
                    ret = false;

                    if (ce || co)
                    {
                        ret = true;
                    }
                }
                i++;
            }
            return ret;
        }

        //Regresara true si la longitud del string es entre 1 y 20 caracteres
        public bool longitud_uno_a_veinte()
        {
            string password = this.texto;
            Boolean ret = false;

            if ((1 <= password.Length) && (password.Length <= 20))
            {
                ret = true;
            }
            return ret;
        }

        //Regresara true si el string solo contiene carateres del abecedario español en minusculas
        public bool soloLetrasMinusculas()
        {
            string password = this.texto;
            Boolean ret = true;
            int i = 0;

            while (ret && (i < password.Length))
            {
                var con = this.esConsonante(Convert.ToString(password[i]));
                var voc = this.esVocal(Convert.ToString(password[i]));

                if (!con && !voc)
                {
                    ret = false;
                }
                i++;
            }

            return ret;
        }
    }
}
