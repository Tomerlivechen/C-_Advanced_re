using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Speed_Racer.Resources.Controls
{
    /// <summary>
    /// Interaction logic for Fule_Tank.xaml
    /// </summary>
    public partial class Fule_Tank : UserControl
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(10) };
        public int direction = -1;
        public Fule_Tank()
        {

            InitializeComponent();
            timer1.Start();
            timer1.Tick += moveTank;
        }
        
        public void moveTank(object sender, EventArgs e)
        {
           double topPos = Canvas.GetTop(tank);
            if (topPos >= 16) {
                direction = -1;
            }
            if (topPos <= 0)
            {
                direction = 1;
            }
            Canvas.SetTop(tank, topPos + 0.3 * direction);
        }
    }
}
