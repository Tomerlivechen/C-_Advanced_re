using System.Text;

namespace Advanced_Lesson_3_HW
{
    internal class Program
    {
        public delegate int AskForTemp(string message, int low, int high);

        static void Main(string[] args)
        {
            TemperatureMonitor monitor = new TemperatureMonitor();

            monitor.HighTemperature += new Notify(warningupateformat);
            monitor.Lowtemperature += new Notify(lowwarningupateformat);
            monitor.TemperatureUpdate += new Notify(upateformat);

            AskForTemp askfortemp = new AskForTemp(FoolProofing.RequestANumber);
            string RequestMin = "Minimum Temp";
            string RequestMax = "Maximum Temp";

            monitor.StartMonitor(askfortemp(RequestMin, -90, 60), askfortemp(RequestMax, -90, 60));

            void upateformat(string message, int temp)
            {
                FoolProofing.greentext($"the temperature is {temp} and {message}", true);
            }
            void warningupateformat(string message, int temp)
            {
                FoolProofing.redtext($"the temperature is {temp} and {message}", true);
            }
            void lowwarningupateformat(string message, int temp)
            {
                FoolProofing.Bluetext($"the temperature is {temp} and {message}", true);
            }
        }
    }
}

/* hw
 *
 *1.Build a class called TemperatureMonitor
 * 2.The class has a Start method that:
 *runs in an endless loop
 *		pauses for 200 milliseconds
 *		generates a random number (logical temperature ranges)
 *
 * 3. If the temperature is high (for ex. over 40degrees)
 *		raise the "HighTemperature" alert
 * 4. If it is low (below 20D) call the "Low temperature alert
 * 5. for every temperature (no mater how high or low call
 *		the "TemperatureUpdate" event.
 *
 * 6. Create an instance of the class, and register for all events
 *
 * 7. run and enjoy.
 *
 */
