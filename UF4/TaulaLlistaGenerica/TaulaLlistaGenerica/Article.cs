namespace TL;

public class Article
{

    private int codi;
    private string nom;
    private double preu;
    
    public Article(int codi, string nom, double preu)
    {
        this.codi = codi;
        this.nom = nom;
        this.preu = preu;
    }

    public int Codi
    {
        get => codi;
        set => codi = value;
    }

    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Preu
    {
        get => preu;
        set => preu = value;
    }

    public void IncrementarPreu(double increment)
    {
        preu += increment;
    }
}