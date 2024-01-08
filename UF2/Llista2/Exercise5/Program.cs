namespace Exercise5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadDate());
        }

        static string ReadDate()
        {
            int date = 0;
            int year = 0, month = 0, day = 0;
            bool correct = false;
            while (!correct)
            {
                try
                {
                    Console.Write("Write a date in the following format: ddmmyyyy → ");
                    date = Convert.ToInt32(Console.ReadLine());
                    if (date.ToString().Length > 8) throw new Exception("Not in correct format");
                    year = date % 10000;
                    int aux = date / 10000;
                    month = aux % 100;
                    day = aux / 100;
                    if (!CheckForCorrectDate(day, month, year))
                        throw new Exception("The date entered is not in the correct format");
                    correct = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return $"The date {day:00}/{month:00}/{year:0000} is in the correct format";
        }

        static bool CheckForCorrectDate(int day, int month, int year)
        {
            bool correctTime = false;
            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    correctTime = day is > 0 and <= 31;
                    break;
                case 2:
                    correctTime = IsLeapYear(year) ? day is > 0 and <= 29 : day is > 0 and <= 28;
                    break;
                case 4: case 6: case 9: case 11:
                    correctTime = day is > 0 and <= 30;
                    break;
                default:
                    throw new Exception("Month does not exist");
                    break;
            }
            return correctTime;
        }

        static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
    }
}
