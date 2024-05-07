namespace Advanced_Lesson_5;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        // Creating dependancis and refencing a class lybrary anables us to use classes from unrelated projects
        ClassLibrary_Advanced_Lesson_5.firstBaseClass baseclass = new ClassLibrary_Advanced_Lesson_5.firstBaseClass();
        ClassLibrary_Advanced_Lesson_5.firstBaseClass baseclass2 = new();
    }

}

public class firstClass
{
    public virtual void method1()
    {
        Console.WriteLine("Method 1 respons");
    }
    private void method2()
    {
        Console.WriteLine("Method 2 respons");
    }

    protected void method3()
    {
        Console.WriteLine("Method 3 respons");
    }
}

public class secondClass : firstClass
{
    public override void method1()
    {
        Console.WriteLine("Method 1 respons on secondclass");
        method3();
    }

    public void useclassmethods()
    {
        //       method2(); private methods cannot be used outside the class
        method3(); // protected methods can only be used in class or inherited classes

    }




}