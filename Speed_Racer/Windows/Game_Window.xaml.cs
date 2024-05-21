using Common_Classes.Classes;
using Speed_Racer.Resources.Classes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using Speed_Racer.Resources.Controls;
using static System.Formats.Asn1.AsnWriter;



namespace Speed_Racer.Windows
{
    /// <summary>
    /// Interaction logic for Game_Window.xaml
    /// </summary>
    public partial class Game_Window : Window
    {
        public double speed_Holder = 0.1;
        public double Speed = 0.11;
        public int difficalty = 2;
        public bool sidecrash = false;
        public bool start = false;
        public int countDown = 0;
        public string name = "TEST";

        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(10) };
        DispatcherTimer timer1s = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        DispatcherTimer timer4s = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        Fule_Tank fule_Tank = new Fule_Tank();
        Race_Game NewGame;
        public Game_Window()
        {
            NewGame = new Race_Game(name, difficalty);
            InitializeComponent();
            timer4s.Start();

            timer1.Tick += timedReaction;
            timer1s.Tick += secondTimedReaction;
            timer4s.Tick += FourSecondtimer;

            NewGame.WinEvent += win_fuction;
            NewGame.LoseEvent += Lose_fuction;
            //moveAllCars(600);
            
            Track_Canvas.Children.Add(fule_Tank);
            Canvas.SetZIndex(fule_Tank, 4);
            Canvas.SetTop(fule_Tank, 0);
            Canvas.SetLeft(fule_Tank, 0);
            
        }

        public void FourSecondtimer(object sender, EventArgs e)
        {
            if (countDown == 0)
            {
                setCarsFordifficalty(difficalty);
                Light.Source = Image_Import.LoadImageFromResource("RedLight.png");
                Light.Visibility = Visibility.Visible;
                countDown++;
                return;
            }
            if (countDown == 1)
            {
                Light.Source = Image_Import.LoadImageFromResource("YellowLight.png");
                countDown++;
                return;
            }
            if (countDown == 2)
            {
                Light.Source = Image_Import.LoadImageFromResource("GreenLight.png");
                countDown = 0;
                timer1.Start();
                timer1s.Start();
                start =true;
                return;
            }

        }

        public void setCarsFordifficalty(int difficalty)
        {
            List<UIElement> enimyCars = new List<UIElement>() { Car2, Car3, Car5, Car6, Car8 };
            switch (difficalty)
            {
                case 0:
                    Car5.Visibility = Visibility.Collapsed;
                    Car6.Visibility = Visibility.Collapsed;
                    Car8.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    Car6.Visibility = Visibility.Collapsed;
                    Car8.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    Car8.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }



            
        }

        public void moveLines()
        {
            List<UIElement> lines = new List<UIElement>();
            lines.Add(Track_line1);
            lines.Add(Track_line2);
            lines.Add(Track_line3);
            foreach (UIElement item in lines)
            {
                double[] position = Getposition(item);
                if (position[1] >= 28 - (difficalty + 1) * Speed) { Canvas.SetTop(item, -20); }
                else
                {
                    Canvas.SetTop(item, position[1] + (difficalty+1) * Speed);
                }
            }

        }

        private void Lose_fuction(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1s.Stop();
            MessageBox.Show("You Lose");
            start =false;
            GameOver(sender, e);
        }


        private void win_fuction(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1s.Stop();
            MessageBox.Show("You Win");
            start =false;
            GameOver(sender,e);
            }

        private void timedReaction(object sender, EventArgs e)
        {
            checkEnemyCollision();
            MoveAllObjects();
            checkCollision();
            moveLines();
            speed_Value.Text = Speed.ToString("F2");

        }
        private void secondTimedReaction(object sender, EventArgs e)
        {
            Light.Visibility = Visibility.Collapsed;
            timer4s.Stop();
            NewGame.timePass();
            NewGame.moveForward(Speed);
            Distance_Count.Text = NewGame.distance.ToString("F1");
            Car_Count.Text = NewGame.repair.ToString();
            Time_Count.Text = NewGame.time.ToString();
            Score_Value.Text = NewGame.score.ToString();
            Fule_Value.Text = NewGame.Fule.ToString("F1");
            NewGame.UseFule(Speed);


        }



        public double[] Getposition(UIElement element)
        {
            double currentX = Canvas.GetLeft(element);
            double currentY = Canvas.GetTop(element);
            double[] respons = new double[] { currentX, currentY };
            return respons;

        }


        private void Game_Window_KeyDown(object sender, KeyEventArgs e)
        {
            double[] position = Getposition(player);
            if (start)
            {
                if (e.Key == Key.W)
                {
                    Speed += 0.05;
                }
                else if (e.Key == Key.S)
                {
                    if (Speed > 0.1)
                    {
                        Speed -= 0.05;
                    }
                }


            }


            if (e.Key == Key.P)
            {
                if (start)
                {
                    timer1.Stop();
                    timer1s.Stop();
                    start = false;
                    return;
                }
                if (!start)
                {
                    timer1.Start();
                    timer1s.Start();
                    start = true;
                    return;
                }

            }
        }

        public void moveAllCars(double moveto)
        {
            Random rnd = new Random();
            List<UIElement> enimyCars = new List<UIElement>() { Car2, Car3, Car5, Car6, Car8 };
            foreach (UIElement item in enimyCars)
            {
                Canvas.SetTop(item, rnd.Next((int)moveto, (int)moveto+200));
            }
        }


        public void explosion()
        {
            player.Source = Image_Import.LoadImageFromResource("Explosion.png");
        }

        public void Fix()
        {
            player.Source = Image_Import.LoadImageFromResource("MaxCar.png");
        }

        public void GameOver(object sender, EventArgs e) {
            int response = Message_Box_Classes.DisplayMessageBox("Game over, Do you Want to play again?", "GAME OVER");
            if (response == 0)
            {
                Close();
            }
            if (response == 1)
            {
                InitializeComponent();
                NewGame.initilize(difficalty);
                timer4s.Start();
            }
        }


        public void Death()
        {
            explosion();
            timer1.Stop();
            timer1s.Stop();
            if (NewGame.repair <0 ) {
                object sender = new object();
                EventArgs e = new EventArgs();
                GameOver(sender, e);
            }
            MessageBox.Show("You died");
            timer1.Start();
            timer1s.Start();
            Fix();
            Speed = speed_Holder;
            NewGame.Car_death();
        moveAllCars(700);
        }

        public void moveObject(UIElement element, int speed)
        {
            Random rnd = new Random();
            string designation;
            checkCollision();
            double[] position = Getposition(element);
                Canvas.SetTop(element, position[1] + speed * (difficalty+1)* Speed);
                if (position[1] > 800 || position[1] < -2000)
                {
                if (element is Image image)
                {
                    int newSpeed = rnd.Next(1, 6);
                    if (newSpeed == 1)
                    {
                        designation = "terrane";
                    }
                    else
                    {
                        designation = "Car";
                    }
                    image.Tag = $"{designation} {newSpeed}";
                    image.Source = Image_Import.LoadImageFromResource($"{changeCarImageBySpeed(newSpeed)}.png");
                    Canvas.SetLeft(element, rnd.Next(0, 300));

                }
                if (element is Fule_Tank Fule_Tank)
                {
                    Fule_Tank.Visibility = Visibility.Visible;
                    Canvas.SetLeft(Fule_Tank, rnd.Next(0, 300));
                    Canvas.SetTop(Fule_Tank, -1 * (500 + 150 * rnd.Next(2, 8)));
                    return;
                }
                Canvas.SetTop(element, -1 * (500 + 150 * rnd.Next(2,5)));
            }
            

        }

        public string changeCarImageBySpeed(int newspeed)
        {
            Random rnd = new Random();
            if (newspeed == 1)
            {
                int random = rnd.Next(0,2);
                if (random == 0)
                {
                    return "Debris";
                }
                else
                {
                    return "FlippedCar";
                }
            }
            if ((newspeed >= 2) && (newspeed <= 4))
            {
                return "HunterCar";
            }
            if ((newspeed > 4))
            {
                return "BattleCar";
            }
            return "Debris";
        }

        public void checkCollision()
        {
            double[] carPosition = Getposition(player);
            int verticalTolerance = (int)player.ActualWidth;
            int horizontalTolerance = (int)player.ActualHeight;
            foreach (var obj in Track_Canvas.Children)
            {

                if (obj is Image movable)
                {
                    
                        if (movable.Tag != null)
                        {
                            verticalTolerance += (int)movable.ActualWidth;
                            verticalTolerance = (verticalTolerance / 2) - 5;
                            horizontalTolerance += (int)movable.ActualHeight;
                            horizontalTolerance = (horizontalTolerance / 2) - 5;
                            double[] ElementPosition = Getposition(movable);
                            if (carPosition[1] > ElementPosition[1] - horizontalTolerance && carPosition[1] < ElementPosition[1] + horizontalTolerance)
                            {
                                if (carPosition[0] > ElementPosition[0] - verticalTolerance && carPosition[0] < ElementPosition[0] + verticalTolerance  )
                                {
                                    if (movable.Visibility == Visibility.Visible && (movable.Tag.ToString().Contains("Car") || movable.Tag.ToString().Contains("terrane")))
                                    {
                                        Death();
                                        return;
                                    }
                                    }

                                }
                            }

                        }if (obj is Fule_Tank goody) {
                    verticalTolerance += (int)goody.ActualWidth;
                    verticalTolerance = (verticalTolerance / 2) - 5;
                    horizontalTolerance += (int)goody.ActualHeight;
                    horizontalTolerance = (horizontalTolerance / 2) - 5;
                    double[] ElementPosition = Getposition(goody);
                    if (carPosition[1] > ElementPosition[1] - horizontalTolerance && carPosition[1] < ElementPosition[1] + horizontalTolerance)
                    {
                        if (carPosition[0] > ElementPosition[0] - verticalTolerance && carPosition[0] < ElementPosition[0] + verticalTolerance)
                        {
                            if (goody.Visibility == Visibility.Visible)
                            {
                                goody.Visibility = Visibility.Collapsed;
                                NewGame.AddFule();
                                return;
                            }
                        }

                    }
                }

            }

                    
                
            

            }




        public void checkEnemyCollision()
        {
            Random rnd = new Random();
            List<UIElement> enimyCars = new List<UIElement>() { Car2, Car3, Car5, Car6, Car8 };
            foreach (UIElement car in enimyCars)
            {
                if (car is Image carImage)
                {
                    double[] carPosition = Getposition(car);
                    int verticalTolerance = (int)carImage.ActualWidth;
                    int horizontalTolerance = (int)carImage.ActualHeight;
                    foreach (UIElement car2 in enimyCars)
                    {

                        if (car != car2)
                        {
                            if (car2 is Image carImage2)
                            {
                                verticalTolerance += (int)carImage2.ActualWidth;
                                verticalTolerance = (verticalTolerance / 2);
                                horizontalTolerance += (int)carImage2.ActualHeight;
                                horizontalTolerance = (horizontalTolerance / 2);
                                double[] car2Position = Getposition(car2);
                                if (carPosition[1] > car2Position[1] - horizontalTolerance && carPosition[1] < car2Position[1] + horizontalTolerance)
                                {
                                    if (carPosition[0] > car2Position[0] - verticalTolerance && carPosition[0] < car2Position[0] + verticalTolerance)
                                    {
                                        if (car.Visibility == Visibility.Visible && car2.Visibility == Visibility.Visible)
                                        {
                                            if (carImage.Tag != "terrane 1")
                                            {
                                                carImage.Tag = $"terrane 1";
                                                carImage.Source = Image_Import.LoadImageFromResource($"FlippedCar.png");
                                            }
                                            if (carImage2.Tag != "terrane 1")
                                            {
                                                carImage2.Tag = $"terrane 1";
                                                carImage2.Source = Image_Import.LoadImageFromResource($"FlippedCar.png");
                                            }
                                            
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
            foreach (var obj in Track_Canvas.Children)
            {

                if (obj is Image movable)
                {

                        if (movable.Tag != null)
                        {
                            string[] parts = movable.Tag.ToString().Split(' ');
                            int.TryParse(parts[1], out int speed);
                            moveObject(movable, speed);
                        }
                    
                }
                if (obj is Fule_Tank tank)
                {
                    moveObject(tank, 1);
                }

            }
        }


        private void Mouse_move(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(Track_Canvas);
            if (sidecrash && position.X < 315 && position.X > 0 && start)
            {
                if (position.X < 290 && position.X > 15 && start) {
                    Canvas.SetLeft(player, position.X);
                }
                if (position.X > 290 || position.X < 15) {
                    Death();
                }
            }

            if (position.X <290 && position.X > 15 && start)
            {
                Canvas.SetLeft(player, position.X);
            }
        }
    }
}
