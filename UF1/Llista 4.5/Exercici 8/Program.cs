namespace Exercici_8
{
    internal class Program
    {
        private const double PERCENT_RANGE_1 = .19;
        private const double PERCENT_RANGE_2 = .24;
        private const double PERCENT_RANGE_3 = .30;
        private const double PERCENT_RANGE_4 = .37;
        private const double PERCENT_RANGE_5 = .45;
        private const double PERCENT_RANGE_6 = .47;
        private const double TAXES_OVER_RANGE_1 = 2365.5;
        private const double TAXES_OVER_RANGE_2 = 1860;
        private const double TAXES_OVER_RANGE_3 = 4500;
        private const double TAXES_OVER_RANGE_4 = 9176;
        private const double TAXES_OVER_RANGE_5 = 108000;
        private const string FILE_NAME = "income.txt";
        static void Main(string[] args)
        {
            var taxes = CalculateTaxtesToPay();
            var range = CalculatePITRate();
            //Console.WriteLine($"Total income: {totalIncome}");
            Console.WriteLine($"The worker is in the tax range {range}.");
            //Console.WriteLine($"The worker has to pay {taxes}.");
        }

        static double CalculateTaxtesToPay()
        {
            double income = 0;
            StreamReader sr = new StreamReader(FILE_NAME);
            string? line = sr.ReadLine();
            while (line != null)
            {
                income += Convert.ToInt32(line);
                line = sr.ReadLine();
            }
            double taxesToPay;
            switch (income)
            {
                case <= 12450:
                    taxesToPay = income * PERCENT_RANGE_1;
                    break;
                case <= 20200:
                    income -= 12450;
                    taxesToPay = TAXES_OVER_RANGE_1 + income * PERCENT_RANGE_2;
                    break;
                case <= 35200:
                    income -= 20200;
                    taxesToPay = TAXES_OVER_RANGE_1 + TAXES_OVER_RANGE_2 + income * PERCENT_RANGE_3;
                    break;
                case <= 60000:
                    income -= 35200;
                    taxesToPay = TAXES_OVER_RANGE_1 + TAXES_OVER_RANGE_2 + TAXES_OVER_RANGE_3 + income * PERCENT_RANGE_4;
                    break;
                case <= 300000:
                    income -= 60000;
                    taxesToPay = TAXES_OVER_RANGE_1 + TAXES_OVER_RANGE_2 + TAXES_OVER_RANGE_3 + TAXES_OVER_RANGE_4 + income * PERCENT_RANGE_5;
                    break;
                default:
                    income -= 300000;
                    taxesToPay = TAXES_OVER_RANGE_1 + TAXES_OVER_RANGE_2 + TAXES_OVER_RANGE_3 + TAXES_OVER_RANGE_4 + TAXES_OVER_RANGE_5 + income * PERCENT_RANGE_6;
                    break;
            }

            return Math.Round(taxesToPay, 2);
        }
        static int CalculatePITRate()
        {
            double income = 0;
            StreamReader sr = new StreamReader(FILE_NAME);
            string? line = sr.ReadLine();
            bool found = false;
            int range = 0;
            while (!found && line != null)
            {
                income += Convert.ToInt32(line);
                if (income > 300000)
                    found = true;
                else 
                    line = sr.ReadLine();
            }

            if (!found)
            {
                range = income switch
                {
                    <= 12450 => 1,
                    <= 20200 => 2,
                    <= 35200 => 3,
                    <= 60000 => 4,
                    <= 300000 => 5,
                    _ => 6
                };
            }
            else 
                range = 6;

            return range;
        }
    }
}