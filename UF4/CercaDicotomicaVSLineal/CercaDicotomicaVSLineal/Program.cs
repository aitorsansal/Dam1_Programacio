// See https://aka.ms/new-console-template for more information

internal class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new("grafica.csv");
        for (int i = 1000; i <= 100000; i+=500)
        {
            int[] table = new int[i];
            for (int j = 1; j <= i; j++)
            {
                table[j-1] = j * 2;
            }
            Random r = new Random();
            double dicoCompleteCost = 0, linealCompleteCost = 0;
            for (int j = 0; j < i; j++)
            {
                int toSearch = r.Next(1, i * 2+1);
                dicoCompleteCost += DicotomicSearch(toSearch, table);
                linealCompleteCost += LinealSearch(toSearch, table);
            }

            double avgDicotomic = dicoCompleteCost / i, avgLineal = linealCompleteCost / i;
                sw.WriteLine($"{i};{avgLineal};{avgDicotomic}");
                Console.WriteLine(i);
        }
        sw.Close();
    }
    private static int LinealSearch(int toSearch, int[] table)
    {
        bool found = false;
        int count = 0;
        for (int i = 0; i < table.Length && !found; i++)
        {
            found = table[i] >= toSearch;
            count++;
        }
        return count;
    }

    private static int DicotomicSearch(int toSearch, int[] table)
    {
        int left = 0, right = table.Length-1;
        bool found = false;
        int count = 0;
        while (!found && left+1 != right)
        {
            int toDetect = left + ((right - left) / 2);
            if (table[toDetect] == toSearch) found = true;
            else if (table[toDetect] < toSearch) left = toDetect;
            else right = toDetect;
            count++;
        }
        return count;
    }
}