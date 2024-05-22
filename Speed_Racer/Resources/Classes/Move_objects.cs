using Speed_Racer.Resources.Controls;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Speed_Racer.Resources.Classes
{
    public static class Move_objects
    {
        public static void MoveAllObjects(Canvas Track_Canvas , int difficalty, double Speed)
        {
            foreach (var obj in Track_Canvas.Children)
            {
                if (obj is Image movable)
                {
                    if (movable.Tag != null)
                    {
                        string[] parts = movable.Tag.ToString().Split(' ');
                        int.TryParse(parts[1], out int speed);
                        moveObject(movable, speed, difficalty, Speed);
                    }
                }
                if (obj is Colectable tank)
                {
                    moveObject(tank, 1, difficalty, Speed);
                }
            }
        }

        public static void moveObject(UIElement element, int speed, int difficalty, double Speed)
        {
            Random rnd = new Random();
            string designation;
            double[] position = Get_From_Canvas.Getposition(element);
            Canvas.SetTop(element, position[1] + speed * (difficalty + 1) * Speed);
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
                if (element is Colectable Fule_Tank)
                {
                    Fule_Tank.Visibility = Visibility.Visible;
                    Canvas.SetLeft(Fule_Tank, rnd.Next(0, 300));
                    Canvas.SetTop(Fule_Tank, -1 * (500 + 150 * rnd.Next(2, 8)));
                    return;
                }
                Canvas.SetTop(element, -1 * (500 + 150 * rnd.Next(2, 5)));
            }
        }

        public static string changeCarImageBySpeed(int newspeed)
        {
            Random rnd = new Random();
            if (newspeed == 1)
            {
                int random = rnd.Next(0, 2);
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
    }
}
