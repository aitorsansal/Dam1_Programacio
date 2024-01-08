namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadStringWithChar('a'));
        }

        static string ReadStringWithChar(char charToRead)
        {
            string toRead = "";
            bool correct = false;
            while (!correct)
            {
                try
                {
                    toRead = Console.ReadLine();
                    if (!toRead.Contains(charToRead))
                        throw new Exception($"The string doesn't contain the character {charToRead}");
                    correct = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return toRead;
        }
    }
}
