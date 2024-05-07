using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegats_events
{
      public delegate void Notify(string message);
        public delegate void Update(int precentage, string message);
    internal class Logic1
    {


        public event Notify EventName;
        public event Update Loeading;

        public void Startday(){
            Console.WriteLine("Day has started");
            Thread.Sleep(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                OnLoeading(i * 10, "day passed");
            }

            OnEventName("the event has happend");
}

        private void OnLoeading(int load, string message)
        {
            if (Loeading == null)
            {
                return;
            }
            Loeading(load,message);
        }


        private void OnEventName(string message)
        {
            if (EventName == null)
            {
                return;
            }
            EventName(message);
        }
    }

    
}
