using System.Collections;
using System.Formats.Tar;
using System.Text;

namespace PilaDinamica;

public class Pila<T>: IList<T>
{
    private Node<T>? top = null;
    private int count = 0;
    public Pila() { }

    public Pila(T info)
    {
        Node < T > node = new Node<T>(info);
        top = node;
    }

    public bool Empty => top == null || Count == 0;

    public void Push(T info)
    {
        Node<T> node = new Node<T>(info);
        if (!Empty)
        {
            node.Seg = top;
            top = node;
        }
        else
            top = node;
        count++;
    }

    public T Pop()
    {
        if (Empty) throw new Exception("STACK UNDERFLOW");
        T dada = top.Info;
        if (top.Seg == null) top = null;
        else
        {
            Node<T> tmp = top;
            top = top.Seg;
            tmp.Seg = null;
        }
        count--;
        return dada;
    }

    private Node<T> GoTo(int position)
    {
        Node<T> nodeInPos = top;
        if (position >= 0 && position < Count)
            for (int i = 0; i < position; i++)
            {
                nodeInPos = nodeInPos.Seg;
            }
        else
            nodeInPos = null;

        return nodeInPos;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> cursor = top;
        while (cursor != null)
        {
            yield return cursor.Info;
            cursor = cursor.Seg;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        Push(item);
    }

    public void Clear()
    {
        if (IsReadOnly) throw new NotSupportedException();
        int end = count;
        for (int i = 0; i < end; i++)
        {
            Pop();
        }
    }

    public bool Contains(T item)
    {
        Node<T> cursor = top;
        bool found = false;
        while (found && cursor != null)
        {
            if (cursor.Info.Equals(item)) found = true;
            else cursor = cursor.Seg;
        }
        return found;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null) 
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0) 
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length <= arrayIndex+Count)
            throw new 
                ArgumentException($"The array lenght should be greater than the stack length: {Count}");
        Node<T> cursor = top;
        while (cursor != null)
        {
            array[arrayIndex] = cursor.Info;
            cursor = cursor.Seg;
            arrayIndex++;
        }
    }

    public bool Remove(T item)
    {
        if (IsReadOnly) throw new NotSupportedException();
        Node<T> cursor = top;
        Node<T> last = null;
        bool worked = false;
        while (cursor != null && !worked)
        {
            if (cursor.Info.Equals(item))
            {
                if(last == null)
                    top = cursor.Seg;
                else
                    last.Seg = cursor.Seg;
                worked = true;
                count--;
            }
            else
            {
                last = cursor;
                cursor = cursor.Seg;
            }
        }
        return worked;
    }

    public int Count => count;

    public bool IsReadOnly { get; }
    public int IndexOf(T item)
    {
        var enumerator = GetEnumerator();
        int index = 0;
        bool found = false;
        while (!found && enumerator.MoveNext())
        {
            if (enumerator.Current.Equals(item)) found = true;
            else
                index++;
        }
        enumerator.Dispose();
        return found ? index : -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
        if (IsReadOnly) throw new NotSupportedException();
        Node<T> toAdd = new Node<T>(item);
        var existingBefore = GoTo(index-1);
        toAdd.Seg = existingBefore.Seg;
        existingBefore.Seg = toAdd;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
        if (IsReadOnly) throw new NotSupportedException();
        if (index == 0) Pop();
        else
        {
            var nodeToRemove = GoTo(index);
            var before = GoTo(index - 1);
            before.Seg = nodeToRemove.Seg;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count) 
                throw new ArgumentOutOfRangeException(nameof(index));
            return GoTo(index).Info;
        }
        set
        {
            if (IsReadOnly) throw new NotSupportedException();
            if (index < 0 || index >= Count) 
                throw new ArgumentOutOfRangeException(nameof(index));
            GoTo(index).Info = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("[");
        var enumerator = GetEnumerator();
        while (enumerator.MoveNext())
        {
            sb.Append(enumerator.Current);
            sb.Append(',');
        }

        if (Empty) sb.Remove(1, 1);
        sb.Append(']');
        enumerator.Dispose();
        return sb.ToString();
    }
    
    public override bool Equals(object? obj)
    {
        bool equals = false;
        if (this is not null) equals = obj is null;
        if (obj is not Pila<T>) equals = false;
        equals =  Equals(obj as Pila<T>);
        return equals;
    }

    public bool Equals(Pila<T>? obj)
    {
        bool equals = false;
        if (obj is null) equals = this is null;
        else
        {
            if (Count != obj.Count) equals = false;
            else
            {
                int i = 0;
                while (equals && i<Count)
                {
                    equals = GoTo(i).Info.Equals(obj.GoTo(i).Info);
                    i++;
                }
            }
        }
        return equals;
    }
}