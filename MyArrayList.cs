using System;

internal class MyArrayList<T>
{
    private T[] elementData;
    private int size;

    public MyArrayList()
    {
        elementData = new T[0];
        size = 0;
    }
    public MyArrayList(T[] array)
    {
        elementData = (T[])array.Clone();
        size = array.Length;
    }
    public MyArrayList(uint capacity)
    {
        size = 0;
        elementData = new T[capacity];
    }

    public void AddElement(T element)
    {
        if (size == elementData.Length)
        {
            T[] newArray = new T[(int)(size * 1.5) + 1];
            for (int i = 0; i < size; i++) newArray[i] = elementData[i];
            elementData = newArray;
        }
        elementData[size] = element;
        size++;
    }
    public void AddAll(params T[] array)
    {
        foreach (T element in array) AddElement(element);
    }

    public void Clear()
    {
        elementData = new T[0];
        size = 0;
    }
    public bool Contains(object obj)
    {
        foreach (T element in elementData)
        {
            if (element.Equals(obj)) return true;
        }
        return false;
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

    public void Remove(object obj)
    {
        for (int index = 0; index < size; index++)
        {
            if (Contains(obj))
            {
                for (int specIndex = index; specIndex < size - 1; specIndex++)
                {
                    elementData[specIndex] = elementData[specIndex + 1];
                }
                size--;
            }
        }
    }

    public void RemoveAll(params T[] array)
    {
        foreach (T element in array) Remove(element);
    }

    public void RetainAll(params T[] array)
    {
        foreach (T element in array)
        {
            if (!Contains(element)) Remove(element);
        }
    }

    public int Size() => size;
    public T[] ToArray()
    {
        T[] result = new T[size];
        for (int index = 0; index < size; index++)
        {
            result[index] = elementData[index];
        }
        return result;
    }


    public T[] ToArray(ref T[] array)
    {
        if (array == null)
            ToArray();
        if (array.Length < size)
            throw new ArgumentOutOfRangeException("length");

        for (int index = 0; index < size; index++)
        {
            array[index] = elementData[index];
        }
        return array;
    }

    public void Add(uint index, T element)
    {
        if (index >= size)
            throw new ArgumentOutOfRangeException("index");

        if (size == elementData.Length)
        {
            T[] array = new T[(int)(size * 1.5) + 1];
            for (int i = 0; i < size; i++) array[i] = elementData[i];
            elementData = array;
        }

        for (int i = size; i > index; i--)
        {
            elementData[i] = elementData[i - 1];
        }
        elementData[index] = element;
        size++;
    }

    public void AddAll(uint index, T[] array)
    {
        if (index >= size)
            throw new ArgumentOutOfRangeException("index");

        if (size + array.Length > elementData.Length)
        {
            T[] tempArray = new T[(int)(size * 1.5) + array.Length];
            for (int i = 0; i < size; i++) array[i] = elementData[i];
            elementData = tempArray;
        }

        for (int i = 0; i < array.Length; i++)
        {
            elementData[index + i + array.Length] = elementData[index + i];
            elementData[index + i] = array[i];
            size++;
        }
    }

    public object Get(uint index)
    {
        if (index >= size)
            throw new ArgumentOutOfRangeException("index");

        return elementData[index];
    }

    public int IndexOf(object obj)
    {
        for (int i = 0; i < size; i++)
            if (elementData[i].Equals(obj)) return i;
        return -1;
    }

    public int LastIndexOf(object obj)
    {
        for (int i = elementData.GetUpperBound(0); i >= 0; i--)
            if (elementData[i].Equals(obj)) return i;
        return -1;
    }

    public T Remove(uint index)
    {
        if (index >= size) throw new ArgumentOutOfRangeException("index");
        T element = elementData[index];
        for (uint ind = index; ind < size - 1; ind++) elementData[ind] = elementData[ind + 1];
        elementData[index] = default;
        size--;
        return element;
    }

    public void Set(uint index, T element)
    {
        if (index >= size) throw new ArgumentOutOfRangeException("index");
        if (element == null) throw new ArgumentNullException(element.ToString());
        elementData[index] = element;
    }

    public MyArrayList<T> SubList(uint fromIndex, uint toIndex)
    {
        if (fromIndex >= size) throw new ArgumentOutOfRangeException("fromindex");
        if (toIndex > size) throw new ArgumentOutOfRangeException("toindex");
        MyArrayList<T> array = new MyArrayList<T>(toIndex - fromIndex);
        for (int i = 0; i < array.size; i++)
            array.AddElement(elementData[fromIndex + i]);
        return array;
    }

    public void Print()
    {
        foreach (T element in elementData)
            Console.WriteLine(element.ToString());
        Console.WriteLine();
    }
}