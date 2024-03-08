using System;
using System.Collections;
using System.Collections.Generic;
using ExerciciPila;
using PilaEstatica;

namespace Pila
{
    class Test2
    {
        public const int MAX = 5;
        public const int MAXOPCIONS = 10;
        static int Menu()
        {
            int opcio = 0;
            bool correcte = false;
            do
            {
                Console.WriteLine("\n\nMenú");
                Console.WriteLine("----\n");
                Console.WriteLine("\t1.- Empilar");
                Console.WriteLine("\t2.- Desempilar");
                Console.WriteLine("\t3.- Cim");
                Console.WriteLine("\t4.- Plena");
                Console.WriteLine("\t5.- Buida");
                Console.WriteLine("\t6.- Clone");
                Console.WriteLine("\t7.- Equals");
                Console.WriteLine("\t8.- ToString");
                Console.WriteLine("\t9.- IEnumerator");
                Console.WriteLine("\t10.- ToString de totes");
                Console.WriteLine("\t\n0.- Sortir");
                Console.Write("\n\nOpcio: ");
                try
                {
                    opcio = int.Parse(Console.ReadLine());
                    if ((opcio >= 0) && (opcio <= 10))
                        correcte = true;
                    else
                        correcte = false;
                }
                catch
                {
                    correcte = false;
                }

            } while (!correcte);
            return opcio;
        }

        static int QuinElement()
        {
            int n = 0;
            bool correcte = false;

            do
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if ((n >= 0) && (n <= MAX))
                        correcte = true;
                    else
                        correcte = false;
                }
                catch
                {
                    correcte = false;
                    Console.Write("\nHa de ser un número entre 0 i {0}. Torna-ho a intentar: ", MAX - 1);
                }

            } while (!correcte);
            return n;
        }

        static int LlegirNumero()
        {
            int n = 0;
            bool correcte = false;

            do
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    correcte = true;
                }
                catch
                {
                    correcte = false;
                    Console.Write("\nHa de ser un número enter. Torna-ho a intentar: ");
                }

            } while (!correcte);
            return n;
        }
        static void Main(string[] args)
        {
            Pila<int> pilaDeEnters= new Pila<int>();    
           
            Pila<int>[] vec = new Pila<int>[MAX];
            int i, j, opcio;
            Tests.test();

            // inicialitzem la taula
            for (i = 0; i < MAX; i++)
            {
                vec[i] = new Pila<int>();
            }

            /**** Proves ***/
            /**** Proves ***/
            /**** Proves ***/
            /**** Proves ***/
            //Empilem uns quants elements a la pila 0
            vec[0].Empila(1);
            vec[0].Empila(2);
            vec[0].Empila(3);
            vec[0].Empila(4);
            vec[0].Empila(5);

            //Empilem uns quants elements a la pila 1
            vec[1].Empila(1);
            vec[1].Empila(2);
            vec[1].Empila(3);
            vec[1].Empila(4);
            vec[1].Empila(5);
            vec[1].Empila(6);
            vec[1].Empila(7);
            vec[1].Empila(8);
            vec[1].Empila(9);
            vec[1].Empila(10);
            do
            {
                opcio = Menu();
                switch (opcio)
                {
                    case 1:
                        Console.Write("\nA quina pila vols empilar? ");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila abans de modificar és: {0}", vec[i].ToString());
                        Console.Write("Quin element vols posar?");
                        j = LlegirNumero();
                        try
                        {
                            vec[i].Empila(j);
                            Console.WriteLine("\nLa pila modificada és: {0}", vec[i]);
                        }
                        catch
                        (Exception e)
                        { Console.WriteLine(e.Message); }
                        break;
                    case 2:
                        Console.Write("\nDe quina pila vols desempilar? ");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila abans de modificar és: {0}", vec[i].ToString());
                        try
                        {
                            vec[i].Desempila();
                            Console.WriteLine("\nLa pila modificada és: {0}", vec[i]);
                        }
                        catch
                        (Exception e)
                        { Console.WriteLine(e.Message); }
                        break;
                    case 3:
                        Console.Write("\nDe quina pila vols saber el cim? ");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila és: {0}", vec[i].ToString());
                        Console.Write("\nEl cim de la pila és: ");
                        Console.Write("{0}", (vec[i].Cim).ToString());
                        break;
                    case 4:
                        Console.Write("\nQuina pila vols saber si es plena?");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila és: {0}", vec[i].ToString());
                        Console.WriteLine("\nLa pila és plena? {0}", vec[i].EsPlena);
                        break;
                    case 5:
                        Console.Write("\nQuina pila vols saber si es buida?");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila és: {0}", vec[i].ToString());
                        Console.WriteLine("\nLa pila és buida? {0}", vec[i].EsBuida);
                        break;
                    case 6:
                        Console.Write("\nQuina pila vols clonar?");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila és: {0}", vec[i].ToString());
                        Console.Write("\nA quina posició la vols clonar?");
                        j = QuinElement();
                        // vec[j] = (Pila<int>)vec[i].Clone();
                        Console.WriteLine("\nLa pila clonada és: {0}", vec[j].ToString());
                        break;
                    case 7:
                        Console.Write("\nQuina és la primera pila que vols comparar?");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila és: {0}", vec[i].ToString());
                        Console.Write("\nQuina és la segona pila que vols comparar?");
                        j = QuinElement();
                        Console.WriteLine("\nLa pila és: {0}", vec[i].ToString());
                        Console.WriteLine("\nLes piles son iguals?: {0}", Equals(vec[i], vec[j]));
                        break;
                    case 8:
                        Console.Write("\nQuina pila vols mostrar? ");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila és: {0}", vec[i].ToString());
                        break;
                    case 9:
                        Console.Write("\nQuina pila vols iterar?");
                        i = QuinElement();
                        Console.WriteLine("\nLa pila iterada és: ");
                        // IEnumerator<int> dit = vec[i].GetEnumerator();
                        Console.WriteLine("****************************");
                        // while (dit.MoveNext())
                        // {
                        //     Console.WriteLine(dit.Current.ToString());
                        // }
                        Console.WriteLine("****************************");
                        break;
                    case 10:
                        foreach (Pila<int> elem in vec)
                        {
                            Console.WriteLine(elem.ToString());
                        }
                        break;
                }
            } while (opcio != 0);
            //Console.Clear();
            //Pila<String> p = new Pila<string>();
            //Pila<String> p2 = new Pila<string>(30);
            //Pila<String> p3 = null;

            //try
            //{
            //    for (int i = 0; i < 12; i++)
            //    {
            //        p.Empilar(i + "-->HOLA");
            //        if (i < 10) p2.Empilar(i + "-->HOLA");
            //        Console.WriteLine(p.Cim + " PLENA --> " + p.Plena);
            //    }


            //}
            //catch (Exception eEmpilar)
            //{
            //    Console.WriteLine(eEmpilar.Message);
            //    p3 = (Pila<String>)p2.Clone();
            //    Console.WriteLine("LA PILA 3-->");
            //    Console.WriteLine(p3);
            //    Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    Console.WriteLine("COMPAREM LA PILA 3 I LA PILA 2-->");
            //    if (p2.Equals(p3)) Console.WriteLine("LES PILES \n" + p2 + "\ni:\n" + p3 + "\nson iguals");
            //    else Console.WriteLine("LES PILES \n" + p2 + "\ni:\n" + p3 + "\nson diferents");
            //    p3.Desempilar();

            //    Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    Console.WriteLine("UN COP DESEMPILAT UN ELEMENT DE P3 COMPAREM LA PILA 3 I LA PILA 2-->");
            //    if (p2.Equals(p3)) Console.WriteLine("LES PILES \n" + p2 + "\ni:\n" + p3 + "\nson iguals");
            //    else Console.WriteLine("LES PILES \n" + p2 + "\ni:\n" + p3 + "\nson diferents");
            //    Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    if (p.Equals(p2)) Console.WriteLine("LES PILES \n" + p + "\ni:\n" + p2 + "\nson iguals");
            //    else Console.WriteLine("LES PILES \n" + p + "\ni:\n" + p2 + "\nson diferents");
            //    Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    p2.Desempilar();
            //    if (p.Equals(p2)) Console.WriteLine("LES PILES +\n" + p + "\ni:\n" + p2 + "\nson iguals");
            //    else Console.WriteLine("LES PILES \n" + p + "\ni:\n" + p2 + "\nson diferents");
            //    Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    p2.Empilar("ADEU");
            //    if (p.Equals(p2)) Console.WriteLine("LES PILES \n" + p + "\ni:\n" + p2 + "\nson iguals");
            //    else Console.WriteLine("LES PILES \n" + p + "\ni:\n" + p2 + "\nson diferents");
            //    Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    Console.WriteLine("FOREACH");
            //    Console.WriteLine(p);
            //    foreach (string s in p) Console.WriteLine(s);
            //    IEnumerator enumerador = p.GetEnumerator();
            //    while (enumerador.MoveNext())
            //    {
            //        Console.WriteLine(enumerador.Current);

            //    }
            //    enumerador.Reset();




            //    Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    try
            //    {
            //        for (int i = 0; i < 12; i++)
            //        {
            //            Console.WriteLine("**" + p + "**");
            //            Console.WriteLine(p.Desempilar() + " BUIDA -->" + p.Buida);
            //        }
            //        Console.WriteLine("PREM UNA TECLA PER SEGUIR"); Console.ReadKey(); Console.Clear();
            //    }
            //    catch (Exception eDesempilar)
            //    {
            //        Console.WriteLine(eDesempilar.Message);

            //    }
            //}
        }
    }
}
