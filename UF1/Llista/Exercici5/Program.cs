namespace Exercici5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double c, radi, areaCercle, areaQuadrat, percentLoss;
            Console.WriteLine("Entra la quantitat de metres");
            c = Convert.ToDouble(Console.ReadLine());
            radi = c / 2;
            areaCercle = Math.PI * Math.Pow(radi, 2);
            areaQuadrat = Math.Pow(c, 2);
            percentLoss = Math.Round(100 - areaCercle / areaQuadrat * 100, 2);           
            Console.WriteLine("Percentatge de roba perduda: " + percentLoss);            
        }
    }
}