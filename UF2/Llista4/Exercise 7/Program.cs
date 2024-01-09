namespace Exercise_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var results = GenerateMatchResults(14);
            for (int i = 0; i < results.GetLength(0); i++)
            {
                string result = "";
                if (results[i, 0] == results[i, 1]) result = "Tie";
                else if (results[i, 0] < results[i, 1]) result = "Visitor Wins";
                else result = "Local Wins";
                Console.WriteLine($"Match #{i+1}:\t Local Team: {results[i, 0]}\t /\t Visitor Team: {results[i, 1]}\t /\t {result}");
            }
        }

        public static int[,] GenerateMatchResults(int quantityOfGames)
        {
            int[,] results = new int[quantityOfGames, 2];
            Random r = new();
            for (int i = 0; i < quantityOfGames; i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    results[i, j] = r.Next(0, 20);
                }
            }

            return results;
        }
    }
}
