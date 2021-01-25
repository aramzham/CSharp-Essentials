using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        var rootNode = new ListNode<int>() { 10, 20, 30 }; // in order to write like this the class should inherit from IEnumerable and have an Add() function
    }
}

public class ListNode<T> : IEnumerable, IReadOnlyCollection<T>, IReadOnlyList<T>
{
    public ListNode<T> Add(int value)
    {
        return null;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // IReadOnlyCollection<T> has only Count property
    public int Count { get; }

    // IReadOnlyList<T> has only indexer
    public T this[int index] => throw new NotImplementedException();
}
