using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Common_Classes;
namespace First_project;

public class Project: IProjectMeta
{

    public string Name { get; set; } = "First Project";


    public BitmapImage Image
    {
        get
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/IndexImage.png");
            return new BitmapImage(uri);

        }
    }
    //   public BitmapImage Image => new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Resources/IndexImage1.png", UriKind.Absolute));

    public void Run()
    {
        MainWindow window = new MainWindow();
        window.ShowDialog();
    }

}
