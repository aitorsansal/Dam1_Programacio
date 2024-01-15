namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_TABLE_LENGTH = 500;
            Random r = new();
            int valueToFind = r.Next(0, 101);
            var data = GenerateRandomTable(MAX_TABLE_LENGTH);
            var indexes = IndexesFound(data, valueToFind);
            WriteValues(indexes, valueToFind);
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

        public static int[] IndexesFound(int[] table, int value)
        {
            int i = 0, iBase = 0;
            int[] tempIndexes = new int[table.Length];
            while (i < table.Length)
            {
                if (table[i] == value)
                {
                    tempIndexes[iBase] = i;
                    iBase++;
                }

                i++;
            }

            int[] indexes = new int[iBase];
            for (int j = 0; j < iBase; j++)
            {
                indexes[j] = tempIndexes[j];
            }

            return indexes;
        }
        //Exercici 3
        public static void WriteValues(int[] data, int value)
        {
            Console.WriteLine($"The value {value} has been found in the following indexes: ");
            foreach (var index in data)
            {
                Console.WriteLine(index);
            }
        }
    }
}