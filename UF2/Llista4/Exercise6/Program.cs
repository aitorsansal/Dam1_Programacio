namespace Exercise6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] winPool = Results(14), currentPool = Results(14);
            Console.WriteLine(CheckPrize(currentPool, winPool));
        }

        public static char[] Results(int numberOfGames)
        {
            int localGoals, visitorGoals;
            Random r = new Random();
            int b = 0;
            char[] results = new char[numberOfGames];
            for (int i = 0; i < numberOfGames; i++)
            {
                localGoals = r.Next(0, 50);
                visitorGoals = r.Next(0, 50);
                if (localGoals == visitorGoals) results[b] = 'X';
                else if (localGoals < visitorGoals) results[b] += '2';
                else results[b] += '1';
                b++;
            }
            return results;
        }

        public static int CheckPrize(char[] target, char[] win)
        {
            int correct = 0;
            int incrrect = 0;
            int i = 0;
            //for (int i = 0; i < win.Length; i++)
            while(++i < win.Length && incrrect < 4)
            {
                Console.WriteLine(i);
                if (win[i] == target[i]) correct++;
                else incrrect++;
            }
            return incrrect >= 4 ? 0: correct;
        }
    }
}
