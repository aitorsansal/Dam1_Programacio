namespace TL;

public class Cercle
{
    private double x;
    private double y;
    private double r;
    private double preuM2;

    public Cercle(double x, double y, double r, double preuM2)
    {
        this.x = x;
        this.y = y;
        this.r = r;
        this.preuM2 = preuM2;
    }

    public double X
    {
        get => x;
        set => x = value;
    }

    public double Y
    {
        get => y;
        set => y = value;
    }

    public double R
    {
        get => r;
        set => r = value;
    }

    public double Preu => preuM2 * Math.PI*r*r;
}