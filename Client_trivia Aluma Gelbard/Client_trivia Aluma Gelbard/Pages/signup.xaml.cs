using Client_trivia_Aluma_Gelbard.Classes;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Client_trivia_Aluma_Gelbard.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class signup : Page
    {
        public signup()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            if(Classes.Validator.isnt_void(mail.Text) && Classes.Validator.isnt_void(username.Text) && Classes.Validator.isnt_void(password.Password))
            { // check if there is inputs
                if(Classes.Validator.check_username(username.Text).Equals("") && Classes.Validator.check_password(password.Password).Equals("") && Classes.Validator.check_mail(mail.Text).Equals(""))
                { // check if the fields are valid
                    User new_user = new User(username.Text, mail.Text, password.Password);
                    errors.Text = "The user added successfully!";

                    mail.Text = "";
                    username.Text = "";
                    password.Password = "";
                }
                else
                {
                    errors.Text = Classes.Validator.check_username(username.Text);
                    errors.Text += Classes.Validator.check_password(password.Password);
                    errors.Text += Classes.Validator.check_mail(mail.Text);
                }

            }
            else
            {
                errors.Text = "Sorry, some of the fields arre missing!";
            }
        }
    }
}
