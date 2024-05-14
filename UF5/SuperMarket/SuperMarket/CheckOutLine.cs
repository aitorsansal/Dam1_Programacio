using System.Text;

namespace Super;

public class CheckOutLine(Person responsible, int number)
{
    private int number = number;
    private Queue<ShoppingCart> queue = new();
    private Person cashier = responsible;
    private bool active = true;
    public int Number => number;
    public bool CheckIn(ShoppingCart shoppingCart)
    {
        if (active)
            queue.Enqueue(shoppingCart);
        return active;
    }
    
    public bool CheckOut()
    {
        if (!active || queue.Count == 0)
            return false;
        var shoppingCart = queue.Dequeue();
        double totalOfShopping = ShoppingCart.ProcessItems(shoppingCart);
        int rawPoints = shoppingCart.RawPointsObtainedAtChechout(totalOfShopping);
        shoppingCart.Customer.AddInvoiceAmount(totalOfShopping);
        shoppingCart.Customer.AddPoints(rawPoints);
        cashier.AddPoints(rawPoints);
        cashier.AddInvoiceAmount(totalOfShopping);
        shoppingCart.Customer.Active = false;
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append($"NUMERO DE CAIXA →{number}\n" +
                  $"CAIXER/A AL CÀRREC →{cashier.FullName}\n");
        if (queue.Count == 0)
            sb.Append("CAIXA BUIDA");
        else
            foreach (var shpCart in queue)
            {
                sb.Append(shpCart);
                sb.Append('\n');
            }
        return sb.ToString();
    }
}