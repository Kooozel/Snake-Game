using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Snake
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Head snake;
        Food food;
        DispatcherTimer timer;

        public MainWindow()
        {
            Start();
        }


        public void Start()
        {
            

            InitializeComponent();
            gameboard.Children.Clear();
            snake = new Head();
            gameboard.Children.Add(snake.Rectangle);
            Canvas.SetLeft(snake.Rectangle,0);
            Canvas.SetTop(snake.Rectangle,0);

            food = new Food();
            food.Draw(gameboard);
            food.PickLocation(gameboard);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();


        }
        public bool Death()
        {

            foreach (SnakeBody item in snake.Tails)
            {
                if (item.X == snake.X && item.Y == snake.Y)
                {
                    return true;
                }
            }

            if (snake.X > gameboard.Width - GlobalVar.SCALE)
            {
                return true;
            }
            else if (snake.X < 0)
            {
                return true;
            }
            else if (snake.Y < 0)
            {
                return true;
            }
            else if (snake.Y > gameboard.Height - GlobalVar.SCALE)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
       

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Death())
            {
                MessageBox.Show($"Game over!\n Your score: {snake.Total}.");
                timer.Stop();
                Start();
                
            }

            if (snake.Eat(food))
            {
                
                food.PickLocation(gameboard);


                gameboard.Children.Add(snake.Tails[snake.Total-1].Rectangle);
                Canvas.SetLeft(snake.Tails[snake.Total - 1].Rectangle, snake.X);
                Canvas.SetTop(snake.Tails[snake.Total - 1].Rectangle, snake.Y);

            }
            snake.Update();

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                snake.Dir(0, -1);
            }
            else if (e.Key == Key.Down)
            {
                snake.Dir(0, 1);
            }
            else if (e.Key == Key.Left)
            {
                snake.Dir(-1, 0);
            }
            else if (e.Key == Key.Right)
            {
                snake.Dir(1, 0);
            }

            
           
        }

    }
}

