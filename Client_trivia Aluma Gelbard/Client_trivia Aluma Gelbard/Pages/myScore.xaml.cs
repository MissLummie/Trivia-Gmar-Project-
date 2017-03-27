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
using Windows.UI.Xaml.Navigation;
using Client_trivia_Aluma_Gelbard.RemoteDatabaseService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client_trivia_Aluma_Gelbard.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class myScore : Page
    {
        public myScore()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient proxy = new Client_trivia_Aluma_Gelbard.RemoteDatabaseService.TriviaServiceClient();
            Score result = await proxy.GetUserScoreAsync(Classes.UserManager.myUser.user_ID);
            this.score_tb.Text = "Total Score:    " + (result.score).ToString();
            this.highscore_tb.Text = "Highest Score:    " + (result.highest_score).ToString();
            this.lategame_tb.Text = "Last Game Score:    " + (result.late_score).ToString();
            this.fastest_tb.Text = "Fastest Time:    " + (result.fastest_time).ToString();
            this.strike_tb.Text = "Longest Strike:    " + (result.longest_strike).ToString();

        }
    }
}
