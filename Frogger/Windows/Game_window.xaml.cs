using Common_Classes;
using System.Reflection;
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
using System.Windows.Threading;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Frogger;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Game_window : Window
{
    public bool onlog = false;
    public int waterspeed = 7;
    public double difficaltyHolder = 0.1;
    public double difficalty = 0.1;
    public int timeDifficalty = 5;
    bool nightMare = false;
    public scoreKeeping scores = new scoreKeeping();
    public Game_window(double difficalty_Set)
    {
        difficaltyHolder = difficalty_Set / 10;
        difficalty = difficalty_Set / 10;
        if (difficalty >= 6)
        {
            nightMare=true;
        }
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        DispatcherTimer timer100 = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(timeDifficalty) };

        InitializeComponent();
        initialzeObjects();

        DispatcherTimer timer05 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };

        void Timed_100_Actions(object sender, EventArgs e)
        {
            MoveAllObjects();
            double[] position = Getposition(frog);
            FrogPosition.Text = $"{position[0]} x {position[1]}";
            SafeFrog(getWinPosition(position[1], position[0]));


            if (position[1] < 180 && position[1] >= 145 || position[1] < 110 && position[1] >= 75)
            {
                if (position[0] < 0) { Death(); }
                else { moveObject(frog, "Left", waterspeed); }
                //               else { MoveLeft(position[0]); }
            }
            if (position[1] < 145 && position[1] >= 110 || position[1] < 75 && position[1] >= 40)
            {
                if (position[0] > 610) { Death(); }
                else { moveObject(frog, "Right", waterspeed); }
                //               else { MoveRight(position[0]); }
            }

        }

        void Timed_05_Actions(object sender, EventArgs e)
        {




        }
        void Timed_1_Actions(object sender, EventArgs e)
        {

            GlobalVars.SetTimerCount();
            time.Text = GlobalVars.Timer_count.ToString();
            wins.Text = scores.Wins.ToString();
            lives.Text = scores.Lives.ToString();


            if (scores.Wins == 5 || scores.Lives < 0)
            {
                string reason = "";
                int respons = 0;
                
                if (scores.Lives < 0 && scores.Wins < 5) { respons = Message_Box_Classes.DisplayMessageBox($"You have lost\n Play again?", "Game Over"); }
                if (scores.Wins == 5) { respons = Message_Box_Classes.DisplayMessageBox($"You win, You have compleated the game in {GlobalVars.Timer_count} seconds\n Play again?", "Congratulations"); GlobalVars.AddHighScore((int)difficalty_Set, GlobalVars.Timer_count); }
                if (respons == 1)
                {
                    initialzeGame();
                    GlobalVars.ResetTimerCount();

                }
                else
                {
                    this.Close();
                }
            }
        }








        timer1.Tick += Timed_1_Actions;
        timer100.Tick += Timed_100_Actions;
        timer05.Tick += Timed_05_Actions;
        timer1.Start();
        timer100.Start();
        timer05.Start();

        Closed += Window_Closed;

        void Window_Closed(object sender, EventArgs e)
        {
            timer1.Stop();
            timer100.Stop();
            timer05.Stop();
            GlobalVars.ResetTimerCount();
        }


    }


    public void notonlog()
    {
        double[] position = Getposition(frog);
        if (position[1] <= 150 && position[1] >= 40)
        {
            onlog = false;
            checkCollision();
            if (onlog == false)
            {
                Death();
            }
        }
    }
    

    public void initialzeObjects()
    {
        Canvas.SetTop(frog, 355);
        Canvas.SetLeft(frog, 285);


    }

    public void initialzeGame()
    {
        Canvas.SetTop(frog, 355);
        Canvas.SetLeft(frog, 285);
        scores.initialze();


    }
    public void Death()
    {
        difficalty = 0;
        scores.Lives--;
        initialzeObjects();
        MessageBox.Show("You died");
        difficalty = difficaltyHolder;
        

    }
    public void Win()
    {
        initialzeObjects();
        MessageBox.Show("Safe");
        scores.Lives--;
        scores.Wins++;

    }
    public void SafeFrog(int position)
    {
        switch (position)
        {
            case 1:
                if (SafeFrog_1.Visibility == Visibility.Visible)
                {
                    Death();
                }
                else
                {
                    SafeFrog_1.Visibility = Visibility.Visible;
                    Win();
                }
                break;
            case 2:
                if (SafeFrog_2.Visibility == Visibility.Visible)
                {
                    Death();
                }
                else
                {
                    SafeFrog_2.Visibility = Visibility.Visible;
                    Win();
                }
                break;
            case 3:
                if (SafeFrog_3.Visibility == Visibility.Visible)
                {
                    Death();
                }
                else
                {
                    SafeFrog_3.Visibility = Visibility.Visible;
                    Win();
                }
                break;
            case 4:
                if (SafeFrog_4.Visibility == Visibility.Visible)
                {
                    Death();
                }
                else
                {
                    SafeFrog_4.Visibility = Visibility.Visible;
                    Win();
                }
                break;
            case 5:
                if (SafeFrog_5.Visibility == Visibility.Visible)
                {
                    Death();
                }
                else
                {
                    SafeFrog_5.Visibility = Visibility.Visible;
                    Win();
                }
                break;
                default:
                break;
        }
    }


    public double[] Getposition(UIElement element)
    {
        double currentX = Canvas.GetLeft(element);
        double currentY = Canvas.GetTop(element);
        double[] respons = new double[] { currentX, currentY };
        return respons;

    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        double[] position = Getposition(frog);
        notonlog();

        if (e.Key == Key.Up)
        {
            MoveUp(position[1], position[0]);
        }
        else if (e.Key == Key.Down)
        {
            MoveDown(position[1]);
        }
        else if (e.Key == Key.Left)
        {
            MoveLeft(position[0]);
        }
        else if (e.Key == Key.Right)
        {
            MoveRight(position[0]);
        }
        notonlog();

    }

    public void nightMareActive()
    {
        if (nightMare)
        {
            Death();
        }
       
    }

    public bool checkEdge(double current, double left)
    {
        if (current <= 40)
        {
            if(left <110)
            {
                nightMareActive();
                return true;
            }
            if (left >= 565)
            {
                nightMareActive();
                return true;
            }
            if (left >= 145 && left < 215)
            {
                nightMareActive();
                return true;
            }
            if (left >= 250 && left < 320)
            {
                nightMareActive();
                return true;
            }
            if (left >= 355 && left < 425)
            {
                nightMareActive();
                return true;
            }
            if (left >= 460 && left < 530)
            {
                nightMareActive();
                return true;
            }

        }
        return false;
    }

    public int getWinPosition(double current, double left)
    {
        if (current < 40)
        {
            if (left >= 110 && left <= 145)
            {
                return 1;
            }
            if (left >= 215 && left <= 250)
            {
                return 2;
            }
            if (left >= 320 && left <= 355)
            {
                return 3;
            }
            if (left >= 425 && left <= 460)
            {
                return 4;
            }
            if (left >= 530 && left <= 565)
            {
                return 5;
            }

        }
        return 0;
    }

    public void moveObject(UIElement element,string direction, int speed)
    {
        if (speed == 0) { speed = waterspeed; }
        checkCollision();
       double[] position= Getposition(element);
        if (direction=="Left")
        {
         Canvas.SetLeft(element, position[0]- speed*difficalty);  
            if(position[0] < -125)
            {
                Canvas.SetLeft(element, 750 - speed * difficalty);
            }
        }
        if (direction == "Right")
        {
            Canvas.SetLeft(element, position[0] + speed * difficalty);
            if (position[0] > 750)
            {
                Canvas.SetLeft(element, -125 + speed * difficalty);
            }
        }


    }

    public void checkCollision()
    {
        double[] frogPosition= Getposition(frog);
        
        foreach (var obj in MyCanvas.Children)
        {

            if (obj is Image)
            {
                Image image = (Image)obj;
                {
                    if (image.Tag != null)
                    {
                        double[] ElementPosition = Getposition(image);
                        if (ElementPosition[1] == frogPosition[1])
                        {
                            if (ElementPosition[0] - 15 < frogPosition[0] && ElementPosition[0] + image.Width - 15 > frogPosition[0])
                            {
                                if (frogPosition[1] > 145)
                                {
                                    Death();
                                    return;
                                }
                                if (frogPosition[1] <= 145)
                                {
                                    if ((ElementPosition[0] - 15 < frogPosition[0] && ElementPosition[0] + image.Width - 15 > frogPosition[0]))
                                    {


                                        onlog = true;
                                        return;
                                    }
                                }
                            }
                        }

                    }

                }
            }

        }

    }

    public void MoveAllObjects()
    {
        foreach (var obj in MyCanvas.Children)
        {

            if (obj is Image)
            {
                Image image = (Image)obj;
                {
                    if (image.Tag != null)
                    {
                        string[] parts = image.Tag.ToString().Split(' ');
                        int.TryParse(parts[1], out int speed);
                        moveObject(image, parts[0], speed);
                    }
                }
            }
        }
    }


    public void MoveUp(double current, double left)
    {
        frog.Source = Frogger_Classes.LoadImageFromResource("Frog_top.png");
        if (!checkEdge(current, left))
        {
            
            if (current > 35)
            {
                Canvas.SetTop(frog, current - 35);
            }
            if (current <= 35)
            {
                Canvas.SetTop(frog, 5);
            }
        }


    }
    public void MoveDown(double current)
    {
        frog.Source = Frogger_Classes.LoadImageFromResource("Frog_Down.png");
        if (current < 335)
        {
            Canvas.SetTop(frog, current + 35);
        }
        if (current >= 335)
        {
            Canvas.SetTop(frog, 355);
        }

    }
    public void MoveLeft(double current)
    {
        frog.Source = Frogger_Classes.LoadImageFromResource("Frog_Right.png");
        if (current > 35)
        {
            Canvas.SetLeft(frog, current - 35);
        }
        if (current <= 35)
        {
            Canvas.SetLeft(frog, 5);
        }

    }
    public void MoveRight(double current)
    {
        frog.Source = Frogger_Classes.LoadImageFromResource("Frog_Left.png");
        if (current < 560)
        {
            Canvas.SetLeft(frog, current + 35);
        }
        if (current >= 560)
        {
            Canvas.SetLeft(frog, 600);
        }

    }

    private void Close_button(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void About_button(object sender, RoutedEventArgs e)
    {
        Help window = new Help();
        window.ShowDialog();
    }
}

