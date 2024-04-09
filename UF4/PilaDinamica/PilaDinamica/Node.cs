namespace PilaDinamica;

public class Node<T>
{

    private T info;
    private Node<T> seg = null;
    
    public T Info
    {
        get => info;
        set => info = value;
    }

    public Node<T> Seg
    {
        get => seg;
        set => seg = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Node(T info)
    {
        this.info = info;
    }
    
    
}