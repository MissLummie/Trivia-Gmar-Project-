using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Client_trivia_Aluma_Gelbard.RemoteDatabaseService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client_trivia_Aluma_Gelbard.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class top10 : Page
    {
        bool is3 = true;
        public top10()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
        }

        private void image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (is3)
                changeTo10();
            else
                changeTo3();
        }

        private async void changeTo3()
        {
            is3 = true;
            ImageBrush bg = new ImageBrush();
            bg.Stretch = Stretch.Fill;
            BitmapImage bi3 = new BitmapImage();
            bi3.UriSource = new Uri("ms-appx:///Pictures/top3.png");
            bg.ImageSource = bi3;
            this.myGrid.Background = bg;

            title.Visibility = Visibility.Collapsed;
            this.topten.Visibility = Visibility.Collapsed;

            this.champ1.Visibility = Visibility.Visible;
            this.champ2.Visibility = Visibility.Visible;
            this.champ3.Visibility = Visibility.Visible;

            Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient proxy = new Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient();
            System.Collections.ObjectModel.ObservableCollection<Score> score_list = await proxy.GetTop10ScoreAsync();
            if(score_list.Count >= 1) {
                this.champ1.Text = (Classes.UserManager.Select(score_list[0].user_id)).username;
            }
            if (score_list.Count >= 2) {
                this.champ2.Text = (Classes.UserManager.Select(score_list[1].user_id)).username;
            }
            if (score_list.Count >= 3) {
                this.champ3.Text = (Classes.UserManager.Select(score_list[2].user_id)).username;
            }


            this.see.Text = "See More!";
        }

        private async void changeTo10()
        {
            is3 = false;
            ImageBrush bg = new ImageBrush();
            bg.Stretch = Stretch.Fill;
            BitmapImage bi3 = new BitmapImage();
            bi3.UriSource = new Uri("ms-appx:///Pictures/void.png");
            bg.ImageSource = bi3;
            this.myGrid.Background = bg;

            title.Visibility = Visibility.Visible;
            this.topten.Visibility = Visibility.Visible;
            this.topten.Text = "";
            this.champ1.Visibility = Visibility.Collapsed;
            this.champ2.Visibility = Visibility.Collapsed;
            this.champ3.Visibility = Visibility.Collapsed;

            Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient proxy = new Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient();
            System.Collections.ObjectModel.ObservableCollection<Score> score_list = await proxy.GetTop10ScoreAsync();
            int range = score_list.Count >= 10 ? 10 : score_list.Count;
            for (int i=0; i<range; i++) {
                this.topten.Text += i + 1 + ".      " + (Classes.UserManager.Select(score_list[i].user_id)).username;
                this.topten.Text += " With the score: " + score_list[i].score + "\n";
            }

            this.see.Text = "See Less!";
        }

        private void see_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (is3)
                changeTo10();
            else
                changeTo3();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            changeTo3();
        }
    }
}
