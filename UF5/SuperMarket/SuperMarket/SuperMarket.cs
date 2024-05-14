using System.ComponentModel.Design;
using System.Text;

namespace Super;

public class SuperMarket
{
    private string name;
    private string adress;
    public static int MAX_LINES = 5;
    private int activeLines;
    private CheckOutLine?[] lines = new CheckOutLine?[MAX_LINES];
    private Dictionary<string, Person> staff; //cashiers.txt
    private Dictionary<string, Person> customers; //customers.txt
    private SortedDictionary<int, Item> warehouse; //items.txt
    public Dictionary<string, Person> Staff => staff;
    public Dictionary<string, Person> Customers => customers;
    public SortedDictionary<int, Item> Warehouse => warehouse;
    public int ActiveLines => activeLines;
    public CheckOutLine?[] Lines => lines;
    

    public SuperMarket(string name, string adress, string fileCashiers, string fileCustomers, string fileItems,
        int activeLines)
    {
        if (activeLines > MAX_LINES)
            throw new Exception($"The number of active lines cannot be greater than {MAX_LINES}");
        staff = LoadCashiers(fileCashiers);
        customers = LoadCustomers(fileCustomers);
        warehouse = LoadWarehouse(fileItems);
        for (int i = 0; i < activeLines; i++)
        {
            lines[i] = new CheckOutLine(GetAvailableCashier(), i + 1);
        }

        this.activeLines = activeLines;
    }

    private SortedDictionary<int,Item> LoadWarehouse(string fileName)
    {
        SortedDictionary<int,Item> warehouse = new();
        using (StreamReader sr = new(fileName))
        {
            string? line = sr.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var sp = line.Split(";");
                Item i = new Item(sp[0], Convert.ToInt32(sp[1]), char.Parse(sp[2]), Convert.ToDouble(sp[3]));
                warehouse.Add(i.Code, i);
                line = sr.ReadLine();
            }
        }

        return warehouse;
    }

    private Dictionary<string,Person> LoadCustomers(string fileName)
    {
        Dictionary<string, Person> customers = new();
        using (StreamReader sr = new(fileName))
        {
            string? line = sr.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var sp = line.Split(";");
                customers.Add(sp[0], 
                    new Customer(sp[0], sp[1], !string.IsNullOrEmpty(sp[2]) ? Convert.ToInt32(sp[2]) : null));
                line = sr.ReadLine();
            }
        }

        return customers;
    }

    private Dictionary<string,Person> LoadCashiers(string fileName)
    {
        Dictionary<string, Person> staff = new();
        using (StreamReader sr = new(fileName))
        {
            string? line = sr.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var sp = line.Split(";");
                staff.Add(sp[0], new Cashier(sp[0], sp[1], sp[3]));
                line = sr.ReadLine();
            }
        }

        return staff;
    }

    public HashSet<Item> GetItemsByStock()
    {
        HashSet<Item> items = [];
        foreach (var item in warehouse.Values)
        {
            items.Add(item);
        }
        return items;
    }

    public Person GetAvailableCustomer()
    {
        Person? customer = null;
        var inactiveCustomers = customers.Values.Where(x => !x.Active).ToList();
        Random r = new Random();
        customer = inactiveCustomers.ElementAt(r.Next(0, inactiveCustomers.Count));
        customer.Active = true;
        return customer;
    }

    public Person GetAvailableCashier()
    {
        var inactiveCashiers = customers.Values.Where(x => !x.Active).ToList();
        Random r = new Random();
        Person cashier = inactiveCashiers.ElementAt(r.Next(0, inactiveCashiers.Count));
        cashier.Active = true;
        return cashier;
    }

    public void OpenCheckOutLine(int line2Open)
    {
        if (line2Open < 1 || line2Open > MAX_LINES)
            throw new Exception("Incorrect line number");
        if (lines[line2Open - 1] is not null)
            throw new Exception("Line already opened");
        lines[line2Open - 1] = new CheckOutLine(GetAvailableCashier(), line2Open);
        activeLines++;
    }

    public CheckOutLine? GetCheckOutLine(int lineNumber)
    {
        if (lineNumber < 1 || lineNumber > MAX_LINES)
            return null;
        return lines[lineNumber - 1];
    }

    public bool JoinQueue(ShoppingCart cart, int line)
    {
        if (line < 1 || line > MAX_LINES || lines[line - 1] is null)
            return false;
        lines[line - 1]?.CheckIn(cart);
        return true;
    }

    public bool CheckOut(int line)
    {
        if (line < 1 || line > MAX_LINES || lines[line - 1] is null)
            return false;
        return lines[line - 1].CheckOut();
    }

    public override string ToString()
    {
        StringBuilder sb = new($"{name}\n" +
                               $"{adress}");
        foreach (var line in lines)
        {
            if (line is not null)
                sb.Append(line);
        }
        return sb.ToString();
    }

    public static bool CloseCheckOutLine(SuperMarket super, int lineToRemove)
    {
        CheckOutLine? line = super.GetCheckOutLine(lineToRemove);
        if (line is null || !line.Empty) return false;
        line.Cashier.Active = false;
        super.lines[lineToRemove-1] = null;
        super.activeLines--;
        return true;
    }
}