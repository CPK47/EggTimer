using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Media;

namespace EggTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer Timer = new DispatcherTimer();
        int first;
        int second;
        int result;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Size_Click(object sender, RoutedEventArgs e)
        {
            string button = sender.ToString();
            button = button.Substring(button.IndexOf(' ') + 1);
            switch (button)
            {
                case "Small": { first = 60; }
                    break;
                case "Medium": { first = 120; }
                    break;
                case "Large": { first = 180; }
                    break;
                default: { first = 0; }
                    break;
            }
            
            //first = 1;
            timer.Content = first;
        }

        private void BoilType_Click(object sender, RoutedEventArgs e)
        {
            string button = sender.ToString();
            button = button.Substring(button.IndexOf(' ') + 1);
            switch (button)
            {
                case "Soft":
                    { second = 60; }
                    break;
                case "Medium":
                    { second = 120; }
                    break;
                case "Hard":
                    { second = 180; }
                    break;
                default:
                    { second = 0; }
                    break;
            }
            result = first + second;
            timer.Content = result;
            
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (result != 0) { result--; timer.Content = result.ToString(); }
            else
            {
                Timer.Stop(); 
                SoundPlayer player = new SoundPlayer(Environment.CurrentDirectory + @"\..\..\..\Assets\yeah-boi.wav");
                player.Play();
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
            timer.Content = "0";
        }
    }
}
