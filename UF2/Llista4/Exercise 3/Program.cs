namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WriteRandomWord(5));
        }

        static string WriteRandomWord(int letters)
        {
            char[] USABLE_CHARS =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };
            string resultString = "";
            Random r = new Random();
            for (int i = 0; i < letters; i++)
            {
                resultString += USABLE_CHARS[r.Next(0, USABLE_CHARS.Length)];
            }
            return resultString;
        }
    }
}
