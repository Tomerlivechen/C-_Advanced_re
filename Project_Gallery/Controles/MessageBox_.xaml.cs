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
using static Common_Classes.Message_Box_Classes;
using static Common_Classes.My_Message_Box_Classes;

namespace Project_Gallery.Controles
{
    /// <summary>
    /// Interaction logic for MessageBox_.xaml
    /// </summary>
    public partial class MessageBox_ : UserControl
    {
        public MessageBox_(MYMessageBoxobject messageBoxData)
        {
            InitializeComponent();
            DataContext = messageBoxData;

            int index = -1;
            foreach (string button in messageBoxData.buttontext)
            {
                index++;
                Button setButton = new Button { Content = button };

                setButton.Click += (sender, e) =>
                {
//                    messageBoxData.buttonCommands[index]?.DynamicInvoke();
                };
                buttonPanel.Children.Add(setButton);
            }
        }
    }
}
