namespace Exercici1
{
    internal class Program
    {
        const string NOM_ARXIU = "nums1.txt";
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(NOM_ARXIU);
            double suma = 0;
            int totalNums = 0;
            double mitjana;
            string linia;
            linia = sr.ReadLine();

            while(linia != null)
            {
                suma += Convert.ToInt32(linia);

                totalNums++;
                linia = sr.ReadLine();
            }

            mitjana = suma / totalNums;
            Console.Write($"La mitjana és {mitjana}");
            sr.Close();
        }
    }
}