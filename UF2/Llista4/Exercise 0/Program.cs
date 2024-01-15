namespace Exercise_0
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int MAX_TIMES = 5;
            var data = GenerateRandomTable(500);
            for (int i = 0; i < MAX_TIMES; i++)
            {
                Console.Write("Write a number to search in the array: ");
                try
                {
                    var numberToSearch = Convert.ToInt32(Console.ReadLine());
                    var location = Search(data, numberToSearch);
                    Console.WriteLine(location != -1
                        ? $"Found the number {numberToSearch} in position {location}"
                        : $"The number {numberToSearch} is not in the table");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }
        }

        public static int[] GenerateRandomTable(int max)
        {
            Random r = new Random();
            int[] table = new int[max];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = r.Next(0, 101);
            }
            return table;
        }

        public static int Search(int[] table, int value)
        {
            bool found = false;
            int location = -1;
            int i = 0;
            while (!found && i < table.Length)
            {
                found = table[i] == value;
                if (!found) i++;
            }

            if (found) location = i;
            return location;
        }
    }
}
