using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciciPila;

namespace PilaEstatica
{
    public class Tests
    {
        //Número d'elements intern de la pila.
        //El fem servir per provar el ToString.
        public const int MAX_ELEMENTS_PILA = 10;

        public class Elefant : ICloneable
        {
            private string nom;
            private int edat;
            public string Nom { get => nom; set => nom = value; }
            public int Edat { get => edat; set => edat = value; }

            public Elefant(string nom, int edat)
            {
                this.nom = nom;
                this.edat = edat;
            }

            public object Clone()
            {
                return new Elefant(this.nom, this.edat);
            }
        }

        static int executaTest(Action funcio)
        {
            int ret = 0;
            try
            {
                funcio();
                ret++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"--- El test: {funcio.Method.Name}, no passa");
            }
            return ret;
        }

        static void empilaIDesempila()
        {
            Pila<int> pila = new Pila<int>();
            pila.Empila(3);
            int valor = pila.Desempila();
            if (valor != 3)
                throw new Exception("No desempila el que hauria");
            if (!pila.EsBuida)
                throw new Exception("La pila hauria de ser buida");
        }

        static void provaCim()
        {
            Pila<int> pila = new Pila<int>();
            pila.Empila(3);
            pila.Empila(4);
            if (pila.Cim != 4)
                throw new Exception("Error el cim de la pila ha de ser 3");
        }

        static void provaEquals()
        {
            Pila<int> pila = new Pila<int>();
            pila.Empila(3);
            pila.Empila(4);

            Pila<int> pila2 = new Pila<int>();
            pila2.Empila(3);
            pila2.Empila(4);

            if (!pila.Equals(pila2))
                throw new Exception("Error la pila ha de ser igual");
        }

        static void buidaIExcepcio()
        {
            Pila<int> pila = new Pila<int>();
            bool excepcioExecutada = false;
            try
            {
                pila.Desempila();
            }
            catch (Exception)
            {
                excepcioExecutada = true;
            }
            if (!excepcioExecutada)
                throw new Exception("S'hauria d'executar una excepció i no ho ha fet.");
        }

        static void revisioToString()
        {
            Pila<int> pila = new Pila<int>(MAX_ELEMENTS_PILA);
            if (!pila.ToString().ToLower().Contains("buida"))
                throw new Exception("Error la pila hauria de marcar buida.");

            for (int i = 0; i < 10; i++)
            {
                pila.Empila(MAX_ELEMENTS_PILA);
            }
            if (!pila.ToString().ToLower().Contains("plena"))
                throw new Exception("Error la pila hauria de marcar plena.");

            pila = new Pila<int>();
            pila.Empila(3);
            pila.Empila(4);

            var valor = pila.ToString().ToLower();
            if (!(valor.Contains("3") && valor.Contains("4")))
                throw new Exception("La pila ha de contenir el 3 i el 4.");
        }

        public static void esPlenaIEsBuida()
        {
            var r = new Random();
            var pila = new Pila<int>(MAX_ELEMENTS_PILA);
            if (!pila.EsBuida)
                throw new Exception("La pila ha de ser buida");
            for (int i = 0; i < MAX_ELEMENTS_PILA; i++)
            {
                pila.Empila(r.Next(int.MaxValue));
            }
            if (!pila.EsPlena)
                throw new Exception("La pila ha de ser buida");
        }

        // public static void testEnumerador()
        // {
        //     Stack<int> s = new Stack<int>();
        //     var r = new Random();
        //     var pila = new Pila<int>(MAX_ELEMENTS_PILA);
        //     for (int i = 0; i < MAX_ELEMENTS_PILA; i++)
        //     {
        //         int valor = r.Next(int.MaxValue);
        //         pila.Empila(valor);
        //         s.Push(valor);
        //     }
        //
        //     if (!(pila.Count() == s.Count))
        //         throw new Exception("L'enumerador no fa bé el recompte");
        //
        //     foreach (var elem in pila)
        //     {
        //         var valor = s.Pop();
        //         if (valor != elem)
        //             throw new Exception("L'enumerador ha retornat un valor que no toca, " +
        //                 "pot ser que recorris a l'inversa la pila.");
        //     }
        // }

        // public static void deepClone()
        // {
        //     var pila = new Pila<Elefant>(MAX_ELEMENTS_PILA);
        //     for (int i = 0; i < MAX_ELEMENTS_PILA; i++)
        //     {
        //         pila.Empila(new Elefant("ele" + i, i));
        //     }
        //     var pila2 = (Pila<Elefant>)pila.Clone();
        //     var e1 = pila2.Desempila();
        //     e1.Nom = "Panxo";
        //     e1.Edat = 100;
        //
        //     var e1c = pila.Desempila();
        //     if (!(e1c.Nom == "ele" + (MAX_ELEMENTS_PILA-1).ToString() && e1c.Edat == MAX_ELEMENTS_PILA-1))
        //         throw new Exception("Error no ha fet una copia profunda");
        // }

        public static void test()
        {
            int comptador = 0;
            comptador += executaTest(empilaIDesempila);
            comptador += executaTest(buidaIExcepcio);
            comptador += executaTest(provaCim);
            comptador += executaTest(provaEquals);
            comptador += executaTest(revisioToString);
            comptador += executaTest(esPlenaIEsBuida);
            //comptador += executaTest(testEnumerador);
            //comptador += executaTest(deepClone);

            Console.WriteLine($"---> Resultat test:{comptador} <----");
        }
    }
}
