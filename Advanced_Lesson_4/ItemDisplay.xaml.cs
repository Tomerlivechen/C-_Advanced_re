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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Advanced_Lesson_4
{
    /// <summary>
    /// Interaction logic for ItemDisplay.xaml
    /// </summary>
    public partial class ItemDisplay : Window
    {
        public ItemDisplay()
        {
            InitializeComponent();
        }

        public ItemDisplay(Subclass item) : this()
        {
            TextBoxName.Text = item.Name;
            TextBoxDescription.Text = item.Description;
            TextBoxPriority.Text = (item.Priority).ToString();
            TextBoxActive.Text = item.Active ? "Active" : "Disabled";
        }
    }
}
