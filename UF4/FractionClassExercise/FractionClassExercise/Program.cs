// See https://aka.ms/new-console-template for more information

using FractionClassExercise;

internal class Program
{
    public static void Main(string[] args)
    {
        Fraction f1 = new Fraction(2, 3, '+');
        Fraction f2 = new Fraction(4, 6, '+');
        Console.WriteLine((double)f1);
        f1.Add(f2);
        Console.WriteLine($"After addition f1 = {f1} and f2 = {f2}");
        f1.Simplify();
        Console.WriteLine($"After simplifying f1 = {f1}");
    }
}