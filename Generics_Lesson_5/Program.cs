namespace Generics_Lesson_5;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}


public class Mystack
{
    private readonly double[] _items;
    private int _currentIndex;
    public Mystack()
    {
        _items = new double[10];
        _currentIndex = -1;
    }

    public void push(double item)
    {
        _items[++_currentIndex] = item;
    }
    public double pop() => _items[_currentIndex--];
    

    public int getCount()
    {
        return _currentIndex+1;
    }
}

public class MyGeneralizedStack
{
    private readonly Object[] _items;
    private int _currentIndex;
    public MyGeneralizedStack()
    {
        _items = new Object[10];
        _currentIndex = -1;
    }

    public void push(Object item)
    {
        _items[++_currentIndex] = item;
    }
    public Object Pop() => _items[_currentIndex--];


    public int getCount()
    {
        return _currentIndex + 1;
    }
}
// TypePlaceHolder is oftern replaced with the letter T
// This enables to cast any type in to the existing class without changing the class itself
public class MyGenericStack<TypePlaceHolder>
{
    private readonly TypePlaceHolder[] _items;
    private int _currentIndex;
    public MyGenericStack()
    {
        _items = new TypePlaceHolder[10];
        _currentIndex = -1;
    }

    public void push(TypePlaceHolder item)
    {
        _items[++_currentIndex] = item;
    }
    public TypePlaceHolder Pop() => _items[_currentIndex--];


    public int getCount()
    {
        return _currentIndex + 1;
    }
}