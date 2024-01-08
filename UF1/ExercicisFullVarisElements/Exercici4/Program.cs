namespace Exercici4
{
    internal class Program
    {
        private const string FILE_NAME = "extint.txt";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(FILE_NAME);
            string? line = sr.ReadLine();
            int tram1, tram2;
            bool found = false;
            if(line == null) Console.WriteLine("no info");
            else
            {
                tram1 = Convert.ToInt32(line);
                line = sr.ReadLine();
                if(line == null) Console.WriteLine("missing 1 element");
                else
                {
                    while (line != null && !found)
                    {
                        tram2 = Convert.ToInt32(line);
                        line = sr.ReadLine();
                        found = tram1 <= 10 && tram2 <= 10;
                        if (!found)
                        {
                            tram1 = tram2;
                        }
                    }

                    Console.WriteLine(found ? "It's extint" : "I'ts ok");
                }
            }
        }
    }
}