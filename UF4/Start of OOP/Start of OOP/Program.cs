using System.Threading.Channels;
using GestioBancaria;

namespace Start_of_OOP;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount("ES0251325","Aitor", "Sánchez", 500);
        Console.WriteLine(account.GetHashCode());
        account++;
        Console.WriteLine("--------");
        Console.WriteLine(account.GetHashCode());
    }
}