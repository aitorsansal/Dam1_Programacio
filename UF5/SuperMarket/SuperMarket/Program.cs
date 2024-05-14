﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Super
{
    class Program
    {
        public static void MostrarMenu()
        {
            Console.WriteLine("1- UN CLIENT ENTRA AL SUPER I OMPLE EL SEU CARRO DE LA COMPRA");
            Console.WriteLine("2- AFEGIR UN ARTICLE A UN CARRO DE LA COMPRA");
            Console.WriteLine("3- UN CARRO PASSA A CUA DE CAIXA (CHECKIN)");
            Console.WriteLine("4- CHECKOUT DE CUA TRIADA PER L'USUARI");
            Console.WriteLine("5- OBRIR SEGÜENT CUA DISPONIBLE");
            Console.WriteLine("6- INFO CUES");
            Console.WriteLine("7- CLIENTS VOLTANT PEL SUPERMERCAT");
            Console.WriteLine("8- LLISTAR CLIENTS PER RATING (DESCENDENT)");
            Console.WriteLine("9- LLISTAR ARTICLES PER STOCK (DE  - A  +)");
            Console.WriteLine("A- CLOSE QUEUE");
            Console.WriteLine("0- EXIT");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            SuperMarket super = new SuperMarket("HIPERCAR", "C/Barna 99", "CASHIERS.TXT", "CUSTOMERS.TXT", "GROCERIES.TXT", 2);
            //
            Dictionary<Customer,ShoppingCart> carrosPassejant= new Dictionary<Customer,ShoppingCart>();

            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                MostrarMenu();
                tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                        DoNewShoppingCart(carrosPassejant, super);
                        break;
                    case ConsoleKey.D2:
                        DoAfegirUnArticleAlCarro(carrosPassejant, super);
                      
                        break;
                    case ConsoleKey.D3:
                        DoCheckIn(carrosPassejant, super); 
                       
                        break;
                     case ConsoleKey.D4:
                        if (DoCheckOut(super)) Console.WriteLine("BYE BYE. HOPE 2 SEE YOU AGAIN!");
                        else Console.WriteLine("NO S'HA POGUT TANCAR CAP COMPRA");
                        MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
                      
                        break;
                    case ConsoleKey.D5:
                        DoOpenCua(super);
                     
                        break;
                    case ConsoleKey.D6:
                        DoInfoCues(super);
                        
                        break;

                    case ConsoleKey.D7:
                        DoClientsComprant(carrosPassejant);
                        

                        break;
                    case ConsoleKey.D8:
                        DoListCustomers(super);
                       
                        break;

                    case ConsoleKey.D9:
                        HashSet<Item> articlesOrdenatsPerEstoc = super.GetItemsByStock();
                        DoListArticlesByStock("LLISTAT D'ARTICLES - DATA " + DateTime.Now, articlesOrdenatsPerEstoc.OrderBy(x => x.Stock).ToHashSet());
                        
                        break;
                    case ConsoleKey.A:
                        DoCloseQueue(super);
                        
                        break;

                    case ConsoleKey.D0:
                        MsgNextScreen("PRESS ANY KEY 2 EXIT");
                        break;
                    default:
                        MsgNextScreen("Error. Prem una tecla per tornar al menú...");
                        break;
                }

            } while (tecla.Key != ConsoleKey.D0);
            

        }
        //OPCIO 1 - Entra un nou client i se li assigna un carro de la compra. S'omple el carro de la compra
        /// <summary>
        /// Crea un nou carro de la compra assignat a un Customer inactiu
        /// L'omple d'articles aleatòriament 
        /// i l'afegeix als carros que estan passejant pel super
        /// </summary>
        /// <param name="carros">Llista de carros que encara no han entrat a cap 
        /// cua de pagament</param>
        /// <param name="super">necessari per poder seleccionar un client inactiu</param>
        public static void DoNewShoppingCart(Dictionary<Customer,ShoppingCart> carros,SuperMarket super)
        {
            Console.Clear();
            ShoppingCart sp = new ShoppingCart((Customer)super.GetAvailableCustomer(), DateTime.Now);
            sp.AddAllRandomly(super.Warehouse);
            carros.Add(sp.Customer, sp);
            Console.WriteLine($"Welcome to the supermarket, {sp.Customer.FullName}");
            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
        }

        //OPCIO 2 - AFEGIR UN ARTICLE ALEATORI A UN CARRO DE LA COMPRA ALEATORI DELS QUE ESTAN VOLTANT PEL SUPER
        /// <summary>
        /// Dels carros que van passejant pel super, 
        /// es selecciona un carro a l'atzar i un article a l'atzar
        /// i s'afegeix al carro de la compra
        /// amb una quantitat d'unitats determinada
        /// Cal mostrar el carro seleccionat abans i després d'afegir l'article.
        /// </summary>
        /// <param name="carros">Llista de carros que encara no han entrat a cap 
        /// cua de pagament</param>
        /// <param name="super">necessari per poder seleccionar un article del magatzem</param>
        public static void DoAfegirUnArticleAlCarro(Dictionary<Customer,ShoppingCart> carros, SuperMarket super)
        {
            Console.Clear();
            if(carros.Count == 0)
                Console.WriteLine("No hi ha ningú comprant al supermercat actualment.");
            else
            {
                Random r = new();
                ShoppingCart carro = carros.ElementAt(r.Next(0, carros.Count)).Value;
                Item item = super.Warehouse.ElementAt(r.Next(0, super.Warehouse.Count)).Value;
                Console.WriteLine($"Carro abans d'afegir l'item:\n{carro}");
                carro.AddOne(item,
                    item.PackagingType == Item.Packaging.Kg ? Math.Round(r.NextDouble() * 20, 2) : r.Next(1, 20));
                Console.WriteLine($"Carro després d'afegir l'item:\n{carro}");
            }
            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
            
        }
        // OPCIO 3 : Un dels carros que van pululant pel super  s'encua a una cua activa
        // La selecció del carro i de la cua és aleatòria
        /// <summary>
        /// Agafem un dels carros passejant (random) i l'encuem a una de les cues actives
        /// de pagament.
        /// També hem d'eliminar el carro seleccionat de la llista de carros que passejen 
        /// Si no hi ha cap carro passejant o no hi ha cap linia activa, cal donar missatge 
        /// 
        /// </summary>
        /// <param name="carros">Llista de carros que encara no han entrat a cap 
        /// cua de pagament</param>
        /// <param name="super">necessari per poder encuar un carro a una linia de caixa</param>
        public static void DoCheckIn(Dictionary<Customer,ShoppingCart> carros, SuperMarket super)
        {
            Console.Clear();
            if(carros.Count == 0)
                Console.WriteLine("No hi ha ningú comprant al supermercat");
            else if(super.ActiveLines == 0)
                Console.WriteLine("No hi ha cap línia activa");
            else
            {
                Random r = new();
                ShoppingCart carro = carros.ElementAt(r.Next(0, carros.Count)).Value;
                int count = SuperMarket.MAX_LINES;
                int activeCount = r.Next(1, super.ActiveLines);
                while (activeCount != 0)
                {
                    if (super.GetCheckOutLine(count) is not null) activeCount--;
                    count--;
                }
                
                CheckOutLine line = super.GetCheckOutLine(count);
                line.CheckIn(carro);
                carros.Remove(carro.Customer);
                Console.WriteLine($"El client {carro.Customer.FullName} ha entrat a la línia {line.Number}");
                Console.WriteLine("Informació de la cua:");
                Console.WriteLine(line);
            }
            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
        }

        // OPCIO 4 - CHECK OUT D'UNA CUA TRIADA PER L'USUARI
        /// <summary>
        /// Es demana per teclat una cua de les actives (1..ActiveLines)
        /// i es fa el checkout del ShoppingCart que toqui
        /// Si no hi ha cap carro a la cua triada, es dona un missatge
        /// </summary>
        /// <param name="super">necessari per fer el checkout</param>
        /// <returns>true si s'ha pogut fer el checkout. False en cas contrari</returns>

        public static bool DoCheckOut(SuperMarket super)
        {
            Console.Clear();
            bool fet=true;
            Console.Clear();
            Console.Write("Diga'm de quina línia vols fer checkout: ");
            int queue = -1;
            try
            {
                queue = Convert.ToInt32(Console.ReadLine());
                if (queue == -1)
                    fet = false;
                else if (super.GetCheckOutLine(queue) is null)
                {
                    Console.WriteLine("La caixa no és oberta");
                    fet = false;
                }
                else if (!super.CheckOut(line: queue))
                {
                    Console.WriteLine($"No hi ha ningú a la línia {queue}");
                    fet = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                fet = false;
            }

            return fet;
        }
        /// <summary>
        /// En cas que hi hagin cues disponibles per obrir, s'obre la 
        /// següent linia disponible
        /// </summary>
        /// <param name="super"></param>
        /// <returns>true si s'ha pogut obrir la cua</returns>
        // OPCIO 5 : Obrir la següent cua disponible (si n'hi ha)
        public static bool DoOpenCua(SuperMarket super)
        {
            Console.Clear();
            bool fet = true;
            if (super.ActiveLines == SuperMarket.MAX_LINES)
            {
                Console.WriteLine("Totes les cues són ja obertes");
                fet = false;
            }
            else
            {
                CheckOutLine? toOpenLine;
                int i = 0;
                do
                {
                    i++;
                    toOpenLine = super.GetCheckOutLine(i);
                } while (toOpenLine is not null);
                super.OpenCheckOutLine(i);
                toOpenLine = super.GetCheckOutLine(i);
                Console.WriteLine($"S'ha obert la línia següent: ");
                Console.WriteLine(toOpenLine);
            }
            MsgNextScreen("PREM UNA TECLA PER ANAR AL MENÚ PRINCIPAL");
            return fet;
        }

        //OPCIO 6 : Llistar les cues actives
        /// <summary>
        /// Es llisten totes les cues actives des de la 1 fins a ActiveLines.
        /// Apretar una tecla després de cada cua activa
        /// </summary>
        /// <param name="super"></param>
        public static void DoInfoCues(SuperMarket super)
        {
            Console.Clear();
            for (int i = 0; i < SuperMarket.MAX_LINES; i++)
            {
                var line = super.GetCheckOutLine(i);
                if (line is not null)
                {
                    Console.WriteLine($"{line}\n");
                    MsgNextScreen("PREM PER A VEURE LA SEGÜENT CUA\n");
                }
            }
            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");

        }


        // OPCIO 7 - Mostrem tots els carros de la compra que estan voltant
        // pel super però encara no han anat a cap cua per pagar
        /// <summary>
        /// Es mostren tots els carros que no estan en cap cua.
        /// Cal apretar una tecla després de cada carro
        /// </summary>
        /// <param name="carros"></param>
        public static void DoClientsComprant(Dictionary<Customer,ShoppingCart> carros)
        {
            Console.Clear();
            Console.WriteLine("CARROS VOLTANT PEL SUPER (PENDENTS D'ANAR A PAGAR): ");
            foreach (var carro in carros)
            {
                Console.WriteLine($"{carro}\n");
                MsgNextScreen("Prem una tecla per a veure el següent carro");
            }
            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");

        }

        //OPCIO 8 : LListat de clients per rating
        /// <summary>
        /// Cal llistar tots els clients de més a menys rating
        /// Per poder veure bé el llistat, primer heu de fer uns quants
        /// checkouts i un cop fets, fer el llistat. Aleshores els
        /// clients que han comprat tindran ratings diferents de 0
        /// Jo he fet una sentencia linq per solucionar aquest apartat
        /// </summary>
        /// <param name="super"></param>
        public static void DoListCustomers(SuperMarket super)
        {

            Console.Clear();
            var orderedCustomers = super.Customers.Values.OrderBy(x => x.GetRating).ToList();
            orderedCustomers.Sort();
            foreach (var customer in orderedCustomers)
            {
                Console.WriteLine(customer);
            }
            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");

        }

        // OPCIO 9
        /// <summary>
        /// Llistar de menys a més estoc, tots els articles del magatzem
        /// </summary>
        /// <param name="header">Text de capçalera del llistat</param>
        /// <param name="items">articles que ja vindran preparats en la ordenació desitjada</param>
        public static void DoListArticlesByStock(String header, HashSet<Item> items)
        {
            Console.Clear();
            Console.WriteLine(header);
            

            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
        }

        // OPCIO A : Tancar cua. Només si no hi ha cap client
        /// <summary>
        /// Començant per la última cua disponible, tanca la primera que trobi sense
        /// cap carro encuat. (primer mirem la número "ActiveLines" després ActiveLines-1 ...
        /// Fins trobar una que estigui buida. La que trobem la eliminarem
        /// Cal afegir la propietat Empty a la classe ChecOutLine i  a la classe SuperMarket:
        /// el mètode public static bool RemoveQueue(Supermarket super, int lineToRemove)
        /// que elimina la cua amb número = lineToRemove i retorna true en cas que l'hagi 
        /// pogut eliminar (perquè no hi ha cap carro pendent de pagament)
        /// </summary>
        /// <param name="super"></param>
        public static void DoCloseQueue(SuperMarket super)
        {
            Console.Clear();
             


            MsgNextScreen("PREM UNA TECLA PER CONTINUAR");
        }

      
        public static void MsgNextScreen(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }
       
      
    }
}


