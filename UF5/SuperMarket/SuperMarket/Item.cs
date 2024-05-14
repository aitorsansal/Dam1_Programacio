namespace Super;

public class Item : IComparable<Item>
{

    public enum Category {Beverage =1, Fruits, Vegetables, Bread, MilkAndDerivatives, Garden, Meat, Sweets, Sauces, Frozen, Cleaning, Fish, Other}
    public enum Packaging {Unit, Kg, Package}

    private static int newItemId = 0;

    private char currency = '\u20AC';
    private int code;
    private string description;
    private bool onSale;
    private double price;
    private Category category;
    private Packaging packaging;
    private double stock = 10;
    private int minStock = 5;
    public Item(string description, int category, char packaging, double price)
    {
        if (stock < minStock)
            throw new Exception("The stock cannot be less than the min stock.");
        code = newItemId;
        newItemId++;
        this.description = description;
        Random r = new Random();
        stock = r.Next(minStock, 500);
        this.price = price;
        this.category = (Category)category;
        onSale = r.Next(5) == 4;
        this.packaging = packaging switch
        {
            'K' => Packaging.Kg,
            'U' => Packaging.Unit,
            'P' => Packaging.Package,
            _ => throw new Exception("The type of packaging is incorrect")
        };
    }

    public double Stock => stock;
    public int MinStock => minStock;
    public Packaging PackagingType => packaging;
    public string Description => description;
    public Category GetCategory => category;
    public bool OnSale => onSale;
    public double Price => OnSale ? price * .9 : price;
    public int Code => code;

    public static void UpdateStock(Item item, double qty)
    {
        item.stock += qty;
    }
    public int CompareTo(Item? other)
    {
        return other is null ? 1 : stock.CompareTo(other.stock);
    }

    public override string ToString()
    {
        return
            $"CODE→{code} // DESCRIPTION→{Description} // CATEGORY→{GetCategory} // STOCK→{Stock} // MIN_STOCK→{MinStock} // " +
            $"PRICE→{price}{currency} // ON SALE→{(OnSale ? $"Y ({Price}{currency})" : "N")}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return this is null;
        if (obj is not Item item) return false;
        return code == item.code;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(code);
    }
}