namespace Exercici1;


internal class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        int primerDau, segonDau, tercerDau;
        int suma;
        Console.WriteLine("Simulació del llançament de 3 daus i obtenció de la suma dels llançaments: ");
        primerDau = r.Next(1, 7);
        segonDau = r.Next(6) + 1;
        tercerDau = r.Next(1, 7);
        suma = primerDau + segonDau + tercerDau;
        Console.WriteLine("Valor 1er dau: " + primerDau);
        Console.WriteLine("Valor 2n dau: " + segonDau);
        Console.WriteLine("Valor 3r dau: " + tercerDau);
        Console.WriteLine("Suma dels 3 llançaments: " + suma);
    }
}