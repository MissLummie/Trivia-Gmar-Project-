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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Client_trivia_Aluma_Gelbard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);

            if (Classes.UserManager.myUser != null)
            {
                username.Text = Classes.UserManager.myUser.username;
                set_hello();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        { // Signin
            if (Classes.UserManager.myUser == null)
            { // if is not connected
                if ((!username.Text.Equals("")) && (!password.Password.Equals("")))
                {
                    int userId = Classes.UserManager.FindUser(username.Text, password.Password) > 0 ? Classes.UserManager.FindUser(username.Text, password.Password) : -1;
                    if (userId != -1)
                    { // connect
                        Classes.UserManager.myUser = Classes.UserManager.Select(userId);
                        set_hello();
                    }
                    else
                    { // wrong details
                        var dialog = new MessageDialog("Error: Username or password are incorrect");
                        var res = dialog.ShowAsync();
                    }
                }
            }
        }

        private void set_hello()
        { // Print hello if the user is connected
            hello.Text = "Hey " + username.Text + "! :)\nFor any help chose help :)";
            usernameblock.Visibility = Visibility.Collapsed;
            passblock.Visibility = Visibility.Collapsed;
            image.Visibility = Visibility.Collapsed;
            image_Copy.Visibility = Visibility.Collapsed;
            username.Visibility = Visibility.Collapsed;
            password.Visibility = Visibility.Collapsed;
            button.Visibility = Visibility.Collapsed;
            signup.Content = "SignOut!";
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.help));
        }

        private void best_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.top10));
        }

        private void status_Click(object sender, RoutedEventArgs e)
        { // direct to personal status page
            if(Classes.UserManager.myUser != null) // only if connected
                Frame.Navigate(typeof(Pages.myScore));
            else
            {
                var dialog = new MessageDialog("Error: You need to connect your user");
                var res = dialog.ShowAsync();
            }
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        { // sign up and sign out click
            if(Classes.UserManager.myUser == null) // only if disconnected
                Frame.Navigate(typeof(Pages.signup));
            else { // signout
                usernameblock.Visibility = Visibility.Visible;
                passblock.Visibility = Visibility.Visible;
                image.Visibility = Visibility.Visible;
                image_Copy.Visibility = Visibility.Visible;
                username.Visibility = Visibility.Visible;
                password.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Visible;
                signup.Content = "SignUp!";
                Classes.UserManager.myUser = null;
            }
        }

        private void createroom_Click(object sender, RoutedEventArgs e)
        { // if the user connected: create a play room
            if (Classes.UserManager.myUser != null) // only if connected
                Frame.Navigate(typeof(Pages.createroom));
            else
            {
                var dialog = new MessageDialog("Error: You need to connect your user");
                var res = dialog.ShowAsync();
            }
        }

        private void addques_Click(object sender, RoutedEventArgs e)
        { // direct to add questions page if the user connected & admin
            if (Classes.UserManager.myUser != null && Classes.UserManager.myUser.isAdmin) // only if connected
                Frame.Navigate(typeof(Pages.addQues));
            else
            {
                var dialog = new MessageDialog("Error: Access Denied");
                var res = dialog.ShowAsync();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (Classes.UserManager.myUser != null) {
                username.Text = Classes.UserManager.myUser.username;
                set_hello();
            }
        }
    }
}
