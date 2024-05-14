// See https://aka.ms/new-console-template for more information


internal class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new("values.csv");
        sw.WriteLine("Mida;SelectionSort_Ordered;BubbleSort_Ordered;QuickSort_Ordered;HeapSort_Ordered;" +
                     "DirectSort_Reverse;BubbleSort_Reverse;QuickSort_Reverse;HeapSort_Reverse;" +
                     "DirectSort_Random;BubbleSort_Random;QuickSort_Random;HeapSort_Random");
        //mida;directa_ordenada;sacsejada_ordenada;quicksort_ordenada;heapsort_ordenada...
        for (int i = 100; i < 10001; i+=100)
        {
            int[] orderedTable = new int[i];
            int[] reverseTable = new int[i];
            int[] unorderedTable = new int[i];

            for (int j = 0; j < i; j++)
            {
                orderedTable[j] = j+1;
            }

            reverseTable = (int[])orderedTable.Clone();
            Array.Reverse(reverseTable);
            Random r = new();
            for (int j = 0; j < i; j++)
            {
                unorderedTable[j] = r.Next(j);
            }
            sw.WriteLine($"{i};{SelectionSort(orderedTable)};{BubbleSort(orderedTable)};{QuickSort(orderedTable)};{HeapSort(orderedTable)};" + 
                         $"{SelectionSort((int[])reverseTable.Clone())};{BubbleSort((int[])reverseTable.Clone())};{QuickSort((int[])reverseTable.Clone())};{HeapSort((int[])reverseTable.Clone())};" +
                         $"{SelectionSort((int[])unorderedTable.Clone())};{BubbleSort((int[])unorderedTable.Clone())};{QuickSort((int[])unorderedTable.Clone())};{HeapSort((int[])unorderedTable.Clone())}");
            // Console.WriteLine(i);
        }
        sw.Close();
    }
//SelectionSort
    static int SelectionSort(int[] arr)
    {
        int n = arr.Length;
        int loopedTimes = 0;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
                loopedTimes++;
            }
            Intercanvi(ref arr[i], ref arr[minIndex]);
        }
        return loopedTimes;
    }
//BubbleSort
    static int BubbleSort(int[] arr)
    {
        int length = arr.Length;
        int loopedTimes = 0;
        bool swapped;
        do
        {
            swapped = false;
            for (int j = 0; j < length-1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Intercanvi(ref arr[j], ref arr[j + 1]);
                    swapped = true;
                }

                loopedTimes++;
            }

            for (int j = length - 1; j > 0; j--)
            {
                if (arr[j] < arr[j - 1])
                {
                    Intercanvi(ref arr[j], ref arr[j - 1]);
                    swapped = true;
                }

                loopedTimes++;
            }
        } while (swapped);
        return loopedTimes;
    }
//QuickSort
    static int QuickSort(int[] taula)
    {
        int nComparacions;
        nComparacions = Particio(taula, 0, taula.Length - 1, 0);
        return nComparacions;
    }
    static int Particio(int[] numeros, int esq, int drt, int nComp)
    {
        int i, j, x;
        i = esq;
        j = drt;
        x = numeros[(esq + drt) / 2];
        do
        {
            while (numeros[i] < x)
            {
                nComp++;
                i++;
            }
            while (x < numeros[j])
            {
                nComp++;
                j--;
            }
            if (i <= j)
            {
                Intercanvi(ref numeros[i], ref numeros[j]);
                i++;
                j--;
            }
        } while (i <= j);
        if (esq < j)
            nComp = Particio(numeros, esq, j, nComp);
        if (i < drt)
            nComp = Particio(numeros, i, drt, nComp);
        return nComp;
    }
    static void Intercanvi(ref int a, ref int b)
    {
        int temp;
        temp = a;
        a = b;
        b = temp;
    }
//HeapSort
    static int HeapSort(int[] numeros)
    {
        int esq, drt, nComparacions = 0;
        esq = ((numeros.Length - 1) / 2) + 1;
        drt = numeros.Length - 1;
        while (esq > 0)
        {
            esq--;
            nComparacions += Ajusta(numeros, esq, drt);
        }
        while (drt > 0)
        {
            Intercanvi(ref numeros[0], ref numeros[drt]);
            drt--;
            nComparacions += Ajusta(numeros, 0, drt);
        }
        return nComparacions;
    }
    static int Ajusta(int[] numeros, int esq, int drt)
    {
        int i, j, x;
        int nComparacions = 0;
        i = esq;
        j = 2 * esq;
        x = numeros[esq];
        if ((j < drt) && (numeros[j] < numeros[j + 1]))
        {
            nComparacions++;
            j++;
        }
        while ((j <= drt) && (x < numeros[j]))
        {
            numeros[i] = numeros[j];
            i = j;
            j = j * 2;
            if ((j < drt) && (numeros[j] < numeros[j + 1]))
            {
                nComparacions++;
                j++;
            }
        }
        numeros[i] = x;
        return nComparacions;
    }
}