using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client_trivia_Aluma_Gelbard.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class createroom : Page
    {
        public createroom()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if(Classes.UserManager.myUser != null)
            {
                if (subject.SelectedValue != null && level.SelectedValue != null && num.SelectedValue != null && timer.SelectedValue != null)
                { // if all the field arenot missing
                    // initial game parameters
                    Classes.GameManager.InitailGame((subject.SelectedItem as ComboBoxItem).Content.ToString(),
                                                    int.Parse((level.SelectedItem as ComboBoxItem).Content.ToString()),
                                                    int.Parse((num.SelectedItem as ComboBoxItem).Content.ToString()),
                                                    int.Parse((timer.SelectedItem as ComboBoxItem).Content.ToString()));
                    Frame.Navigate(typeof(Pages.game)); // start the game
                }
                else
                { // fields are missing
                    var dialog = new MessageDialog("Error: Some fields are missing!");
                    var res = dialog.ShowAsync();
                }
            }
            else
            { // user error
                var dialog = new MessageDialog("Error: You are disconnected!");
                var res = dialog.ShowAsync();
                Frame.GoBack();
            }
        }
    }
}
