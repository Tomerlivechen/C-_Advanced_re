using Common_Classes;
using First_project;
using Project_Gallery.Controles;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrioratyDefiner;

namespace Project_Gallery;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IProjectMeta[] Projects = new IProjectMeta[]
    {
        new First_project.Project(),
        new PrioratyDefiner.Project(),
        new System_manager.Project(),
        new Memory_game.Project(),

    };

    public MainWindow()
    {
        InitializeComponent();
        InitializProjectbuttons();
    }

    private void InitializProjectbuttons()
    {
        foreach (var project in Projects)
        {
            int i = 0;
            //Button button = new Button()
            //{
            //    Width = 100, Height = 100, Margin= new Thickness (10)

            //};

            //StackPanel panel = new StackPanel();
            //panel.Orientation = Orientation.Vertical;

            //Image image = new Image();

            //panel.Children.Add(image);

            //button.Content = panel;
            ProjectButton button = new ProjectButton(project)
            {
                Margin = new Thickness(10),
                Height = 100,
                Width = 100,
            };
            ProjectButtons.Children.Add(button);
        }
    }
}
