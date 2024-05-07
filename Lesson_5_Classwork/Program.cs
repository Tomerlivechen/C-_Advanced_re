namespace Lesson_5_Classwork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConsoleLogger<int> intlogger = new ConsoleLogger<int>();
            intlogger.insert(5);
            intlogger.log();
            ConsoleLogger<string> stringlogger = new ConsoleLogger<string>();
            stringlogger.insert("5") ;
            stringlogger.log();
            ConsoleLogger<object> objlogger = new ConsoleLogger<object>();
            objlogger.insert(5);
            objlogger.log();
            ConsoleLogger<double> doublelogger = new ConsoleLogger<double>();
            doublelogger.insert(5.0);
            doublelogger.log();


        }
    }
}
