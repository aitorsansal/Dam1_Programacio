namespace SuperMarket;

public class Item : IComparable<Item>
{

    public enum Category {Beverage =1, Fruits, Vegetables, Bread, MilkAndDerivatives, Garden, Meat, Sweets, Sauces, Frozen, Cleaning, Fish, Other}
    public enum Packaging {Unit, Kg, Package}

    private char currency = '\u20AC';
    private int code;
    private string description;
    private bool onSale;
    private double price;
    private Category category;
    private Packaging packaging;
    private double stock;
    private int minStock;
    public Item(int code, string description, bool onSale, double price, Category category, Packaging packaging, double stock, int minStock)
    {
        //stock actual ha de ser >= que stock minim
        this.code = code;
        this.description = description;
        this.onSale = onSale;
        this.price = price;
        this.category = category;
        this.packaging = packaging;
        this.stock = stock;
        this.minStock = minStock;
    }

    public double Stock => stock;
    public int MinStock => minStock;
    public Packaging PackagingType => packaging;
    public string Description => description;
    public Category GetCategory => category;
    public bool OnSale => onSale;
    public double Price => OnSale ? price * .9 : price;

    public static void UpdateStock(Item item, double qty)
    {
        item.stock += qty;
    }
    public int CompareTo(Item? other)
    {
        throw new NotImplementedException();
        //BY STOCK
    }

    public override string ToString()
    {
        return
            $"CODE →{code} DESCRIPTION →{Description}\tCATEGORY→{GetCategory}\tSTOCK→{Stock}\tMIN_STOCK→{MinStock}\tPRICE→{price}{currency}\tON SALE→{(OnSale ? $"Y ({Price}{currency})" : "N")}";
    }
    //TODO: IMPLEMENT GETHASHCODE AND EQUALS
    
}