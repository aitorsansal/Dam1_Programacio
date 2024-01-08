namespace Exercici4
{
    internal class Program
    {
        const string FILE_NAME = "coords.txt";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(FILE_NAME);
            double radius;
            double coordX, coordY;
            string line = sr.ReadLine();
            Console.Write("Entra el radi de la circumferència: ");
            radius = Convert.ToDouble(Console.ReadLine());

            while(line != null)
            {
                coordX = double.Parse(line);
                line = sr.ReadLine();
                coordY = double.Parse(line);

                double hip = Math.Sqrt(coordY * coordY + coordX * coordX);
                if (hip > radius)
                    Console.WriteLine($"El punt {coordX}, {coordY} está fora del cercle de radi {radius}.");
                else if(hip < radius)
                    Console.WriteLine($"El punt {coordX}, {coordY} está dins del cercle de radi {radius}.");
                else
                    Console.WriteLine($"El punt {coordX}, {coordY} está en el perímetre cercle de radi {radius}.");


                line = sr.ReadLine();
            }
            
        }
    }
}