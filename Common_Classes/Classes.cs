using System;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Common_Classes;

public class Class1 { }

public class My_Message_Box_Classes
{
    public static MessageBoxResult Show(MYMessageBoxobject messagebox)
    {
        Window window = new Window
        {
            Title = messagebox.caption,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            ResizeMode = ResizeMode.NoResize,
            SizeToContent = SizeToContent.WidthAndHeight,
            Content = messagebox.message
        };
        StackPanel buttonPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 10, 0, 0)
        };
        int index = -1;
        foreach (string button in messagebox.buttontext)
        {
            index++;
            Button setButton = new Button { Content = button };

            setButton.Click += (sender, e) =>
            {
                //                messagebox.buttonCommands[index]?.DynamicInvoke();
                window.DialogResult = messagebox.buttonRespons[index];
                window.Close();
            };
            buttonPanel.Children.Add(setButton);
        }
        window.Content = new StackPanel
        {
            Children =
            {
                new TextBlock { Text = messagebox.message, Margin = new Thickness(10) },
                buttonPanel
            }
        };
        window.Icon = messagebox.image;
        window.ShowDialog();

        return (bool)window.DialogResult.HasValue ? MessageBoxResult.OK : MessageBoxResult.None;
    }

    public class MYMessageBoxobject
    {
        static Uri imageDefault = new Uri(
            $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Resources/Error.png"
        );
        public string message { get; set; } = "Defalt message";
        public string caption { get; set; } = "Defalt message";
        public string[] buttontext { get; set; } = { "OK" };
        public bool[] buttonRespons { get; set; } = { false };
        public BitmapImage image { get; set; } = new BitmapImage(imageDefault);

        public MYMessageBoxobject(string _caption, string _message)
        {
            message = _message;
            caption = _caption;
        }

        public MYMessageBoxobject() { }

        public MYMessageBoxobject(
            string _caption,
            string _message,
            string[] _buttonText,
            bool[] _buttonRespons,
            Delegate[] delegates
        )
        {
            message = _message;
            caption = _caption;
            buttontext = _buttonText;
            buttonRespons = _buttonRespons;
        }
    }
}

public class Input_box_field
{
    public string Input_label {  get; set; } 
}

public static class UniversalVars
{
    public static List<string> inputBoxReturn { get; set; }

    public static void SetInputBoxReturn(List<string> inputReturn) { inputBoxReturn = inputReturn; }

}

public class HighScore_Total
{
    public HighScore_Set High_Score_12 { get; set; }
    public HighScore_Set High_Score_18 { get; set; }
    public HighScore_Set High_Score_24 { get; set; }
    public HighScore_Set High_Score_30 { get; set; }
    public HighScore_Set High_Score_36 { get; set; }
    public HighScore_Set High_Score_48 { get; set; }
    public HighScore_Total()
    {
        High_Score_12 = new HighScore_Set { card_Number = 12 };
        High_Score_18 = new HighScore_Set { card_Number = 18 };
        High_Score_24 = new HighScore_Set { card_Number = 24 };
        High_Score_30 = new HighScore_Set { card_Number = 30 };
        High_Score_36 = new HighScore_Set { card_Number = 36 };
        High_Score_48 = new HighScore_Set { card_Number = 48 };
    }
}

public class HighScore_Total_Frogger
{
    public HighScore_Set_Frogger Difficalty_1 { get; set; }
    public HighScore_Set_Frogger Difficalty_2 { get; set; }
    public HighScore_Set_Frogger Difficalty_3 { get; set; }
    public HighScore_Set_Frogger Difficalty_4 { get; set; }
    public HighScore_Set_Frogger Difficalty_5 { get; set; }
    public HighScore_Set_Frogger Difficalty_6 { get; set; }
    public HighScore_Set_Frogger Difficalty_7 { get; set; }
    public HighScore_Total_Frogger()
    {
        Difficalty_1 = new HighScore_Set_Frogger { Difficalty = "Piece of Cake" };
        Difficalty_2 = new HighScore_Set_Frogger { Difficalty = "Very Easy" };
        Difficalty_3 = new HighScore_Set_Frogger { Difficalty = "Easy" };
        Difficalty_4 = new HighScore_Set_Frogger { Difficalty = "Moderate" };
        Difficalty_5 = new HighScore_Set_Frogger { Difficalty = "Hard" };
        Difficalty_6 = new HighScore_Set_Frogger { Difficalty = "Very Hard" };
        Difficalty_7 = new HighScore_Set_Frogger { Difficalty = "Near Impossible" };
    }
}

public class HighScore_Player
{
    public int time_complete { get; set; }
    public string player_Name { get; set; } = "";
}
public class HighScore_Set
{
    public int card_Number { get; set; }
    public List<HighScore_Player> player_list { get; set; }

    public HighScore_Set()
    {
        player_list = new List<HighScore_Player>();
    }

    public void AddPlayer(HighScore_Player player)
    {
        player_list.Add(player);
        SortPlayers();
    }

    private void SortPlayers()
    {
        player_list = player_list.OrderBy(player => player.time_complete).ToList();
    }
}

public class HighScore_Set_Frogger
{
    public string Difficalty { get; set; }
    public List<HighScore_Player> player_list { get; set; }

    public HighScore_Set_Frogger()
    {
        player_list = new List<HighScore_Player>();
    }

    public void AddPlayer(HighScore_Player player)
    {
        player_list.Add(player);
        SortPlayers();
    }

    private void SortPlayers()
    {
        player_list = player_list.OrderBy(player => player.time_complete).ToList();
    }
}
public static class Message_Box_Classes
{
    public static int DisplayMessageBox(string message, string caption)
    {
        CustumMessageBox messageBox = new CustumMessageBox();

        MessageBoxResult result = messageBox.Show(
            message,
            caption,
            MessageBoxButton.YesNo,
            MessageBoxImage.Question
        );

        if (result == MessageBoxResult.Yes)
        {
            return 1;
        }
        else if (result == MessageBoxResult.No)
        {
            return 2;
        }
        return 0;
    }

    public static string PiorityMesageBox(string Object1, string Object2)
    {
        CustumMessageBox messageBox = new CustumMessageBox();

        string message = $"Is {Object1} of higher priority than {Object2} ?";
        string caption = "Priority Qestion";
        MessageBoxResult result = messageBox.Show(
            message,
            caption,
            MessageBoxButton.YesNo,
            MessageBoxImage.Question
        );

        if (result == MessageBoxResult.Yes)
        {
            return Object1;
        }
        else if (result == MessageBoxResult.No)
        {
            return Object2;
        }
        return null;
    }
}

public class CustumMessageBox
{
    public MessageBoxResult Show(
        string messageBoxText,
        string caption,
        MessageBoxButton button,
        MessageBoxImage icon
    )
    {
        MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

        return result;
    }
}

public class MyTimer
{
    DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };
    //    timer.Tick += (sender, e) => {timer.Stop() }
    //        timer.Start();
}
