namespace Dau_I_Moneda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingValue = 100;
            int endValue = startingValue;
            int coin, dice;
            var rand = new Random();

            dice = rand.Next(1,7);
            coin = rand.Next(2); // 0 cara, 1 creu

            switch (coin)
            {
                case 0: //cara
                    if (dice == 6)
                        endValue += 10;
                    else if (dice % 2 == 0) //es parell
                        endValue *= 2;
                    break;
                case 1:
                    if (dice == 6)
                        endValue = 0;
                    else if (dice % 2 != 0) //es senar
                        endValue /= 2;
                    break;
            }
            Console.WriteLine($"Dice: {dice}, coin {coin}");
            Console.Write($"Starting quantity: {startingValue}, ending quantity: {endValue}");
        }
    }
}