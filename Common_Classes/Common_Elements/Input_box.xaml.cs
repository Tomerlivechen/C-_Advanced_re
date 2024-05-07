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
using System.Xml.Linq;

namespace Common_Classes.Common_Elements
{
    /// <summary>
    /// Interaction logic for Input_box.xaml
    /// </summary>
    public partial class Input_box : Window
    {
        public Input_box(
            int number_of_field,
            string title,
            Input_box_field Input_field1,
            Input_box_field Input_field2 = null,
            Input_box_field Input_field3 = null
        )
        {
            InitializeComponent();
            Title.Text = title.ToString();

            switch (number_of_field)
            {
                case 3:
                    Field3_lable.Content = Input_field3.Input_label.ToString();
                    Field3_lable.Visibility = Visibility.Visible;
                    Field3_TB.Visibility = Visibility.Visible;
                    Field2_lable.Content = Input_field2.Input_label.ToString();
                    Field2_lable.Visibility = Visibility.Visible;
                    Field2_TB.Visibility = Visibility.Visible;
                    this.Height = 390;
                    break;
                case 2:
                    Field2_lable.Content = Input_field2.Input_label.ToString();
                    Field2_lable.Visibility = Visibility.Visible;
                    Field2_TB.Visibility = Visibility.Visible;
                    Field1_lable.Content = Input_field1.Input_label.ToString(); ;
                    this.Height = 300;
                    break;
                case 1:
                    Field1_lable.Content = Input_field1.Input_label.ToString();
                    this.Height = 220;
                    break;
                default:
                    break;
            }
        }
            public int getNumberOfField()
            {
            if (Field3_lable.Visibility == Visibility.Visible)
            {
                return 3;
            }
            if (Field2_lable.Visibility == Visibility.Visible)
            {
                return 2;
            }
            if (Field1_lable.Visibility == Visibility.Visible)
            {
                return 1;
            }
            return 0;
        }
        

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<string> fields = new List<string>();
            int number_of_field = getNumberOfField();
            switch (number_of_field)
            {
                case 3:
                    fields.Add(Field1_TB.Text);
                    fields.Add(Field2_TB.Text);
                    fields.Add(Field3_TB.Text);
                    break;
                case 2:
                    fields.Add(Field1_TB.Text);
                    fields.Add(Field2_TB.Text);
                    break;
                case 1:
                    fields.Add(Field1_TB.Text);
                    break;
                default:
                    break;
            }
            UniversalVars.SetInputBoxReturn(fields);
            Close();

        }
    }
}
