namespace Exercise_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfGames = 10;
            var results = Results(numberOfGames);
            Console.WriteLine("Results of the games: ");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static string[] Results(int numberOfGames)
        {
            int localGoals, visitorGoals;
            Random r = new Random();
            int b = 0;
            string[] results = new string[numberOfGames];
            for (int i = 0; i < numberOfGames; i++)
            {
                localGoals = r.Next(0, 50);
                visitorGoals = r.Next(0, 50);
                if (localGoals == visitorGoals) results[b] = "X";
                else if (localGoals < visitorGoals) results[b] += "2";
                else results[b] += "1";
                b++;
            }
            return results;
        }
    }
}
