namespace BulkFilesRenamer.Helpers;

interface ILinkedListManager<T>
{
    LinkedList<T> Items { get; }
    bool MoveUp(int index);
    bool MoveDown(int index);
    bool MoveToTop(int index);
    bool MoveToBottom(int index);
    bool RemoveAt(int index);
    void Reset(IEnumerable<T> items);
    void Clear();
}

class LinkedListManager<T> : ILinkedListManager<T>
{
    LinkedList<T> items;
    public LinkedList<T> Items => items;

    public LinkedListManager(IEnumerable<T> items)
    {
        this.items = new LinkedList<T>(items.ToList());
    }

    public bool MoveUp(int index)
    {
        if (index > 0 && index < items.Count)
        {
            var currentNode = GetNodeAtIndex(index);
            var previousNode = currentNode.Previous;
            items.Remove(currentNode);
            items.AddBefore(previousNode, currentNode);
            return true;
        }

        return false;
    }

    public bool MoveDown(int index)
    {
        if (index >= 0 && index < items.Count - 1)
        {
            var currentNode = GetNodeAtIndex(index);
            var nextNode = currentNode.Next;
            items.Remove(currentNode);
            items.AddAfter(nextNode, currentNode);
            return true;
        }

        return false;
    }

    public bool MoveToTop(int index)
    {
        if (index > 0 && index < items.Count)
        {
            var currentNode = GetNodeAtIndex(index);
            items.Remove(currentNode);
            items.AddFirst(currentNode);
            return true;
        }

        return false;
    }

    public bool MoveToBottom(int index)
    {
        if (index >= 0 && index < items.Count - 1)
        {
            var currentNode = GetNodeAtIndex(index);
            items.Remove(currentNode);
            items.AddLast(currentNode);
            return true;
        }

        return false;
    }

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= Items.Count)
        {
            return false;
        }

        LinkedListNode<T> nodeToRemove = GetNodeAtIndex(index);
        Items.Remove(nodeToRemove);
        return true;
    }

    public void Reset(IEnumerable<T> items)
    {
        this.items = new LinkedList<T>(items.ToList());
    }

    public void Clear()
    {
        items.Clear();
    }

    private LinkedListNode<T> GetNodeAtIndex(int index)
    {
        var currentNode = items.First;
        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }
}
