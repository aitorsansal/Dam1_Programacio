// See https://aka.ms/new-console-template for more information
namespace DAM1;
internal class Program
{
    public static void Main(string[] args)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(5);
        q.Enqueue(3);
        q.Enqueue(9);
        q.Enqueue(6);
        q.Enqueue(4);
        q.Enqueue(3);
        q.Enqueue(11);
        q.Enqueue(8);
        Console.WriteLine(q);
        var q2 = q.Requeue();
        q2.Enqueue(55);
        Console.WriteLine(q);
        Console.WriteLine(q2);
    }
}
