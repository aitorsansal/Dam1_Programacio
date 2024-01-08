namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool correct = false;
            int first = 1, second = 10;
            if (first > second) Console.WriteLine("The first value is higher than the second.");
            else
            {
                while (!correct)
                {
                    try
                    {
                        Console.WriteLine($"Write a value between {first} and {second}: ");
                        ReadIntBetween(first, second);
                        correct = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }

        static int ReadIntBetween(int first, int second)
        {
            if (first >= second) throw new Exception("The first value is higher than the second.");
            int readed = Convert.ToInt32(Console.ReadLine());
            if(readed < first || readed > second) throw new Exception($"The value is not between {first} and {second}");
            return readed;
        }
    }
}
