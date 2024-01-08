namespace Exercici1
{
    internal class Program
    {
        private const string FILE_NAME = "nums.txt";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(FILE_NAME);
            string? line = sr.ReadLine();
            int? antAnt = 0;
            int? ant = 0;
            int? act = 0;
            bool conditionComplete = false;
            if(line == null) Console.WriteLine("Emplty file");
            else
            {
                antAnt = Convert.ToInt32(line);
                line = sr.ReadLine();
                if(line == null) Console.WriteLine("Missing 2 elements");
                else
                {
                    ant = Convert.ToInt32(line);
                    line = sr.ReadLine();
                    if(line == null) Console.Write("Missing 1 element");
                    else
                    {
                        while (!conditionComplete && line != null)
                        {
                            act = Convert.ToInt32(line);
                            conditionComplete = act == ant + antAnt;
                            if (!conditionComplete)
                            {
                                antAnt = ant;
                                ant = act;
                                line = sr.ReadLine();
                            }
                        }

                        if (conditionComplete)
                        {
                            Console.WriteLine($"{act} = {antAnt} + {ant}");
                            Console.WriteLine("Found one number with the propieties needed");
                        }
                        else
                            Console.WriteLine("Not found");
                    }
                }
            }


        }
    }
}