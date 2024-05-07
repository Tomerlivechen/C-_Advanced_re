using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Recursive
{
    /// <summary>
    /// Interaction logic for RecursiveFolder.xaml
    /// </summary>
    public partial class RecursiveFolder : Window
    {
        public RecursiveFolder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.ShowDialog();

            SelectedRoot.Text = openFolderDialog.FolderName;


            TV_data.Items.Clear();

            TreeViewItem root = BuildDirectory(openFolderDialog.FolderName);
            TV_data.Items.Add(root);
        }


        public TreeViewItem BuildDirectory(string folderName)
        {
            TreeViewItem result = new TreeViewItem();
            result.Header = folderName;
            DirectoryInfo info = new DirectoryInfo(folderName);
            foreach (var directory in info.GetDirectories())
            {
                result.Items.Add(BuildDirectory(directory.FullName));
            }
            return result;
        }
    }
}
