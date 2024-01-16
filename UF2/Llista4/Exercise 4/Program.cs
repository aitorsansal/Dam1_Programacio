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
            Random r = new Random();
            StringBuilder sb = new();
            for (int i = 0; i < letters; i++)
            {
                var toAdd = r.Next(0,2) == 0 ? 65 : 97;
                sb.Append((char)(toAdd + r.Next(0,26)));
            }
            return sb.ToString();
        }
    }
}
