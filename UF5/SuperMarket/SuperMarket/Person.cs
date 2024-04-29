namespace SuperMarket;

public abstract class Person : IComparable<Person>
{
    protected string _fullName;
    protected string _id;
    protected int _points;
    protected double _totalInvoiced;
    private bool active;

    public bool Active
    {
        get => active;
        set => active = value;
    }

    protected abstract double GetRating { get; }
    public string FullName => _fullName;
    
    protected abstract void AddPoints(int pointsToAdd);
    
    protected Person(string id, string fullName, int points)
    {
        _id = id;
        _fullName = fullName;
        _points = points;
        active = false;
    }

    protected Person(string id, string fullName) : this(id, fullName, 0) { }

    public int CompareTo(Person? other)
    {
        return other != null ? _points.CompareTo(other._points) : 1;
    }

    public void AddInvoiceAmount(double amount)
    {
        _totalInvoiced += amount;
    }

    public override string ToString()
    {
        return $"DISPONIBLE →{(Active ? "N" : "S")}";
    }
}