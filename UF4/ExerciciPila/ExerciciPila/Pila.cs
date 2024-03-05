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
    public Pila() : this(10) {}

    public void Empila(T element)
    {
        if (element is null) throw new ArgumentNullException(nameof(element));
        if (nElements == elements.Length) throw new StackOverflowException();
        elements[nElements] = element;
        nElements++;
    }

    public T Desempila()
    {
        nElements--;
        T element = elements[nElements];
        elements[nElements] = default;
        return element;
    }
    
    public T? Cim => nElements > 0 ? elements[nElements - 1] : throw new Exception("STACK UNDERFLOW");

    public bool EsBuida => nElements == 0;

    public bool EsPlena => nElements == elements.Length;

    public override bool Equals(object? obj)
    {
        bool equals = false;
        if (obj is Pila<T>)
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
        StringBuilder sb = new StringBuilder();
        if (EsBuida)
            sb.Append("PILA BUIDA: -");
        else
        {
            if (EsPlena)
            {
                sb.Append("PILA PLENA:");
            }
            else
            {
                sb.Append($"PILA {nElements}/{elements.Length}: ");
            }
            for (int i = nElements - 1; i > 0; i--)
            {
                sb.Append(elements[i] + "-");
            }
            sb.Append(elements[0]);
        }

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