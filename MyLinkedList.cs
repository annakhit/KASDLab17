using System;
using System.Collections.Generic;

public class MyLinkedList<T> where T : IComparable<T>
{
    internal MyLinkedListNode<T> head;
    private int size = 0;

    public MyLinkedList() { }

    public MyLinkedList(IEnumerable<T> collection)
    {
        foreach (T item in collection) AddLast(item);
    }

    public MyLinkedListNode<T> AddLast(T value)
    {
        MyLinkedListNode<T> result = new MyLinkedListNode<T>(value);
        if (head == null) InsertNodeToEmptyList(result);
        else
        {
            InsertNodeBefore(head, result);
        }
        return result;
    }

    public MyLinkedListNode<T> AddFirst(T value)  // Add() Push()
    {
        MyLinkedListNode<T> result = new MyLinkedListNode<T>(value);
        if (head == null) InsertNodeToEmptyList(result);
        else
        {
            InsertNodeBefore(head, result);
            head = result;
        }
        return result;
    }

    public void AddAll(IEnumerable<T> collection)
    {
        foreach (T item in collection) AddLast(item);
    }

    public void Clear()
    {
        head = null;
        size = 0;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public bool ContainsAll(params T[] array)
    {
        foreach (T element in array)
        {
            if (!Contains(element)) return false;
        }
        return true;
    }

    public bool IsEmpty() => size == 0;

    public void RemoveValue(T value)
    {
        MyLinkedListNode<T> node = Find(value);
        if (node != null) RemoveNode(node);
    }

    public void RemoveAll(params T[] array)
    {
        foreach (T element in array) RemoveValue(element);
    }

    public void RetainAll(params T[] array)
    {
        foreach (T element in array)
        {
            if (!Contains(element)) RemoveValue(element);
        }
    }

    public int Size() => size;

    public T[] ToArray()
    {
        MyLinkedListNode<T> node = head;
        T[] array = new T[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = node.item;
            node = node.next;
        }
        return array;
    }

    public T[] ToArray(ref T[] array)
    {
        T[] elements = ToArray();
        if (array == null) return elements;

        if (array.Length < elements.Length)
            throw new ArgumentOutOfRangeException();

        for (int index = 0; index < elements.Length; index++)
        {
            array[index] = elements[index];
        }
        return array;
    }

    public MyLinkedListNode<T> Add(int index, T value)
    {
        MyLinkedListNode<T> node = GetNode(index);
        MyLinkedListNode<T> result = new MyLinkedListNode<T>(value);
        InsertNodeBefore(node, result);
        if (node == head) head = result;
        return result;
    }

    public void AddAll(int index, IEnumerable<T> collection)
    {
        foreach (T item in collection) Add(index, item);
    }

    public T Get(int index)
    {
        MyLinkedListNode<T> node = GetNode(index);
        return node.item;
    }

    public int IndexOf(T value)
    {
        MyLinkedListNode<T> node = head;

        int index = -1;

        for (int i = 0; i < size; i++)
        {
            if (value.CompareTo(node.item) == 0)
            {
                index = i;
                break;
            }
            node = node.next;
        }

        return index;
    }

    public int LastIndexOf(T value)
    {
        MyLinkedListNode<T> node = head.prev;

        int index = -1;

        for (int i = size; i > 0; i--)
        {
            if (value.CompareTo(node.item) == 0)
            {
                index = i - 1;
                break;
            }
            node = node.prev;
        }

        return index;
    }

    public T Remove(int index)
    {
        MyLinkedListNode<T> node = GetNode(index);
        RemoveNode(node);
        return node.item;
    }

    public void Set(int index, T value)
    {
        MyLinkedListNode<T> node = GetNode(index);
        node.item = value;
    }

    public T[] SubList(int fromIndex, int toIndex)
    {
        if (fromIndex >= toIndex) throw new ArgumentOutOfRangeException();
        T[] array = new T[toIndex - fromIndex];
        Array.Copy(ToArray(), fromIndex, array, 0, toIndex - fromIndex);
        return array;
    }

    public T Peek() => head.item; // Element() GetFirst() PeekFirst()

    public T GetLast() // PeekLast()
    {
        if (head == null) return default;
        return head.prev.item;
    }

    public T Pull() // PollFirst() RemoveFirst()
    {
        MyLinkedListNode<T> node = head;
        if (node == null) return default;
        RemoveNode(node);
        return node.item;
    }

    public T Pop() // PollLast() RemoveLast()
    {
        if (head == null) return default;
        MyLinkedListNode<T> node = head.prev;
        RemoveNode(node);
        return node.item;
    }

    public bool RemoveLastOccurrence(T value)
    {
        int index = LastIndexOf(value);
        if (index == -1) return false;
        Remove(index);
        return true;
    }

    public bool RemoveFirstOccurrence(T value)
    {
        int index = IndexOf(value);
        if (index == -1) return false;
        Remove(index);
        return true;
    }

    private MyLinkedListNode<T> GetNode(int index)
    {
        if (index >= size) throw new ArgumentOutOfRangeException();

        MyLinkedListNode<T> node = head;

        for (int i = 0; i < index; i++) node = node.next;

        return node;
    }

    private void RemoveNode(MyLinkedListNode<T> node)
    {
        if (node.next == node) head = null;
        else
        {
            node.next.prev = node.prev;
            node.prev.next = node.next;
            if (head == node) head = node.next;
        }
        size--;
    }

    private void InsertNodeToEmptyList(MyLinkedListNode<T> newNode)
    {
        newNode.next = newNode;
        newNode.prev = newNode;
        head = newNode;
        size++;
    }

    private void InsertNodeBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
        newNode.next = node;
        newNode.prev = node.prev;
        node.prev.next = newNode;
        node.prev = newNode;
        size++;
    }

    private MyLinkedListNode<T> Find(T value)
    {
        MyLinkedListNode<T> node = head;
        if (node != null)
        {
            do
            {
                if (value.CompareTo(node.item) == 0) return node;
                node = node.next;
            } while (node != head);
        }
        return null;
    }

    public void Print()
    {
        Console.WriteLine(string.Join(" ", ToArray()));
    }
}