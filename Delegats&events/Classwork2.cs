using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegats_events
{
    public delegate void TimerNotification(int number);
    internal class Classwork2
    {




    }

    internal class Timer
    {
        public event TimerNotification TimerTick;
        public event TimerNotification TimerCompleted;


        public void Start(int number)
        {
            Console.WriteLine("Started");
            for (int i = 0; i < number; i++)
            {
 //               Console.WriteLine(i);
                Thread.Sleep(1000);
                OnTimerTick(i);
            }
            Console.WriteLine("Finished");
            OnTimerCompleted(number);
        }



        private void OnTimerTick(int number)
        {
            if (TimerTick == null)
            {
                return;
            }
            TimerTick(number);
        }

        private void OnTimerCompleted(int number)
        {
            if (TimerCompleted == null)
            {
                return;
            }
            TimerCompleted(number);
        }
    }



}


/*
 *
 * Step 1: create a delegate called "TimerNotification"
 * returns void and takes an integer
 *
 * Step 2: Create a Timer class
 * create 2 events using the delegate above:
 * TimerTick
 * TimerCompleted
 *
 * Step 3:
 * Add a function to the Timer class called "Start" that
 * takes an integer (time to run in seconds)
 * the function needs to loop the amount given in the parameter
 * each iteration sleep for 1000 milli seconds and then raise
 * the TimerTick event.
 * When the loop completes, call the TimerCompleted event.
 *
 * Step 4:
 * in the Main
 * create an instance of Timer
 * register for each of the events with a function suited
 * call the "Start" on the timer and run the code
 *
 * verify that you get the tick event notifications
 * and the completed
 *
 *
 *
 */