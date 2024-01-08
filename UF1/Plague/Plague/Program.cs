namespace Plague
{
    internal class Program
    {
        private const string FILE_NAME = "plague.txt";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(FILE_NAME);

            string? line = sr.ReadLine();
            int allAdded = 0;
            bool found = false;

            while (!found && line != null)
            {
                var number = Convert.ToInt32(line);
                allAdded += number;
                found = allAdded >= 200 || number >= 45;
                line = sr.ReadLine();
            }

            Console.WriteLine(found ? "Is a plague" : "Is not a plague");
            sr.Close();
        }
    }
}