namespace Exercici2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int dice1 = r.Next(1,7);
            int dice2 = r.Next(1,7);
            int dice3 = r.Next(1,7);
            int timesThrown = 3;
            bool conditionFound = dice2 == dice1 + dice3;
            Console.WriteLine($"{dice1} {dice2} {dice3}");
            while (!conditionFound)
            {
                dice1 = dice2;
                dice2 = dice3;
                dice3 = r.Next(1,7);
                timesThrown++;
                Console.WriteLine($"{dice1} {dice2} {dice3}");
                conditionFound = dice2 == dice1 + dice3;
            }
            Console.WriteLine($"Condition met in {timesThrown} throws.");
        }
    }
}