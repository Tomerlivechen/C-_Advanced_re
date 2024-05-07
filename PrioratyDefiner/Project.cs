using Common_Classes;
using PriorityDefiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PrioratyDefiner
{
    public class Project : IProjectMeta
    {
        public string Name { get; set; } = "Prioraty Definer";

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
            TaskLists window = new TaskLists();
            window.ShowDialog();
        }
    }
}
