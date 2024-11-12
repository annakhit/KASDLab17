using System;
using System.Diagnostics;

public static class Speed
{
    public static double SpeedOfAddingToMyArrayList(int length)
    {
        double sum = 0;
        for (int i = 0; i < 20; i++)
        {
            MyArrayList<int> list = new MyArrayList<int>();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int j = 0; j < length; j++) list.AddElement(j);
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfAddingToMyLinkedList(int length)
    {
        double sum = 0;
        for (int i = 0; i < 20; i++)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int j = 0; j < length; j++) list.AddLast(j);
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfGettingToMyArrayList(int length)
    {
        double sum = 0;

        MyArrayList<int> list = new MyArrayList<int>();

        for (int j = 0; j < length; j++) list.AddElement(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (uint j = 0; j < 100; j++) list.Get((uint)(j * length / 100));
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfGettingToMyLinkedList(int length)
    {
        double sum = 0;

        MyLinkedList<int> list = new MyLinkedList<int>();

        for (int j = 0; j < length; j++) list.AddLast(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int j = 0; j < 100; j++) list.Get((j * length / 100));
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfSettingToMyArrayList(int length)
    {
        double sum = 0;

        MyArrayList<int> list = new MyArrayList<int>();

        for (int j = 0; j < length; j++) list.AddElement(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (uint j = 0; j < 100; j++) list.Set((uint)(j * length / 100), 0);
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfSettingToMyLinkedList(int length)
    {
        double sum = 0;

        MyLinkedList<int> list = new MyLinkedList<int>();

        for (int j = 0; j < length; j++) list.AddLast(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int j = 0; j < 100; j++) list.Set((j * length / 100), 0);
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfIndexAddingToMyArrayList(int length)
    {
        double sum = 0;

        MyArrayList<int> list = new MyArrayList<int>();

        for (int j = 0; j < length; j++) list.AddElement(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (uint j = 0; j < 100; j++) list.Add((uint)(j * length / 100), 0);
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfIndexAddingToMyLinkedList(int length)
    {
        double sum = 0;

        MyLinkedList<int> list = new MyLinkedList<int>();

        for (int j = 0; j < length; j++) list.AddLast(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int j = 0; j < 100; j++) list.Add((j * length / 100), 0);
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfRemovingToMyArrayList(int length)
    {
        double sum = 0;

        MyArrayList<int> list = new MyArrayList<int>();

        for (int j = 0; j < length + 200; j++) list.AddElement(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (uint j = 0; j < 10; j++) list.Remove((uint)(j * length / 10));
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }

    public static double SpeedOfRemovingToMyLinkedList(int length)
    {
        double sum = 0;

        MyLinkedList<int> list = new MyLinkedList<int>();

        for (int j = 0; j < length + 200; j++) list.AddLast(j);

        for (int i = 0; i < 20; i++)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int j = 0; j < 9; j++) list.Remove(j * length / 10);
            timer.Stop();
            sum += timer.ElapsedMilliseconds;
        }

        return sum;
    }
}