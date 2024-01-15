namespace Exercise_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_GAMES = 10;
            var results = Results(NUMBER_OF_GAMES);
            Console.WriteLine("Results of the games: ");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        static string[] Results(int numberOfGames)
        {
            int localGoals, visitorGoals;
            Random r = new Random();
            string[] results = new string[numberOfGames];
            for (int i = 0; i < numberOfGames; i++)
            {
                localGoals = r.Next(0, 50);
                visitorGoals = r.Next(0, 50);
                if (localGoals == visitorGoals) results[i] = "X";
                else if (localGoals < visitorGoals) results[i] = "2";
                else results[i] = "1";
            }
            return results;
        }
    }
}
