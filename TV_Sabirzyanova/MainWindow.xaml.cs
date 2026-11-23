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

namespace TV_Sabirzyanova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();
        public MainWindow()
        {
            InitializeComponent();
            VideoPlayer.Source = new Uri(TV.Channels[TV.ActiveChannel].Src, UriKind.Relative);
            VideoPlayer.Play();
            VideoPlayer.MediaFailed += (s, args) => MessageBox.Show(args.ErrorException.Message);

        }

        private void BackChannel(object sender, RoutedEventArgs e)
        {
            TV.BackChannel(VideoPlayer, NameChannel);
        }

        private void NextChannel(object sender, RoutedEventArgs e)
        {
            TV.NextChannel(VideoPlayer, NameChannel);
        }

        private void SelectChannel1(object sender, RoutedEventArgs e)
        {
            TV.SelectChannelByIndex(0, VideoPlayer, NameChannel);
        }

        private void SelectChannel2(object sender, RoutedEventArgs e)
        {
            TV.SelectChannelByIndex(1, VideoPlayer, NameChannel);
        }

        private void PowerToggle(object sender, RoutedEventArgs e)
        {
            TV.IsTurnedOn = !TV.IsTurnedOn;
            if (TV.IsTurnedOn)
            {
                VideoPlayer.Visibility = Visibility.Visible;
                VideoPlayer.Play();
                NameChannel.Content = TV.Channels[TV.ActiveChannel].Name;
            }
            else
            {
                VideoPlayer.Stop();
                VideoPlayer.Visibility = Visibility.Hidden;
                NameChannel.Content = "Телевизор выключен";
            }
        }
    }
}
