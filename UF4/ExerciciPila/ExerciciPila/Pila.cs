using System.Text;

namespace ExerciciPila;

public class Pila<T>
{
    private T?[] elements;
    private int nElements;

    public Pila(int size)
    {
        elements = new T?[size];
        nElements = 0;
    }
    public Pila() : this(5) {}

    public void Empila(T? element)
    {
        if (element is null) throw new ArgumentNullException(nameof(element));
        elements[nElements] = element;
        nElements++;
    }

    public void Desempila()
    {
        for (int i = 0; i < nElements; i++)
        {
            elements[i] = default;
        }

        nElements = 0;
    }
    
    public T? Cim()
    {
        return elements[nElements - 1];
    }

    public bool EsBuida()
    {
        return nElements == 0;
    }

    public bool EsPlena()
    {
        return nElements == elements.Length;
    }

    public override bool Equals(object? obj)
    {
        bool equals = false;
        if (obj is not null && obj is Pila<T>)
        {
            Pila<T> toCheck = (Pila<T>)obj;
            if (nElements == toCheck.nElements)
            {
                equals = true;
                for (int i = 0; i < nElements && equals; i++)
                {
                    equals = toCheck[i]!.Equals(this[i]);
                }
            }
        }
        return equals;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("[");
        for (int i = 0; i < nElements -1; i++)
        {
            sb.Append(elements[i] + ",");
        }

        sb.Append(elements[nElements - 1] + "]");
        return sb.ToString();
    }

    public T? this[int index]
    {
        get => index <= nElements || index > 0 ? elements[index] : throw new IndexOutOfRangeException($"{index} out of range [0,{nElements - 1}]");
        set
        {
            if (index < nElements || index > 0)
                throw new IndexOutOfRangeException($"{index} out of range [0,{nElements - 1}]");
            if (value is null) throw new ArgumentNullException(nameof(value));
            elements[index] = value;
        }
    } 
}