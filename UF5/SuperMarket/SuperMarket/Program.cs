// See https://aka.ms/new-console-template for more information

using System.Text;

internal class Program
{
    static string GROCERIES = "GROCERIES.TXT";
    static string CUSTOMERS = "CUSTOMERS.TXT";
    static string STAFF = "CASHIERS.TXT";
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SuperMarket.SuperMarket superMarket =
            new SuperMarket.SuperMarket("Mercadona", "Carrer de Girona", STAFF, CUSTOMERS, GROCERIES, 3);
    }
}