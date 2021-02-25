using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    public static class GlobalVar
    {
        public const int SCALE = 20;
    }
    public partial class MainWindow : Window
    {
        
        class Head
        {
            
            int x;
            int y;
            int xSpeed;
            int ySpeed;
            Rectangle rectangle;
            int total = 0;
            List<SnakeBody> tails = new List<SnakeBody>();
            public Head()
            {
                this.x = 0;
                this.y = 0;
                this.xSpeed = 1;
                this.ySpeed = 0;
                this.rectangle = new SnakeBody().Rectangle;

            }

            public Rectangle Rectangle { get => rectangle; set => rectangle = value; }
            public int XSpeed { get => xSpeed; set => xSpeed = value; }
            public int Y { get { return (int)Canvas.GetTop(Rectangle); ; } set => y = value; }
            public int X { get { return (int)Canvas.GetLeft(Rectangle); } set => x = value; }
            public int YSpeed { get => ySpeed; set => ySpeed = value; }
            public List<SnakeBody> Tails { get => tails; set => tails = value; }
            public int Total { get => total; set => total = value; }

            public void Update()
            {
                if (total>0)
                {
                    for (int i = Tails.Count-1; i > 0; i--)
                    {
                        Canvas.SetLeft(Tails[i].Rectangle,Tails[i-1].X);
                        Canvas.SetTop(Tails[i].Rectangle, Tails[i - 1].Y);
                    }
                    Canvas.SetLeft(Tails[0].Rectangle, X);
                    Canvas.SetTop(Tails[0].Rectangle, Y);

                }
                Canvas.SetLeft(Rectangle, X + XSpeed * GlobalVar.SCALE);
                Canvas.SetTop(Rectangle, Y + YSpeed * GlobalVar.SCALE);
            }
          
            public void Dir(int x, int y)
            {
                this.XSpeed = x;
                this.YSpeed = y;
            }

            public bool Eat(Food food)
            {
                if (X == food.X && Y == food.Y)
                {
                    this.total++;
                    tails.Add(new SnakeBody());
                    
                    return true;
                }
                else { return false; }
            }
          
        }
    }
}