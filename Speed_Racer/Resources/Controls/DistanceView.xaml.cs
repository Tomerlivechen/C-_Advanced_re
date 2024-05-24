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

namespace Speed_Racer.Resources.Controls
{
    /// <summary>
    /// Interaction logic for DistanceView.xaml
    /// </summary>
    public partial class DistanceView : UserControl
    {
        public DistanceView()
        {
            InitializeComponent();
            road.Width = 400;
        }

        public void moveCar(double distance, double fulldistance)
        {
            double fullsize = road.ActualWidth;
            double position = (fulldistance-distance) / (fullsize / fulldistance);
            Canvas.SetLeft(Car, position);
            

        }
    }
}
