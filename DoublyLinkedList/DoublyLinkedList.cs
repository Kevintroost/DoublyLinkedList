public interface IMyList<T>
{
    void Clear();
    void Add(T element);
    int IndexOf(T element);
    bool Contains(T element);
    void Insert(int index, T element);
    void Remove(T element);
    void RemoveAt(int index);
    T this[int index] { get; set; }
    int Count { get; }
}

public class DoubleLinkList<T> : IMyList<T>
{
    private class Node
    {
        public T Data;
        public Node? Next;
        public Node? Prev;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node? head;
    private Node? tail;
    private int count;

    public DoubleLinkList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void Add(T element)
    {
        Node newNode = new Node(element);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail!.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        count++;
    }

    public int IndexOf(T element)
    {
        Node? current = head;
        int index = 0;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, element))
            {
                return index;
            }
            current = current.Next;
            index++;
        }
        return -1;
    }

    public bool Contains(T element) => IndexOf(element) != -1;

    public void Insert(int index, T element)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node newNode = new Node(element);
        if (index == 0)
        {
            newNode.Next = head;
            if (head != null) head.Prev = newNode;
            head = newNode;
            if (tail == null) tail = newNode;
        }
        else if (index == count)
        {
            Add(element);
            return;
        }
        else
        {
            Node current = head!;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }
            newNode.Next = current.Next;
            newNode.Prev = current;
            if (current.Next != null) current.Next.Prev = newNode;
            current.Next = newNode;
        }
        count++;
    }

    public void Remove(T element)
    {
        Node? current = head;
        while (current != null && !EqualityComparer<T>.Default.Equals(current.Data, element))
        {
            current = current.Next;
        }

        if (current == null) return;

        if (current.Prev != null) current.Prev.Next = current.Next;
        else head = current.Next;

        if (current.Next != null) current.Next.Prev = current.Prev;
        else tail = current.Prev;

        count--;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (index == 0)
        {
            head = head!.Next;
            if (head != null) head.Prev = null;
            else tail = null;
        }
        else
        {
            Node current = head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            if (current.Prev != null) current.Prev.Next = current.Next;
            if (current.Next != null) current.Next.Prev = current.Prev;
            if (current == tail) tail = current.Prev;
        }
        count--;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            return current.Data;
        }
        set
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            current.Data = value;
        }
    }

    public int Count => count;
}