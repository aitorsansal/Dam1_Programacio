namespace Exercici3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggs1, eggs2, eggs3, eggs4;
            double percent1, percent2, percent3, percent4, mitjana, totalEggs;

            Console.Write("Entra els ous del primer trimestre: ");
            eggs1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra els ous del segon trimestre: ");
            eggs2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra els ous del tercer trimestre: ");
            eggs3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra els ous del quart trimestre: ");
            eggs4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(); //Blank space
            
            totalEggs = eggs1 + eggs2 + eggs3 + eggs4;
            mitjana = totalEggs / 4;

            Console.WriteLine($"La mitjana és de {mitjana} ous per trimestre");
            Console.WriteLine();//Blank space

            percent1 = Math.Round(eggs1 / totalEggs * 100);
            percent2 = Math.Round(eggs2 / totalEggs * 100);
            percent3 = Math.Round(eggs3 / totalEggs * 100);
            percent4 = Math.Round(eggs4 / totalEggs * 100);

            Console.Write($"El primer trimestre s'han prodït un {percent1}% del total. ");
            if (percent1 < 18)
                Console.WriteLine("ALARMA!!! Baixa producció");
            else
                Console.WriteLine();
            Console.Write($"El segon trimestre s'han prodït un {percent2}% del total. ");
            if (percent2 < 18)
                Console.WriteLine("ALARMA!!! Baixa producció");
            else
                Console.WriteLine();
            Console.Write($"El tercer trimestre s'han prodït un {percent3}% del total. ");
            if (percent3 < 18)
                Console.WriteLine("ALARMA!!! Baixa producció");
            else
                Console.WriteLine();
            Console.Write($"El quart trimestre s'han prodït un {percent4}% del total. ");
            if (percent4 < 18)
                Console.WriteLine("ALARMA!!! Baixa producció");
            else
                Console.WriteLine();
        }
    }
}