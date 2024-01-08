namespace Exercici3
{
    internal class Program
    {
        public const double IVA = .21;
        static void Main(string[] args)
        {
            double importBrut, iva, importNet;
            Console.OutputEncoding= System.Text.Encoding.UTF8;
            Console.Write("Import brut de la venta ---> ");
            importBrut = Math.Round(Convert.ToDouble(Console.ReadLine()));
            iva = Math.Round(importBrut * IVA, 2);
            importNet = importBrut + iva;
            Console.WriteLine("Import venda sense iva: " + importBrut + "€");
            Console.WriteLine("IVA(" + IVA * 100 + "%) \t\t" + iva + "€");
            Console.WriteLine("Import final: \t\t" + importNet + "€");
        }
    }
}