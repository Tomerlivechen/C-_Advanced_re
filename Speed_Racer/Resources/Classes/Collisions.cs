using Speed_Racer.Resources.Controls;
using Speed_Racer.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Speed_Racer.Resources.Classes
{
    public static class Collisions
    {
        public static void CheckEnemyCollision(List<Image> enimyCars)
        {

            foreach (Image car in enimyCars)
            {

                double[] carPosition = Get_From_Canvas.Getposition(car);
                int verticalTolerance = (int)car.ActualWidth;
                int horizontalTolerance = (int)car.ActualHeight;
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
                            double[] car2Position = Get_From_Canvas.Getposition(car2);
                            if (carPosition[1] > car2Position[1] - horizontalTolerance && carPosition[1] < car2Position[1] + horizontalTolerance)
                            {
                                if (carPosition[0] > car2Position[0] - verticalTolerance && carPosition[0] < car2Position[0] + verticalTolerance)
                                {
                                    if (car.Visibility == Visibility.Visible && car2.Visibility == Visibility.Visible)
                                    {
                                        if (car.Tag.ToString() != "terrane 1")
                                        {
                                            car.Tag = $"terrane 1";
                                            car.Source = Image_Import.LoadImageFromResource($"FlippedCar.png");
                                        }
                                        if (carImage2.Tag.ToString() != "terrane 1")
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

        public static void CheckCollision(Canvas Track_Canvas, Image player, Race_Game NewGame, Game_Window Game_Window)
        {
            double[] carPosition = Get_From_Canvas.Getposition(player);
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
                        double[] ElementPosition = Get_From_Canvas.Getposition(movable);
                        if (carPosition[1] > ElementPosition[1] - horizontalTolerance && carPosition[1] < ElementPosition[1] + horizontalTolerance)
                        {
                            if (carPosition[0] > ElementPosition[0] - verticalTolerance && carPosition[0] < ElementPosition[0] + verticalTolerance)
                            {
                                if (movable.Visibility == Visibility.Visible && (movable.Tag.ToString().Contains("Car") || movable.Tag.ToString().Contains("terrane")))
                                {
                                    Game_Window.Death();
                                    return;
                                }
                            }

                        }
                    }

                }

            }

        }

        public static void CheckGoodCollision(Canvas Track_Canvas, Image player, Race_Game NewGame)
        {
            double[] carPosition = Get_From_Canvas.Getposition(player);
            int verticalTolerance = (int)player.ActualWidth;
            int horizontalTolerance = (int)player.ActualHeight;
            foreach (var obj in Track_Canvas.Children)
            {

                if (obj is Colectable goody)
                {
                    verticalTolerance += (int)goody.ActualWidth ;
                    verticalTolerance = (verticalTolerance / 2) ;
                    horizontalTolerance += (int)goody.ActualHeight ;
                    horizontalTolerance = (horizontalTolerance / 2) ;
                    double[] ElementPosition = Get_From_Canvas.Getposition(goody);
                    if (carPosition[1] > ElementPosition[1] - horizontalTolerance && carPosition[1] < ElementPosition[1] + horizontalTolerance)
                    {
                        if (carPosition[0] > ElementPosition[0] - verticalTolerance && carPosition[0] < ElementPosition[0] + verticalTolerance)
                        {
                            if (goody.Visibility == Visibility.Visible)
                            {
                                if (goody.Tag.ToString() == "Fule")
                                    goody.Visibility = Visibility.Collapsed;
                                NewGame.AddFule();
                                return;
                            }
                        }

                    }
                }
            }
            }





        
    }
}
