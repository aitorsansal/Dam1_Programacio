namespace Exercici2;

internal class Program
{
    public static void Main(string[] args)
    {
        double a, b, x;
        Console.WriteLine("Soluionant l'equació ax + b = 0");
        Console.Write("Valor del coeficient a ---> ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Valor del coeficient b ---> ");
        b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Equació {0}x+({1})=0", a, b);
        if (a != 0)
        {
            a = Math.Round(a / 2);
            b = Math.Round(b / 2);
            x = Math.Round(-b / a, 2);
            Console.WriteLine("Solució x={0}", x);
        }
        else Console.WriteLine("No té solució. El coeficient no pot ser 0");
        Console.ReadLine();
    }
}