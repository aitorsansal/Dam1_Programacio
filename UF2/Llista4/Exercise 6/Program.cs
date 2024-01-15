namespace Exercise_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] winPool = Results(14), currentPool = Results(14);
            int quantityOfWins = CheckPrize(currentPool, winPool);
            Console.WriteLine(quantityOfWins == 0 ? 
                "You don't have any prize. Missed too much games." : 
                $"You have won a prize with the total of {quantityOfWins} wins!!!");
        }

        static char[] Results(int numberOfGames)
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

        static int CheckPrize(char[] target, char[] win)
        {
            int correct = 0;
            int incorrect = 0;
            int i = 0;
            while(i < win.Length)
            {
                if (win[i] == target[i]) correct++;
                else
                {
                    incorrect++;
                }

                i++;
            }
            return incorrect >= 4 ? 0: correct;
        }
    }
}
