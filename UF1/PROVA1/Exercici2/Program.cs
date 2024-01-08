namespace Exercici2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double primerTreballador, segonTreballador, tercerTreballador;

            Console.Write("Primer treballador. Introdueix el teu salari: ");
            primerTreballador = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            Console.Write("Segon treballador. Introdueix el teu salari: ");
            segonTreballador = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            Console.Write("Tercer treballador. Introdueix el teu salari: ");
            tercerTreballador = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);

            Console.WriteLine($"El primer treballador cobrava {primerTreballador} i ara cobra: " + Math.Round(primerTreballador * 1.1), 2);
            Console.WriteLine($"El segon treballador cobrava {segonTreballador} i ara cobra: " + Math.Round(segonTreballador * 1.2), 2);
            Console.WriteLine($"El tercer treballador cobrava {tercerTreballador} i ara cobra: " + Math.Round(tercerTreballador * 1.3), 2);

        }
    }
}