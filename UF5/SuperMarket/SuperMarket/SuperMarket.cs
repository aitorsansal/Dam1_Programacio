namespace SuperMarket;

public class SuperMarket
{
    private string name;
    private string adress;
    public static int MAX_LINES = 5;
    private int activeLines;
    private CheckOutLine[] lines = new CheckOutLine[MAX_LINES];
    private Dictionary<string, Person> staff; //cashiers.txt
    private Dictionary<string, Person> customers; //customers.txt
    private SortedDictionary<int, Item> warehouse; //items.txt

    public SuperMarket(string name, string adress, string fileCashiers, string fileCustomers, string fileItems,
        int activeLines)
    {
        //if activelines > maxlines exception
        if (activeLines > MAX_LINES)
            throw new Exception($"The number of active lines cannot be greater than {MAX_LINES}");
        staff = LoadCashiers(fileCashiers);
        customers = LoadCustomers(fileCustomers);
        warehouse = LoadWarehouse(fileItems);

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
}