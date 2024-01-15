namespace Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WriteRandomWordWithList(5));
        }

        static string WriteRandomWord(int letters)
        {
            char[] usableChars = {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };
            Random r = new Random();
            string resultString = "";
            for (int i = 0; i < letters; i++)
            {
                resultString += usableChars[r.Next(0, usableChars.Length)];
            }

            return resultString;
        }

        static string WriteRandomWordWithList(int letters)
        {
            List<char> usableChars = new();
            for (int i = 65; i < 91; i++)
            {
                usableChars.Add((char)i);
            }

            for (int i = 97; i < 123; i++)
            {
                usableChars.Add((char)i);
            }
            string resultString = "";
            Random r = new Random();
            for (int i = 0; i < letters; i++)
            {
                resultString += usableChars[r.Next(0, usableChars.Count)];
            }
            return resultString;
        }
    }
}
