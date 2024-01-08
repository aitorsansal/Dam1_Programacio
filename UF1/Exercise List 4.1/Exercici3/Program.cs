namespace Exercici3
{
    internal class Program
    {
        const string FILE_NAME = "loteria.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            StreamReader sr = new StreamReader(FILE_NAME);
            int bonusTicket = 0;
            int money = 0;
            double totalTicket = 0;
            var line = sr.ReadLine();
            while( totalTicket < 10)
            {
                if(line == "BONUS")
                {
                    line = sr.ReadLine();
                    money += Convert.ToInt32(line);
                    bonusTicket++;
                }
                totalTicket++;
                line = sr.ReadLine();
            }
            var percentageBonus = bonusTicket / totalTicket * 100;
            Console.WriteLine($"The total quantity of bonus tickets is {bonusTicket}, with a total of {money}€ won");
            Console.WriteLine($"The winning percentage is {percentageBonus}% from {totalTicket}");
            sr.Close();
        }
    }
}