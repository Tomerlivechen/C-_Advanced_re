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
        new API_Animal_Pics.Project(),
        new API_hub.Project(),
        new Frogger.Project(),
        new Memory_game.Project(),
        new Taki_Game.Project(),
        new TickTackTow_WPF.Project(),
        new PrioratyDefiner.Project(),


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

            ProjectButton button = new ProjectButton(project)
            {
                Margin = new Thickness(10),
                Height = 150,
                Width = 150,
            };
            ProjectButtons.Children.Add(button);
        }
    }
}
