namespace Exercici3
{
    internal class Program
    {
        private const string FILE_NAME = "codes.txt";
        private const string SOS_CODE = "... --- ...";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(FILE_NAME);
            string? code1 = sr.ReadLine();
            string? code2 = sr.ReadLine();
            int counted = 1;
            Console.WriteLine($"{counted} => {code1} / {code2}");

            bool found = code1 == SOS_CODE && code2 == SOS_CODE;

            while (!found && code2 != null)
            {
                code1 = code2;
                code2 = sr.ReadLine();
                counted++;
                Console.WriteLine($"{counted} => {code1} / {code2}");

                found = code1 == SOS_CODE && code2 == SOS_CODE;
            }

            Console.WriteLine(found ? "The ship is in problems" : "Everything correct");
        }
    }
}