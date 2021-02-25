using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{

    public partial class MainWindow : Window
    {
        class SnakeBody
        {
            int x;
            int y;
            Rectangle rectangle;
            public SnakeBody()
            {
                Rectangle rectangle = new Rectangle
                {
                    Height = GlobalVar.SCALE,
                    Width = GlobalVar.SCALE,
                    Stroke = Brushes.Black
                };

                rectangle.Fill = Brushes.White;
                this.rectangle = rectangle;
            }
            public int Y { get { return (int)Canvas.GetTop(this.Rectangle); ; } set => y = value; }
            public int X { get { return (int)Canvas.GetLeft(this.Rectangle); } set => x = value; }
            public Rectangle Rectangle { get => rectangle; set => rectangle = value; }
        }

    }
}

