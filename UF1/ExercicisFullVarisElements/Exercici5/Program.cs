namespace Exercici5
{
    internal class Program
    {
        private const string FILE_NAME = "atur.txt";
        static void Main(string[] args)
        {
            bool rising = false;
            int month = 1;
            int year = 1990;
            int atur1, atur2;
            bool found = false;
            StreamReader sr = new StreamReader(FILE_NAME);
            string? line = sr.ReadLine();
            if (line == null) Console.WriteLine("Empty File");
            else
            {
                atur1 = Convert.ToInt32(line);
                line = sr.ReadLine();
                if (line == null) Console.WriteLine("Missing 1 element");
                else
                {
                    while (!found && line != null)
                    {
                        atur2 = Convert.ToInt32(line);
                    }
                }
            }
        }
    }
}