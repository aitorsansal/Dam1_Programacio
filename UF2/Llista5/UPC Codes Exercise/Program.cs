using System.Text;

namespace UPC_Codes_Exercise
{
    internal class Program
    {
        private const string FILE_NAME = "Codes.txt";
        static void Main(string[] args)
        {
            var UPCs = GenerateCheckDigit();
            foreach (var UPC in UPCs)
            {
                Console.WriteLine(UPC);
            }
        }

        static string[] GenerateCheckDigit()
        {
            var checkDigit = 0;
            List<string> UPCs = new();
            StringBuilder sb = new();
            using (StreamReader sr = new StreamReader(FILE_NAME))
            {
                int timesToLoop = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < timesToLoop; i++)
                {
                    sb.Clear();
                    var numbsAsString = sr.ReadLine().Split(" ");
                    for (int j = 0; j < numbsAsString.Length; j+=2)
                    {
                        checkDigit += Convert.ToInt32(numbsAsString[j]);
                    }
                    checkDigit *= 3;

                    for (int j = 1; j < numbsAsString.Length; j += 2)
                    {
                        checkDigit += Convert.ToInt32(numbsAsString[j]);
                    }

                    checkDigit %= 10;
                    foreach (var numb in numbsAsString)
                    {
                        sb.Append(numb + " ");
                    }
                    sb.Append(checkDigit == 0 ? checkDigit : 10-checkDigit);
                    UPCs.Add(sb.ToString());
                }
            }
            return UPCs.ToArray();
        }
    }
}
