using System.Security.Cryptography.X509Certificates;

namespace Delegats_events
{
    internal class Program
    {
        public delegate void Delegate1(string message);

        static void Main(string[] args) { 



            static void printnumber(int number)
            {
                Console.WriteLine(number);
            }

            Timer timer = new Timer();

            timer.TimerTick += new TimerNotification(printnumber);

            timer.Start(10);


            Logic1 logic = new Logic1();

            logic.EventName += new Notify(DelFunction);
            logic.Loeading += new Update(DelFunction2);
            //deligate holds a referance for a method


            logic.Startday();

            Delegate1 mydel = new Delegate1(DelFunction);

            static void DelFunction (string text)
            {
                Console.WriteLine (text);
                Console.Beep ();
            }

            static void DelFunction2(int num, string text)
            {
                Console.WriteLine($"{num}% {text}");
                Console.Beep();
            }

        }

        private static void Timer_TimerTick(int number)
        {
            throw new NotImplementedException();
        }

        private static void Logic_Loeading(int precentage, string message)
        {
            throw new NotImplementedException();
        }
    }
}
