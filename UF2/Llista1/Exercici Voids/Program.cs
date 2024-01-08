namespace Exercici_Voids
{
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thurday,
        Friday,
        Saturday,
        Sunday
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReturnUpperLetter('a'));            
        }

        static string IsOdd(int number)
        {
            return number % 2 == 0 ? "odd" : "not odd";
        }

        static double HourToSeconds(double hours, double minutes, double seconds)
        {
            return hours * 360 + minutes * 60 + seconds;
        }

        static string RandomWeekDay()
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Fiday", "Saturday", "Sunday" };
            Random r = new Random();
            return days[r.Next(days.Length)];
        }

        static bool DetectIfWorkingDay(WeekDays day)
        {
            return day != WeekDays.Saturday && day != WeekDays.Sunday;
        }

        static bool TimeValidation(int time)
        {
            int temp = time;
            int seconds = temp % 100;
            temp /= 100;
            int minutes = temp % 100;
            temp /= 100;
            int hours = temp;
            return seconds < 60 && minutes < 60 && hours < 24;
        }

        static int Add1Second(int time)
        {
            int temp = time;
            int seconds = temp % 100;
            temp /= 100;
            int minutes = temp % 100;
            temp /= 100;
            int hours = temp;
            seconds++;
            if (seconds >= 60)
            {
                seconds -= 60;
                minutes++;
                if (minutes >= 60)
                {
                    minutes -= 60;
                    hours++;
                    if (hours > 23)
                        hours = 0;
                }
            }

            return Convert.ToInt32($"{hours:00}{minutes:00}{seconds:00}");
        }
        static int AddSeconds(int time, int secondsToAdd)
        {
            int temp = time;
            int seconds = temp % 100;
            temp /= 100;
            int minutes = temp % 100;
            temp /= 100;
            int hours = temp;
            seconds += secondsToAdd;
            int overMinutes = seconds / 60;
            Console.WriteLine(overMinutes);
            if (seconds >= 60)
            {
                seconds -= 60 * overMinutes;
                minutes += overMinutes;
                if (minutes >= 60)
                {
                    int overHours = minutes / 60;
                    minutes -= 60 * overHours;
                    hours += overHours;
                }
            }

            return Convert.ToInt32($"{hours:00}{minutes:00}{seconds:00}");
        }

        static int AddSeconds2ndType(int time, int secondsToAdd)
        {
            for (int i = 0; i < secondsToAdd; i++)
            {
                time = Add1Second(time);
            }

            return time;
        }

        static int CalculateAverageOfFile(string filename)
        {
            StreamReader sr = new(filename);
            string? line = sr.ReadLine();
            int total = 0, count = 0;
            while (line != null)
            {
                total += Convert.ToInt32(line);
                count++;
                line = sr.ReadLine();
            }
            sr.Close();
            return (count > 0 ? total/count : 0);
        }

        static char ReturnUpperLetter(char letter)
        {
            return letter switch
            {
                >= 'a' and <= 'z' => (char)(letter - 32),
                >= 'A' and <= 'Z' => letter,
                _ => '?'
            };
        }

        static double CalculateMark(double examMark, double practiseMark, double attendance)
        {
            bool isCorrect = examMark is >= 0 and <= 10 && practiseMark is >= 0 and <= 10 && attendance is >= 0 and <= 100;
            var finalMark = (isCorrect ? examMark * .2 + practiseMark * .7 + attendance / 100 : -1);
            return finalMark;
        }
    }
}
