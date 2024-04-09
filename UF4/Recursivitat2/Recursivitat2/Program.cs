// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

internal class Program
{
    public static void Main(string[] args)
    {
        // Console.WriteLine(IsTriangular(15));
        // Console.WriteLine(TurnArroundNumber(5324));
        int[] testArray = [5,4,4,5];
        // Console.WriteLine(MaxFromVector(testArray));
        // int[] u = [10, -4, 7];
        // int[] v = [-2, 1, 6];
        // Console.WriteLine(CalcularProductoEscalar(v, u));
        // Console.WriteLine(ReturnPositionOfValue(testArray, 55));
        //Console.WriteLine(ArrayStartEnds(testArray));
        Console.WriteLine(TwoPartsAddTheSame(testArray));
    }

    #region Exercici 3

    static bool IsTriangular(int n)
    {
        if (n <= 0) throw new Exception("Shuld be higher than 0");
        return IsTriangular(n, 1,1);
    }
    static bool IsTriangular(int n, int index, int toAdd)
    {
        bool result;
        toAdd++;
        if (index > n)
            result = false;
        else if (index == n)
            result = true;
        else
        {
            result = IsTriangular(n, index+toAdd, toAdd);
        }
        return result;
    }

    #endregion

    static int TurnArroundNumber(int number)
    {
        int result = 0;
        int last = number % 10;
        number /= 10;
        if (number == 0)
            result = last;
        else
        {
            result = last;
            result *= 10;
            result += TurnArroundNumber(number);
        }
        return result;
    }

    #region Exercici 6

    static int MaxFromVector(int[] vect)
    {
        if (vect.Length <= 0) throw new Exception("Vector is empty");
        return MaxFromVector(vect, 0);
    }
    
    static int MaxFromVector(int[] vect, int index)
    {
        int result = vect[index];
        index++;
        if (index < vect.Length)
        {
            int aux = MaxFromVector(vect, index);
            result = result > aux ? result : aux;
        }
        return result;
    }

    #endregion

    #region Exercici 7

    static int CalcularProductoEscalar(int[] v, int[] u)
    {
        if (v.Length <= 0 || u.Length <= 0) throw new Exception("One of the vectors is null");
        if (v.Length != u.Length) throw new Exception("The vectors don't have the same length");
        return CalcularProductoEscalar(v, u, 0);
    }
    static int CalcularProductoEscalar(int[] v, int[] u, int index)
    {
        int result = v[index] * u[index];
        index++;
        if (index < v.Length)
        {
            result += CalcularProductoEscalar(v, u, index);
        }

        return result;
    }

    #endregion

    #region Exercici 8

    static int ReturnPositionOfValue(int[]array, int number)
    {
        return ReturnPositionOfValue(array, number, 0);
    }

    static int ReturnPositionOfValue(int[] array, int number, int index)
    {
        int result;
        if (index == array.Length)
            result = -1;
        else if (array[index] == number)
            result = index;
        else
        {
            index++;
            result = ReturnPositionOfValue(array, number, index);
        }
        return result;
    }

    #endregion

    #region Exercici 10

    static bool ArrayStartEnds(int[] vector)
    {
        if (vector.Length <= 0) throw new Exception("Array cannot be null");
        return ArrayStartEnds(vector, 0);
    }

    static bool ArrayStartEnds(int[] vector, int index)
    {
        bool result = vector[index] == vector[vector.Length - 1 - index];
        if (result && index < vector.Length / 2)
        {
            index++;
            result = result && ArrayStartEnds(vector, index);
        }

        return result;
    }

    #endregion

    static bool TwoPartsAddTheSame(int[] array)
    {
        if (array.Length <= 0) throw new Exception("Array cannot be empty");
        return TwoPartsAddTheSame(array, 0);
    }

    static bool TwoPartsAddTheSame(int[] array, int index)
    {
        bool result = false;
        int firstPart = 0;
        int secondPart = 0;
        for (int i = 0; i < index; i++)
        {
            firstPart += array[index];
        }

        for (int i = index; i < array.Length; i++)
        {
            secondPart += array[index];
        }

        if (firstPart == secondPart)
            result = true;
        else if(++index < array.Length)
        {
            index++;
            result = TwoPartsAddTheSame(array, index);
        }

        return result;
    }
}