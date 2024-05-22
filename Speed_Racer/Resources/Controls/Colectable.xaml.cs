using System.Windows.Controls;
using System.Windows.Threading;

namespace Speed_Racer.Resources.Controls
{
    /// <summary>
    /// Interaction logic for Fule_Tank.xaml
    /// </summary>
    public partial class Colectable : UserControl
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(10) };
        public int direction = -1;
        public Colectable()
        {

            InitializeComponent();
            timer1.Start();
            timer1.Tick += moveTank;
        }

        public void moveTank(object sender, EventArgs e)
        {
            double topPos = Canvas.GetTop(image);
            if (topPos >= 16)
            {
                direction = -1;
            }
            if (topPos <= 0)
            {
                direction = 1;
            }
            Canvas.SetTop(image, topPos + 0.3 * direction);
        }
    }
}
