using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{

    public partial class MainWindow
    {
        class Food
        {
            int x;
            int y;
            Rectangle rectangle;

            public Rectangle Rectangle { get => rectangle; set => rectangle = value; }


            public int Y { get { return (int)Canvas.GetTop(Rectangle); ; } set => y = value; }
            public int X { get { return (int)Canvas.GetLeft(Rectangle); } set => x = value; }

            public void Draw(Canvas canvas)
            {
                Rectangle rectangle = new Rectangle
                {
                    Height = GlobalVar.SCALE,
                    Width = GlobalVar.SCALE,
                    Stroke = Brushes.Black
                };

                rectangle.Fill = Brushes.DeepPink;
                canvas.Children.Add(rectangle);
                this.rectangle = rectangle;
            }
            public void PickLocation(Canvas canvas)
            {
                int columns = (int)Math.Floor(canvas.Width/GlobalVar.SCALE);
                int rows = (int)Math.Floor(canvas.Height/GlobalVar.SCALE);

                Random random = new Random();
                int number1 = (int)Math.Floor(random.NextDouble() * columns);
                int number2 = (int)Math.Floor(random.NextDouble() * rows);
                Canvas.SetLeft(Rectangle,number1*GlobalVar.SCALE);
                Canvas.SetTop(Rectangle, number2* GlobalVar.SCALE);
            }
        }

    }
}

