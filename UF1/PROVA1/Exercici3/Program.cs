namespace Exercici3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i1, i2, i3, i4;
            double endResult;
            Console.Write("Entra el primer dígit: ");
            i1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra el segon dígit: ");
            i2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra el tercer dígit: ");
            i3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entra el quart dígit: ");
            i4= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("El número entrat és: " + i1 + i2 + i3 + i4);

            endResult = i4 * Math.Pow(2, 0) + i3 * Math.Pow(2, 1) + i2 * Math.Pow(2, 2) + i1 * Math.Pow(2, 3);
            Console.WriteLine(endResult);
        }
    }
}