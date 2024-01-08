namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The hour that you entered {ReadHour()} is in a correct format");
        }

        static string ReadHour()
        {
            bool correct = false;
            int hour = 0;
            while (!correct)
            {
                try
                {
                    Console.Write("Write an hour in the format hhmmss: ");
                    hour = Convert.ToInt32(Console.ReadLine());
                    int s = hour % 100;
                    int aux = hour / 100;
                    int h = aux / 100;
                    int m = aux % 100;
                    if (!IsValidTime(h, m, s)) throw new Exception("The hour is not a correct time");
                    correct = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            return hour.ToString();
        }

        static bool IsValidTime(int hh, int mm, int ss)
        {
            return hh is >= 0 and <= 23 
                   && mm is >= 0 and <= 59 
                   && ss is >= 0 and <= 59;
        }

    }
}
