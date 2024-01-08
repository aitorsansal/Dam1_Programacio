namespace Exercici1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nota1, nota2, nota3, nota4, nota5;

            Console.Write("Introdueix la primera nota (1 a 10): ");
            nota1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Introdueix la segona nota (1 a 10): ");
            nota2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Introdueix la tercera nota (1 a 10): ");
            nota3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Introdueix la quarta nota (1 a 10): ");
            nota4 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Introdueix la cinquena nota (1 a 10): ");
            nota5 = Convert.ToDouble(Console.ReadLine());

            Console.Write("MITJANA DEL TRIMESTRE --> " + Math.Round((nota1 + nota2 + nota3 + nota4 + nota5)/5),0);
        }
    }
}