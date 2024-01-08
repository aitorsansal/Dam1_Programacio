namespace Exercici1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int no1, no2, no3, no4, addedNumbers;
            Random r = new Random();
            int randomNumber = r.Next(1000, 10000);
            int toUse = randomNumber;
            no1 = toUse % 10;
            toUse /= 10;
            no2 = toUse % 10;
            toUse /= 10;
            no3 = toUse % 10;
            toUse /= 10;
            no4 = toUse % 10;
            addedNumbers = no1 + no2 + no3 + no4;

            Console.WriteLine($"S'ha generat el número aleatori: {randomNumber}");
            Console.WriteLine($"{no4} + {no3} + {no2} + {no1} = {addedNumbers}");

        }
    }
}