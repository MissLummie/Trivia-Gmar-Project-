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
    public sealed partial class addQues : Page
    {
        public addQues()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(Classes.Validator.isnt_void(question.Text) && Classes.Validator.isnt_void(trueans.Text) && Classes.Validator.isnt_void(ans2.Text) && Classes.Validator.isnt_void(ans3.Text) && Classes.Validator.isnt_void(ans4.Text))
            { // check if the question and answers written
                if(subject.SelectedValue != null && level.SelectedValue != null)
                { // check if there is a subject and level
                    Question new_question = new Question(question.Text, trueans.Text, ans2.Text, ans3.Text, ans4.Text, int.Parse((level.SelectedItem as ComboBoxItem).Content.ToString()), (subject.SelectedItem as ComboBoxItem).Content.ToString());
                    error.Text = "The question added successfully!";

                    // reset:
                    question.Text = "";
                    trueans.Text = "";
                    ans2.Text = "";
                    ans3.Text = "";
                    ans4.Text = "";
                    subject.SelectedValue = null;
                    level.SelectedValue = null;
                }
                else
                {
                    error.Text = "Subject or level are missing!";
                }
            }
            else
            {
                error.Text = "Sorry, some of the fields arre missing!";
            }
        }
    }
}
