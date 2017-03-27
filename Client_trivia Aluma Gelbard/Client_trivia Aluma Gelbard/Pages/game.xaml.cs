using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Text;
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
    public sealed partial class game : Page
    {
        string[] order = new string[4];
        bool timerOn = false;
        int chosenAnswer = -1;

        public object PlayMusic { get; private set; }

        public game()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (Classes.GameManager._questions_array == null)
            { // Protect your code!!
                var dialog = new MessageDialog("Error");
                var res = dialog.ShowAsync();
                Frame.GoBack();
            }

            clear(); // Get ready..
            await Task.Delay(500);
            question.Text = "Set.."; // DRAMA!
            await Task.Delay(500);
            question.Text = "..GO!"; // DRAMA!
            await Task.Delay(500);


            playgame(); // START!
            // playgame() is ASYNC!!! BE CAREFUL
        }

        private async void playgame()
        {
            double time = 0;

            // Make all music stuff work
            var element = new MediaElement();
            var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"\Pictures\");
            var file = await folder.GetFileAsync("correct.wav");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

            for (Classes.GameManager._counter = 0; Classes.GameManager._counter < Classes.GameManager._amount; Classes.GameManager._counter++)
            { // run over questions
                amount.Text = Classes.GameManager._counter + " / " + Classes.GameManager._amount; // count question
                ShowQuestion();
                timerOn = true; // Start run the timer!!


                for (int i = 0; i < Classes.GameManager._timer && timerOn; i++)
                { // run over time per question
                    timer.Text = (Classes.GameManager._timer - i).ToString();
                    for(int j=0; j<100 && timerOn; j++) {
                        // a little bit math.. :)
                        await Task.Delay(10);
                        time += 0.01;
                    }
                }
                await Task.Delay(1000); // Synco!!!


                if (!timerOn && chosenAnswer != -1)
                { // The user chose answer: check if it is true!
                    if (order[chosenAnswer].Equals(Classes.GameManager._questions_array[Classes.GameManager._counter].trueAnswer))
                    { // The user chose answer: true
                        file = await folder.GetFileAsync("correct.wav");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        element.SetSource(stream, "");
                        element.Play();

                        Classes.GameManager.UpdateStats(true, Convert.ToInt32(100 + 60/time), time);
                    }
                    else
                    { // The user chose answer: false
                        file = await folder.GetFileAsync("wrong.wav");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        element.SetSource(stream, "");
                        element.Play();
                    }
                }

                else
                { // The user is GAY and did not chose answer.. SHAME SHAME
                    file = await folder.GetFileAsync("wrong.wav");
                    stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    element.SetSource(stream, "");
                    element.Play();
                }


                // get ready for the next question
                timerOn = false;
                chosenAnswer = -1;
            }

            // Safetly clean and close

            Classes.GameManager.SaveStats();
            Classes.GameManager.ClearGame();
            Frame.GoBack(); // this function is async. Be careful while using Frame.GoBack()
        }

        /* The follow methods do nothing but graphic */

        private void ShowQuestion()
        {
            /* This function randomize the available answers */

            // Show the question
            question.Text = Classes.GameManager._questions_array[Classes.GameManager._counter].question;

            // Initail the answers array
            order[0] = Classes.GameManager._questions_array[Classes.GameManager._counter].trueAnswer;
            order[1] = Classes.GameManager._questions_array[Classes.GameManager._counter].answer_2;
            order[2] = Classes.GameManager._questions_array[Classes.GameManager._counter].answer_3;
            order[3] = Classes.GameManager._questions_array[Classes.GameManager._counter].answer_4;

            // Shuffle!
            new Random().Shuffle<string>(order); // I wrote an extension to RANDOM class.

            // Show the answers
            answer1.Text = order[0];
            answer2.Text = order[1];
            answer3.Text = order[2];
            answer4.Text = order[3];
        }

        private void clear()
        {
            question.Text = "Get ready..";
            answer1.Text = "";
            answer2.Text = "";
            answer3.Text = "";
            answer4.Text = "";
            timer.Text = (Classes.GameManager._timer).ToString();
            amount.Text = "0 / " + Classes.GameManager._amount;
        }

        private async void answer1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (timerOn)
            {
                timerOn = false;
                chosenAnswer = 0;

                TextBlock b = (TextBlock)sender;
                b.FontWeight = FontWeights.ExtraBold;
                b.FontSize = 65;
                await Task.Delay(1000);
                b.FontWeight = FontWeights.Normal;
                b.FontSize = 45;
            }
        }

        private async void answer2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (timerOn)
            {
                timerOn = false;
                chosenAnswer = 1;

                TextBlock b = (TextBlock)sender;
                b.FontWeight = FontWeights.ExtraBold;
                b.FontSize = 65;
                await Task.Delay(1000);
                b.FontWeight = FontWeights.Normal;
                b.FontSize = 45;
            }
        }

        private async void answer3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (timerOn)
            {
                timerOn = false;
                chosenAnswer = 2;

                TextBlock b = (TextBlock)sender;
                b.FontWeight = FontWeights.ExtraBold;
                b.FontSize = 65;
                await Task.Delay(1000);
                b.FontWeight = FontWeights.Normal;
                b.FontSize = 45;
            }
        }

        private async void answer4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (timerOn)
            {
                timerOn = false;
                chosenAnswer = 3;

                TextBlock b = (TextBlock)sender;
                b.FontWeight = FontWeights.ExtraBold;
                b.FontSize = 65;
                await Task.Delay(1000);
                b.FontWeight = FontWeights.Normal;
                b.FontSize = 45;
            }
        }
    }

    /* Indented class */
    static class RandomExtensions
    { // RandomExtensions: Shuffle any kind of array
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }

}
