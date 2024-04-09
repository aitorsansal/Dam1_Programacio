// See https://aka.ms/new-console-template for more information

using PilaDinamica;

Pila<int> pila = new Pila<int>();
pila.Push(1); 
pila.Push(2); 
pila.Push(3); 
pila.Push(4); 
pila.Add(5);
foreach (var p in pila)
{
    Console.WriteLine(p);
}
Console.WriteLine(pila.Count);
Console.WriteLine("-------------");
pila.Remove(3);
foreach (var p in pila)
{
    Console.WriteLine(p);

}
Console.WriteLine(pila.Count);
Console.WriteLine("-------------");
Console.WriteLine(pila.IndexOf(2));
foreach (var p in pila)
{
    Console.WriteLine(p);
}
Console.WriteLine("-------------");
