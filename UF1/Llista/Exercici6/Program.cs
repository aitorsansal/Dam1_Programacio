namespace Exercici6
{
    internal class Program
    {
        public const double IVA = .21;
        static void Main(string[] args)
        {
            double importBrut, iva, importNet, discountPercent, discount, importBrutAmbDescompte;
            discountPercent = -1;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Import brut de la venta ---> ");
            importBrut = Math.Round(Convert.ToDouble(Console.ReadLine()));
            Console.Write("Percentatge del descompte (0 a 100) ---> ");
            discountPercent = Convert.ToDouble(Console.ReadLine());
            while(discountPercent < 0 || discountPercent > 100)
            {
                Console.WriteLine("Valor incorrecte. Torni a introduir-ho.");
                Console.Write("Percentatge del descompte (0 a 100) ---> ");
                discountPercent = Convert.ToDouble(Console.ReadLine());
            }
            discount = importBrut * (discountPercent / 100);
            importBrutAmbDescompte = importBrut - discount;
            iva = Math.Round(importBrutAmbDescompte * IVA, 2);
            importNet = importBrutAmbDescompte + iva;
            Console.WriteLine("IMport venda \t\t" + importBrut);
            Console.WriteLine("Descompte({0}%) \t\t" + discount + "€", discountPercent);
            Console.WriteLine("Import venda sense iva: " + importBrutAmbDescompte + "€");
            Console.WriteLine("IVA(" + IVA * 100 + "%) \t\t" + iva + "€");
            Console.WriteLine("Import final: \t\t" + importNet + "€");
        }
    }
}