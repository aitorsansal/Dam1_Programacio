namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int learpYear;
            Console.Write("Enter a year: ");
            learpYear = ReadLearpYear();
            Console.WriteLine(learpYear + " is a learp year for sure!");
        }

        private static int ReadLearpYear()
        {
            int year = 0;
            bool correct = false;
            while (!correct)
            {
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                    IsLearpYear(year);
                    correct = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return year;
        }

        private static bool IsLearpYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
    }
}
