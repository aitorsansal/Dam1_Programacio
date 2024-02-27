using ED;
public class Program
{
    public static void Main(string[] args)
    {
        TaulaLlista llista = new TaulaLlista(5);
        llista.Afegeix(5);
        llista.Afegeix(1);
        llista.Afegeix(1);
        Console.WriteLine(llista);
        llista.Insereix(5,2);
        llista.Afegeix(3);
        Console.WriteLine(llista);
        llista.Elimina(5);
        Console.WriteLine(llista);
        llista.Afegeix(5);
        llista.Inverteix();
        Console.WriteLine(llista);
    }
}