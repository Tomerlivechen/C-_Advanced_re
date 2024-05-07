using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Classwork;

internal class ClassWork
{
}


public class ConsoleLogger<T>
{
    public T _instance;

    public void log()
    {
        Console.WriteLine($"The console as logged a {typeof(T)} it's value is {_instance.ToString()}");
    }

    public void insert(T instance)
    {
        _instance = instance;
    }
}
// Further definitions of specific classes can but used by adding inheratance of classes or interfaces to use internal propertieas and limit them to specific classes that can be used in the generic class
public class MyRepository<T>
{
    private List<T> _list;

    public void Add(T item)
    {
        _list.Add(item);
    }
}