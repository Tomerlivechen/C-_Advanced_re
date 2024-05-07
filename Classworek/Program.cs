namespace Classworek
{
    internal class Program
    {
        public delegate void MenuAction();

        static void Main(string[] args)
        {


            static void ShowGreeting()
            {
                Console.WriteLine("Hello");
            }
            static void DisplayDate()
            {
                string date = DateTime.Now.ToShortDateString();
                Console.WriteLine(date);
            }
            static void DisplayTime()
            {
                string time = DateTime.Now.ToShortTimeString();
                Console.WriteLine(time);
            }

            Dictionary<int, MenuAction> delegate1Dictionary = new Dictionary<int, MenuAction>();
            delegate1Dictionary.Add(1, new MenuAction(ShowGreeting));
            delegate1Dictionary.Add(2, new MenuAction(DisplayDate));
            delegate1Dictionary.Add(3, new MenuAction(DisplayTime));

            string prompt1 = "Choos a function:\n\t 1. ShowGreeting \n\t 2. DisplayDate \n\t 3. DisplayTime \n\t 4. Exit ";

            int respons;

            do
            {
                respons = FoolProofing.RequestANumber(prompt1, 1, 4);
                if (respons > 0 && respons < 4)
                {
                    delegate1Dictionary[respons].Invoke();
                }

            } while (respons < 4);

        }
    }
}
