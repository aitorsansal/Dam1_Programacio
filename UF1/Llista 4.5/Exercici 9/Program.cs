namespace Exercici_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int correct = 0;
            bool inGame = true;
            Console.Write("Escriu el primer número: ");
            int enteredNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int sumOfAll = enteredNumber;
            while (inGame)
            {
                Console.WriteLine("Escriu la suma de tots el números que hagis entrat amb anterioritat: ↓");
                enteredNumber = Convert.ToInt32(Console.ReadLine());
                if (enteredNumber != sumOfAll) inGame = false;
                sumOfAll += enteredNumber;
                correct++;
            }

            Console.WriteLine($"You lost after getting {correct} correct.");
        }
    }
}