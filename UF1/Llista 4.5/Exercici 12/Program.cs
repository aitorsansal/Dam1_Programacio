namespace Exercici_12
{
    internal class Program
    {
        private const string FILE_NAME = "years.txt";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(FILE_NAME);
            string? line = sr.ReadLine();
            int found = 0;
            while (line != null)
            {
                int year = Convert.ToInt32(line);
                if (IsHulukuYear(year) && IsBulukuluYear(year))
                {
                    Console.WriteLine(
                        $"The year {line} is a learp year, will have Huluku festival and Bukulu festival");
                    found++;
                }

                line = sr.ReadLine();
            }
            if (found == 0) { Console.WriteLine("No year meets all the conditions");}
            sr.Close();
        }


        static bool IsLearpYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        static bool IsHulukuYear(int year)
        {
            return year % 15 == 0;
        }

        static bool IsBulukuluYear(int year)
        {
            return IsLearpYear(year) && year % 55 == 0;
        }
    }
}