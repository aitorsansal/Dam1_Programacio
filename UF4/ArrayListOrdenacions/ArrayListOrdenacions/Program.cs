// See https://aka.ms/new-console-template for more information

using TL;

internal class Program
{
    const string FILE_NAME = "Equips.txt";
    public static void Main(string[] args)
    {
        StreamReader sr = new(FILE_NAME);
        String? line = sr.ReadLine();
        TaulaLlistaGenerica<Equip> taulaLListaEquips = new();

        while (line != null)
        {
            string[] splitedData = line.Split(";");
            taulaLListaEquips.Afegeix(new Equip(splitedData[0], Convert.ToInt32(splitedData[1]),
                Convert.ToInt32(splitedData[2]), Convert.ToInt32(splitedData[3])));
            line = sr.ReadLine();
        }

        ConsoleKey key;
        do
        {
            CreateMenu();
            key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1: case ConsoleKey.NumPad1:
                    taulaLListaEquips.Sort();
                    break;
                case ConsoleKey.D2: case ConsoleKey.NumPad2:
                    taulaLListaEquips.Sort(new Equip.ComparadorPerClassificacio());
                    break;
                case ConsoleKey.D3: case ConsoleKey.NumPad3:
                    taulaLListaEquips.Sort(new Equip.ComparadorPerGolsMarcats());
                    break;
                case ConsoleKey.D4: case ConsoleKey.NumPad4:
                    taulaLListaEquips.Sort(new Equip.ComparadorPerGolsEncaixats());
                    break;
            }
            PrintValues(taulaLListaEquips);
            NextMSGScreen();
        } while (key != ConsoleKey.D0 && key != ConsoleKey.NumPad0);
    }


    static void CreateMenu()
    {
        Console.WriteLine("1 - Llistat alfabètic");
        Console.WriteLine("2 - Llistat per classificació");
        Console.WriteLine("3 - Llistat per gols marcats");
        Console.WriteLine("4 - Llistat per gols encaixats");
        Console.WriteLine("0 - Sortir");
    }
    static void NextMSGScreen(string msg = "Prem alguna tecla per continuar")
    {
        Console.WriteLine(msg);
        Console.ReadKey();
        Console.WriteLine();
    }

    static void PrintValues(TaulaLlistaGenerica<Equip> tL)
    {
        for (int i = 0; i < tL.NElements; i++)
        {
            Console.WriteLine(tL[i]);  
        }
    }
}