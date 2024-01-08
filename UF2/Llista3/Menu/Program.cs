using System.Linq.Expressions;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                ShowOptions();
                tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.D0:
                        MsgNextScreen("PRESS ANY KEY TO EXIT");
                        break;
                    case ConsoleKey.D1:
                        DoLeap();
                        break;
                    case ConsoleKey.D2:
                        DoOddOrEven();
                        break;
                    case ConsoleKey.D3:
                        DoTry2ReadValidTimeStamp();
                        break;
                    case ConsoleKey.D4:
                        DoReadAValidTimeStamp();
                        break;
                    case ConsoleKey.D5:
                        DoTry2EnterValidDate();
                        break;
                    case ConsoleKey.D6:
                        DoEnterValidDate();
                        break;
                    case ConsoleKey.D7:
                        DoMCD();
                        break;
                    case ConsoleKey.D8:
                        DoGenerateHulukuluBulukulu();
                        break;
                    case ConsoleKey.D9:
                        DoSumOfDigits();
                        break;
                    case ConsoleKey.A:
                        AverageOfDataFile();
                        break;
                    default:
                        MsgNextScreen("Error. Press any key to return to the menu...");
                        break;

                }
            } while (tecla.Key != ConsoleKey.D0);
        }
        /// <summary>
        /// Shows a message and waits for a key to be pressed.
        /// </summary>
        /// <param name="msg"></param>
        private static void MsgNextScreen(string msg = "Press any key to go to the main menu")
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }
        
        /// <summary>
        /// Checks if the entered year is a leap year or not
        /// </summary>
        static void DoLeap()
        {
            int year;
            Console.Write("Enter a year →");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(IsLeapYear(year) ? $"{year} is a leap year" : $"{year} is not a leap year");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen();
            }
        }
        /// <summary>
        /// Calculations for checking if it's a leap year
        /// </summary>
        /// <param name="year">the year to check</param>
        /// <returns>True if it's a leap year</returns>
        static bool IsLeapYear(int year) { return year % 4 == 0 && year % 100 != 0 || year % 400 == 0; }
        /// <summary>
        /// Asks for a number to check if it's odd or even
        /// </summary>
        static void DoOddOrEven()
        {
            int number;
            Console.Write("Enter a number to check if it's odd or even →");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(CheckForOddOrEven(number));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                MsgNextScreen();
            }
        }
        /// <summary>
        /// Calculations to check if the number is odd or even
        /// </summary>
        /// <param name="number">the number to check</param>
        /// <returns>string + if it's odd or even</returns>
        private static string? CheckForOddOrEven(int number)
        {
            return number % 2 == 0 ? $"{number} is an odd number" : $"{number} is an even number";
        }
        /// <summary>
        /// Checks for a valid time one time
        /// </summary>
        static void DoTry2ReadValidTimeStamp()
        {
            int time;
            int m, h, s, aux;
            Console.Write("Enter a time in format hhmmss →");
            try
            {
                time = Convert.ToInt32(Console.ReadLine());
                s = time % 100;
                aux = time / 100;
                h = aux / 100;
                m = aux % 100;
                Console.WriteLine(ValidTime(h, m, s)
                    ? $"{h:00}{m:00}{s:00} is a valid timestamp."
                    : $"{h:00}{m:00}{s:00} is not a valid timestamp.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen();
            }
        }
        /// <summary>
        /// Calculations to detect if it's a valid time or not
        /// </summary>
        /// <param name="h">hours</param>
        /// <param name="m">minutes</param>
        /// <param name="s">seconds</param>
        /// <returns>true if it's a valid time</returns>
        private static bool ValidTime(int h, int m, int s) { return h is >= 0 and <= 23 && m is >= 0 and <= 59 && s is >= 0 and <= 59; }
        
        static void DoReadAValidTimeStamp()
        {
            string time = ReadTime();
            Console.WriteLine($"{time} is a valid timestamp for sure!");
            MsgNextScreen("Press a key to go to the main menu");
        }
        /// <summary>
        /// Checks for a valid time until it results true
        /// </summary>
        /// <returns>Valid time in correct format hh:mm:ss</returns>
        /// <exception cref="Exception"></exception>
        private static string ReadTime()
        {
            int time = 0;
            int h = 0, m = 0, s = 0;
            int aux;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.Write("Enter a time in format hhmmss →");
                    time = Convert.ToInt32(Console.ReadLine());
                    s = time % 100;
                    aux = time / 100;
                    h = aux / 100;
                    m = aux % 100;
                    if (!ValidTime(h, m, s)) throw new Exception($"{h:00}{m:00}{s:00} is not a valid timestamp");
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Retry ...");
                }
            }

            return $"{h:00}{m:00}{s:00}";
        }
        /// <summary>
        /// Tries to read a valid date one time
        /// </summary>
        static void DoTry2EnterValidDate()
        {
            int date;
            int year, month, day, aux;
            Console.Write("Enter a date in format ddmmyyyy →");
            try
            {
                date = Convert.ToInt32(Console.ReadLine());
                year = date % 10000;
                aux = date / 10000;
                month = aux % 100;
                day = aux / 100;
                Console.WriteLine(CheckForCorrectDate(day, month, year)
                    ? $"{day:00}{month:00}{year:0000} is a valid date"
                    : $"{day:00}{month:00}{year:0000} is not a valid date");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

                MsgNextScreen();
            }
        }
        /// <summary>
        /// Checks if the date entered is a correct date or not
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns>True if it's a valid date</returns>
        /// <exception cref="Exception"></exception>
        static bool CheckForCorrectDate(int day, int month, int year)
        {
            bool correctTime;
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
        
        static void DoEnterValidDate()
        {
            string date = ReadDate();
            Console.WriteLine($"{date} is a valid date for sure!!");
            MsgNextScreen();
        }
        /// <summary>
        /// Asks for a date until its valid
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string ReadDate()
        {
            int date;
            int year = 0, month = 0, day = 0, aux;
            bool valid = false;
            Console.Write("Enter a date in format ddmmyyyy →");
            while (!valid)
            {
                try
                {
                    date = Convert.ToInt32(Console.ReadLine());
                    year = date % 10000;
                    aux = date / 10000;
                    month = aux % 100;
                    day = aux / 100;
                    if (!CheckForCorrectDate(day, month, year))
                        throw new Exception($"{day:00}{month:00}{year:0000} is not a valid time stamp!!!");
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Retry ...");
                }
            }

            return $"{day:00}{month:00}{year:00}";
        }
        
        static void DoMCD()
        {
            int[] mcd = ReadValues();
            Console.WriteLine($"The MCD of the values {mcd[0]} and {mcd[1]} is {mcd[2]}");
            MsgNextScreen("Press any key to return to the menu");
        }
        /// <summary>
        /// Reads the values for 2 numbers and calculates the mcd
        /// </summary>
        /// <returns>Array with 3 values: 1st number, 2nd number and mcd</returns>
        private static int[] ReadValues()
        {
            int[] values = new int[3];
            try
            {
                Console.Write("Enter the first integer positive value: ");
                values[0] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second positive integer value: ");
                values[1] = Convert.ToInt32(Console.ReadLine());
                int a = Math.Max(values[0], values[1]);
                int b = Math.Min(values[0], values[1]);
                int res;
                do
                {
                    res = b;
                    b = a % b;
                    a = res;
                } while (b != 0);

                values[2] = res;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return values;
        }
        /// <summary>
        /// Asks for two years until the second one is higher than the first one
        /// </summary>
        static void DoGenerateHulukuluBulukulu()
        {
            try
            {
                Console.Write("Enter the first year: ");
                int firstYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second year, being greater than the first: ");
                int secondYear = Convert.ToInt32(Console.ReadLine());
                while (secondYear <= firstYear)
                {
                    Console.Write("Reenter the second year. It wasn't greater than the first one!!! →");
                    secondYear = Convert.ToInt32(Console.ReadLine());
                }

                for (int i = firstYear; i <= secondYear; i++)
                {
                    if (IsBulukuluYear(i) && IsHulukuluYear(i))
                    {
                        Console.WriteLine(i);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                MsgNextScreen();
            }
        }
        /// <summary>
        /// Does the calculations to check if it's a Hulukulu year
        /// </summary>
        /// <param name="year">the year to check</param>
        /// <returns>true if it's a Bulukulu year</returns>
        public static bool IsHulukuluYear(int year) { return year % 15 == 0; }
        
        /// <summary>
        /// Does the calculations to check if it's a Bulukulu year
        /// </summary>
        /// <param name="year">the year to check</param>
        /// <returns>true if it's a Bulukulu year</returns>
        public static bool IsBulukuluYear(int year) { return IsLeapYear(year) && year % 55 == 0; }
        
        static void DoSumOfDigits()
        {
            Console.WriteLine("Enter an integer greater than 0 to sum all the digits → ");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                int sum = SumOfDigits(number);
                Console.WriteLine($"The sum of all the numbers of {number} is {sum}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                MsgNextScreen();
            }
        }
        /// <summary>
        /// Sums all the digits from a number
        /// </summary>
        /// <param name="number">The number to sum all the digits</param>
        /// <returns>The sum of the digits</returns>
        static int SumOfDigits(int number)
        {
            int aux = number;
            int sum = 0;
            while (aux > 0)
            {
                sum += aux % 10;
                aux /= 10;
            }

            return sum;
        }
        /// <summary>
        /// Asks for a name file and sums all the digits from that one.
        /// (The file should be in the correct format)
        /// </summary>
        static void AverageOfDataFile()
        {
            Console.WriteLine("Enter the name of the file without extension →");
            string name = Console.ReadLine() + ".txt";
            int sum = 0;
            StreamReader sr;
            try
            {
                sr = new StreamReader(name);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sum += Convert.ToInt32(line);
                }

                Console.WriteLine($"The sum of all digits from the file {name} is {sum}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MsgNextScreen();
            }
        }
        /// <summary>
        /// Shows the options of the menu
        /// </summary>
        static void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine("1 - Check for a leap year");
            Console.WriteLine("2 - Check for an even or odd number");
            Console.WriteLine("3 - Try reading a valid time stamp");
            Console.WriteLine("4 - Read a valid time stamp");
            Console.WriteLine("5 - Try reading a valid date");
            Console.WriteLine("6 - Read a valid date");
            Console.WriteLine("7 - Do the MCD of two numbers");
            Console.WriteLine("8 - Generate all Hulukulu and Bulukulu years in between");
            Console.WriteLine("9 - Do the sum of digits");
            Console.WriteLine("A - Get the average from a data file");
            Console.WriteLine("0 - Exit from program");
        }
    }
}
