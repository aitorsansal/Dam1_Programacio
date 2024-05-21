namespace TestSuper
{
    using Super;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPriceArticleOnSale()
        {
            Item it = new Item(1, "a", true, 10, Item.Category.Beverage, Item.Packaging.Unit, 10, 10);
            Assert.AreEqual(it.Price, 9.00);
        }

        [TestMethod]
        public void TestComparadorStockPerQuantitat()
        {
            var al = new List<Item>();
            al.Add(new Item(3, "a", true, 10, Item.Category.Beverage, Item.Packaging.Unit, 30, 10));
            al.Add(new Item(1, "a", true, 10, Item.Category.Beverage, Item.Packaging.Unit, 10, 10));
            al.Add(new Item(2, "a", true, 10, Item.Category.Beverage, Item.Packaging.Unit, 20, 10));
            al.Sort();

            Assert.AreEqual(al[0].Stock, 10);
            Assert.AreEqual(al[1].Stock, 20);
            Assert.AreEqual(al[2].Stock, 30);
        }

        [TestMethod]
        public void TestCustomerRating()
        {
            var c = new Customer("1", "Client", null);
            c.AddInvoiceAmount(10);
            c.AddInvoiceAmount(90);
            Assert.AreEqual(100 * 0.02, c.GetRating, "El rating no �s correcte");
        }

        [TestMethod]
        public void TestCustomerAddPoints()
        {
            var c = new Customer("1", "Client", null);
            c.AddPoints(10);
            Assert.AreEqual(0, c.Points, "Els punts s'haurien d'haver perdut");
            c = new Customer("1", "Client", 23);
            c.AddPoints(10);
            c.AddPoints(20);
            Assert.AreEqual(30, c.Points, "Els punts NO s'haurien d'haver perdut");
        }

        [TestMethod]
        public void TestCashierYearsOfServiceAndPoints()
        {
            var dataJoin = new System.DateTime(2001, 01, 01);
            var diff = System.DateTime.Today - dataJoin;
            Cashier c = new Cashier("1", "A", new System.DateTime(2001, 01, 01));
            Assert.AreEqual(diff.Days / 365, c.YearsOfService, "Els anys de servei no quadren...");

            c.AddInvoiceAmount(10);

            Assert.AreEqual(c.GetRating, diff.Days + 10 * 0.1, "Els punts haurien de ser anys + 10*0.1");
        }

        [TestMethod]
        public void testCarrega()
        {
            //TODO: Posar els fitxers fca.txt, fcu.txt i fi.txt a la carpeta bin on s'executen les proves unit�ries.
            SuperMarket sm = new SuperMarket("super", "noimporta", "fca.txt", "fcu.txt", "fi.txt", 2);
            Assert.AreEqual(sm.Warehouse.Count, 8);
            Assert.AreEqual(sm.Warehouse[1].Description.Trim().ToLower(), "tropical fruit");
            Assert.AreEqual(sm.Warehouse[7].Description.Trim().ToLower(), "toilet cleaner");

            Assert.AreEqual(sm.Customers.Count, 6);
            Assert.AreEqual(sm.Customers["CASH"].FullName.Trim().ToLower(), "generic customer");
            Assert.AreEqual(sm.Customers["040302877T"].FullName.Trim().ToLower(), "francisca vallmajo trias");


            Assert.AreEqual(sm.Staff.Count, 3);
            Assert.AreEqual(sm.Staff["037276013M"].FullName.Trim().ToLower(), "caterina font vitales");
            Assert.AreEqual(sm.Staff["040317067E"].FullName.Trim().ToLower(), "joaquim reixach negre");
        }

        [TestMethod]
        public void testCarregaCaixersAmbDatesCorrectes()
        {
            SuperMarket sm = new SuperMarket("super", "noimporta", "fca.txt", "fcu.txt", "fi.txt", 2);
            Assert.AreEqual(sm.Staff.Count, 3);
            var diff = System.DateTime.Today - new System.DateTime(2015, 2, 1);
            Cashier c = (Cashier)sm.Staff["037276013M"];
            Assert.AreEqual(c.FullName.Trim().ToLower(), "caterina font vitales");
            Assert.AreEqual(c.YearsOfService, diff.Days / 365);

            diff = System.DateTime.Today - new System.DateTime(2021, 11, 1);
            c = (Cashier)sm.Staff["040317067E"];
            Assert.AreEqual(c.FullName.Trim().ToLower(), "joaquim reixach negre");
            Assert.AreEqual(c.YearsOfService, diff.Days / 365);
        }

        [TestMethod]
        public void testAfegirProducteAlShoppingCart()
        {
            //Comprovo que al afegir X productes al shopping cart, aquests s'afegeixen a la col�lecci�.
        }

        [TestMethod]
        public void testAfegirProducteAlShoppingCartIComprar()
        {
            //Comprovo que al afegir X productes al shopping cart, i executar la funci� processItems
            //el preu que retorna la funci� �s l'esperat.
            //Tamb� comprovo que l'estoc d'un dels articles s'ha actualitzat correctament.
        }
    }
}