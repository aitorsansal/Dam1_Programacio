namespace Exercici2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int generatedNumber = r.Next(1, 11);
            int playerResponse;

            Console.Write("Intenta endevinar el número. Intent 1/2: ");
            playerResponse = Convert.ToInt32(Console.ReadLine());
            if (playerResponse == generatedNumber)
                Console.WriteLine("Molt bé, l'has encertat!");
            else
            {
                Console.WriteLine("Ho sento, no l'has encertat!");
                Console.Write("Intenta endevinar el número. Intent 2/2: ");
                playerResponse = Convert.ToInt32(Console.ReadLine());
                if (playerResponse == generatedNumber)
                    Console.WriteLine("Molt bé, l'has encertat!");
                else
                {
                    Console.WriteLine("Ho sento, no l'has encertat!");
                    Console.Write($"El número a endevinar era el {generatedNumber}!");
                }
            }
        }
    }
}