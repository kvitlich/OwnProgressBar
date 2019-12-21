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

namespace ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private static bool SideFlag = false;
        private static bool StartButtonFlag = true;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

        }

        private void Tick(object sender, EventArgs e)
        {
            Task.Run(() => {
                Dispatcher.Invoke(() =>
                {
                    ChangeSwordTheme(SideFlag);

                });
            });
        }

        private void Join(object sender, RoutedEventArgs e)
        {
            ChangeSide(SideFlag);
        }


        private void Start(object sender, RoutedEventArgs e)
        {
            if (StartButtonFlag)
            {
                progressBar.Visibility = Visibility.Visible;
                startButton.Content = "Stop";
                progressBar.IsIndeterminate = true;
                sideButton.Visibility = Visibility.Visible;
                StartButtonFlag = false;
                ChangeSide(SideFlag);
                ChangeSwordTheme(SideFlag);
            }
            else
            {
                startButton.Content = "Start";
                progressBar.IsIndeterminate = false;
                sideButton.Visibility = Visibility.Hidden;
                ChangeSwordTheme(SideFlag);
                StartButtonFlag = true;
                progressBar.Visibility = Visibility.Hidden;
            }
        }

        private void ChangeSide(bool currentSide)
        {
            if (SideFlag)
            {
                sideButton.Content = "Join To Dark Side";
                progressBar.Foreground = Brushes.Green;
                progressBar.Background = Brushes.Gray;
                SideFlag = false;
            }
            else
            {
                sideButton.Content = "Join To Light Side";
                progressBar.Foreground = Brushes.Red;
                progressBar.Background = Brushes.Gray;
                SideFlag = true;

            }
        }

        private void ChangeSwordTheme(bool side)
        {
            if (side)
            {
                switch (new Random().Next(1, 4))
                {
                    case 1:
                        progressBar.Foreground = Brushes.Green;
                        break;
                    case 2:
                        progressBar.Foreground = Brushes.White;
                        break;
                    case 3:
                        progressBar.Foreground = Brushes.Blue;
                        break;
                }
            }
            else
            {

                switch (new Random().Next(1, 4))
                {
                    case 1:
                        progressBar.Foreground = Brushes.Red;
                        break;
                    case 2:
                        progressBar.Foreground = Brushes.Purple;
                        break;
                    case 3:
                        progressBar.Foreground = Brushes.DarkRed;
                        break;
                }
            }
        }
    }
}
