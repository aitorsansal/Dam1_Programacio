using TL;
public class Program
{
    public static void Main(string[] args)
    {
        TaulaLlista tAndromines = new TaulaLlista(5);
        Random r = new Random();
        object o;
        for (int i = 0; i < 20; i++)
        {
            tAndromines.Afegeix(i);
            // o = r.Next(2) == 0 ? new Cercle(i, i, i * 2, i * 3) : new Article(i, $"ARTICLE-{i}", i);
            // tAndromines.Afegeix(o);
        }

        Console.WriteLine(tAndromines);
        tAndromines.Insereix(5, 10);
        Console.WriteLine(tAndromines);
        // for (int i = 0; i < tAndromines.NElements; i++)
        // {
        //     Console.Write($"Objecte {i} →");
        //     Cercle unCercle;
        //     Article unArticle;
        //     if (tAndromines[i] is Cercle)
        //     {
        //         unCercle = (Cercle)tAndromines[i];
        //         Console.WriteLine(unCercle.Preu);
        //     }
        //     else if (tAndromines[i] is Article)
        //     {
        //         unArticle = (Article)tAndromines[i];
        //         unArticle.IncrementarPreu(66);
        //         Console.WriteLine(unArticle.Preu);
        //     }
        //     else Console.WriteLine("TF ARE YOU");
        // }
    }
}