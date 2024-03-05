using System.Threading.Channels;
using ExerciciPila;

internal class Program
{
    public static void Main(string[] args)
    {
        Pila<int> a = new Pila<int>();
        a.Empila(1);
        a.Empila(2);
        a.Empila(50);
        a.Empila(10);
        a.Empila(1);
        a.Empila(2);
        a.Empila(50);
        a.Empila(10);
        a.Empila(10);
        a.Empila(10);
        Console.WriteLine(a.Desempila());
        Console.WriteLine(a);
    }
}