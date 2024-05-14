using System.Text;

namespace Super;

public class ShoppingCart(Customer customer, DateTime dateOfPurchase)
{

    private Dictionary<Item, double> shoppingList = new();
    private Customer customer = customer;
    private DateTime dateOfPurchase = dateOfPurchase;
    public Dictionary<Item, double> ShoppingList => shoppingList;
    public Customer Customer => customer;
    public DateTime DateOfPurchase => dateOfPurchase;

    public void AddOne(Item item, double qty)
    {
        if (ShoppingList.ContainsKey(item))
            shoppingList[item] += qty;
        else
            shoppingList.Add(item, qty);
    }

    public void AddAllRandomly(SortedDictionary<int, Item> warehouse)
    {
        Random r = new Random();
        int times = r.Next(1, 11);
        for (int i = 0; i < times; i++)
        {
            int item = r.Next(0, warehouse.Count);
            AddOne(warehouse.ElementAt(item).Value, r.Next(1,6));
        }
    }

    public int RawPointsObtainedAtChechout(double totalInvoiced)
    {
        return (int)(totalInvoiced / 100);
    }

    public static double ProcessItems(ShoppingCart cart)
    {
        double totalInvoiced = 0;
        foreach (var item in cart.ShoppingList)
        {
            cart.shoppingList[item.Key] = item.Value > item.Key.Stock ? item.Key.Stock : item.Value;
            Item.UpdateStock(item.Key, -item.Value);
            totalInvoiced += item.Value * item.Key.Price;
        }
        return totalInvoiced;
    }

    public override string ToString()
    {
        StringBuilder sb = new($"*****\nINFO CARRITO DE LA COMPRA CLIENT→{customer.FullName}\n");
        foreach (var item in ShoppingList)
        {
            sb.Append(
                $"{(item.Key.Description.Length > 12 ? item.Key.Description[..12]+"~" : item.Key.Description), -13}" +
                $"{"Cat", 5}→{item.Key.GetCategory, -20}" +
                $"Qty→{item.Value, -5}" +
                $"UnitPrice→{item.Key.Price}\u20AC");
            if (item.Key.OnSale)
                sb.Append("(*)");
            sb.Append('\n');
        }

        sb.Append("***FI CARRITO COMPRA***");
        return sb.ToString();
    }
}