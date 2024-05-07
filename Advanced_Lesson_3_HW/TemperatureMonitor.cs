using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_HW
{
    public delegate void Notify(string message, int temp);

    internal class TemperatureMonitor
    {
        public event Notify HighTemperature;
        public event Notify Lowtemperature;
        public event Notify TemperatureUpdate;

        public void StartMonitor(int low, int high)
        {
            Random random = new Random();
            while (true)
            {
                int temp = random.Next(-90, 60);
                Thread.Sleep(200);
                if (temp > high)
                {
                    OnHighTemperature(temp);
                }
                else if (temp < low)
                {
                    OnLowtemperature(temp);
                }
                else
                {
                    OnTemperatureUpdate(temp);
                }
            }
        }

        private void OnHighTemperature(int temp)
        {
            if (HighTemperature == null)
            {
                return;
            }
            HighTemperature("Its too damn high", temp);
        }

        private void OnLowtemperature(int temp)
        {
            if (Lowtemperature == null)
            {
                return;
            }
            Lowtemperature("Its Cold", temp);
        }

        private void OnTemperatureUpdate(int temp)
        {
            if (TemperatureUpdate == null)
            {
                return;
            }
            TemperatureUpdate("all it well ", temp);
        }
    }
}
