using System.Collections;
using System.Text;

namespace DAM1;

public class Queue<T> : IEnumerable<T>, IEnumerable
{
    private T[] data;
    private int front = -1;
    private const int DEFAULT_SIZE = 10;

    #region Cosntructors

    public Queue(int size)
    {
        data = new T[size];
    }
    public Queue() : this(DEFAULT_SIZE){}

    #endregion

    #region Properties

    public bool Full => front == data.Length - 1;
    public bool IsEmpty => front == -1;
    public int Count => front + 1;
    public T this[int index]
    {
        get
        {
            if (index < 0 || index > front) throw new IndexOutOfRangeException($"{index} out of range [0,{front}]");
            return data[index];
        }
    }

    #endregion

    public T DeQueue()
    {
        if (IsEmpty) throw new Exception("The queue is empty");
        T element = data[front];
        data[front] = default(T);
        front--;
        return element;
    }

    public T Peek()
    {
        if (IsEmpty) throw new Exception("The queue is empty");
        return data[front];
    }

    public void Enqueue(T element)
    {
        for (int i = front; i >= 0; i--)
        {
            data[i + 1] = data[i];
        }
        data[0] = element;
        front++;
    }

    public void Enqueue(IEnumerable<T> elements)
    {
        foreach (var elem in elements)
        {
            Enqueue(elem);
        }
    }
    public T[] ToArray()
    {
        T[] arrToReturn = new T[front+1];
        IEnumerator<T> iEnum = GetEnumerator();
        int i = 0;
        while (iEnum.MoveNext())
        {
            arrToReturn[i] = iEnum.Current;
            i++;
        }
        iEnum.Dispose();
        return arrToReturn;
    }

    public bool Contains(T element)
    {
        IEnumerator<T> iEnum = GetEnumerator();
        bool found = false;
        while (iEnum.MoveNext() && !found)
        {
            if (iEnum.Current != null && iEnum.Current.Equals(element)) found = true;
        }
        iEnum.Dispose();
        return found;
    }
    public override string ToString()
    {
        StringBuilder sb = new("[");
        // for (int i = front; i >= 0; i--) sb.Append($"{data[i]},");
        IEnumerator<T> iEn = GetEnumerator();
        while (iEn.MoveNext()) sb.Append($"{iEn.Current},");
        iEn.Reset();
        if (front != -1) sb.Remove(sb.Length - 1, 1);
        sb.Append(']');
        iEn.Dispose();
        return sb.ToString();
    }

    public Queue<T> Requeue()
    {
        Queue<T> secondQueue = new(data.Length);
        int half = front / 2;
        for (int i = half; i >= 0; i--)
        {
            secondQueue.Enqueue(data[i]);
        }

        for (int i = 0; i < half; i++)
        {
            data[i] = data[i + half+1];
            data[i + half + 1] = default(T);
            front--;
        }

        return secondQueue;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        // for (int i = front; i >= 0; i--) yield return data[i];
        return new QEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    
    public class QEnumerator<TEnum> : IEnumerator<TEnum>, IEnumerator
    {
        private int posCursor;
        private Queue<TEnum> queue;

        public QEnumerator(Queue<TEnum> q)
        {
            queue = q;
            posCursor = queue.front+1;
        }
        public bool MoveNext()
        {
            bool worked = false;
            if (posCursor-1 >= 0)
            {
                posCursor--;
                worked = true;
            }
            return worked;
        }

        public void Reset()
        {
            posCursor = queue.front+1;
        }

        public TEnum Current {
            get
            {
                if (posCursor < 0 || posCursor > queue.front) throw new IndexOutOfRangeException();
                return queue[posCursor];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Reset();
        }
    }
}