namespace Exercise_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int MAX_TABLE_LENGTH = 500;
            Random r = new();
            int valueToFind = r.Next(0,101);
            var data = GenerateRandomTable(MAX_TABLE_LENGTH);
            int timesFound = CheckForNumberOfEquals(data, valueToFind);
            Console.WriteLine(timesFound > 0
                ? $"The value {valueToFind} has been found a total of {timesFound} in the array of length {MAX_TABLE_LENGTH}."
                : $"The value {valueToFind} cannot be found in the array");
        }

        public static int[] GenerateRandomTable(int max)
        {
            Random r = new();
            int[] table = new int[max];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = r.Next(0, 101);
            }
            return table;
        }

        public static int CheckForNumberOfEquals(int[] table, int value)
        {
            int foundTimes = 0;
            for(int i = 0; i < table.Length; i++)
            {
                if(table[i] == value) foundTimes++;
            }
            return foundTimes;
        }
    }
}
