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
    public sealed partial class help : Page
    {
        int count = 1;
        string[,] sentences = { {"איך מתחילים?",  "במסך הפתיחה לחצו על כפתור ההרשמה\nכתבו את פרטיכם ולחצו על הרשמה\nלאחר מכן התחברו במסך הראשי"},
            {"ואז?",  ",תוכלו לפתוח חדר משחק חדש!\nלחצו על 'Create Room', בחרו את נושא הטריויה, דרגת הקושי, מספר השאלות והזמן שיוקצב ולכל שאלה ותתחילו!"},
            {"מה עושים במשחק?", "על המסך תופיע שאלה ו4 כפתורים בהם יהיו תשובות אפשריות. עליכם לקרוא את השאלה ואת התשובות וללחוץ על אחת התשובות שנראית לכם נכונה, מותר גם לנחש:)\nשימו לב! כל שאלה מוגבלת בזמן! הזדרזו וענו על השאלה לפני שנגמר הזמן!\n\nכל תשובה נכונה מזכה אתכם בנקודות לפי הזמן שלקח לכם לענות אותה, בסוף המשחק יופיעו על המסך הניקוד של כל המשתתפים בחדר."},
            {"איך הניקוד מחושב?", "בסוף המשחק יופיעו הסטטיסטיקות לגבי המשחק: ניקוד סופי שנצבר במשחק, זמן ממוצע לשאלה ואת רצף התשובות הנכונות הארוך ביותר\nהניקוד שיתקבל לתשובה נכונה הוא 100 נקודות בצירוף היחס בין הזמן שלקח לכם לענות בו ל60 שניות (הזמן המקסימלי)- ככל שתענו יותר מהר כך הניקוד שיתווסף יהיה גבוה יותר" },
            {"גם אני רוצה להיות אלוף!!", "גם אנחנו רוצים!\n\nכדי לדעת מה הדירוג שלך ביחס לשחקנים אחרים תוכל ללחוץ על כפתור 3 הגדולים במסך הפתיחה, משם תגיע לעמוד שמציג את 3 השחקנים הטובים ביותר\nרוצה להגיע לטבלה זו גם? אנחנו מאמינים בעבודה קשה, שחק יותר ותשתפר ואנחנו מאמינים שגם אתה תוכל להגיע לטבלה אגדית זו.\n\n\nאבל לא כולם חייבים להשתוות לאחרים, וזה בסדר! תוכל גם לראות את התוצאות האישיות שלך בלחיצה על כפתור הסטטוס האישי"},
            {"תודות וקרדיטים", "תכנה מצוינת זו פותחה על ידי אלומה גלברד המתכנתת המצוינת.\nתודות רבות ישלחו להורים שלי שהביאו אותי עד הלום, לרחל בן סימון הנהדרת, למורה למדעי הכלום והשטות שהאמינה בי לאורך רוב הדרך, למוכר בקפיטריה ולעכברים במטבח.\nלא נשכח לעד את כל הקורבנות בדרך\nאמן."},
        };

        public help()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            this.conTitle.Text = sentences[count - 1, 0];
            this.text.Text = sentences[count - 1, 1];
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (count > 1)
            {
                count--;
                this.textBlock.Text = count.ToString();
                this.conTitle.Text = sentences[count - 1, 0];
                this.text.Text = sentences[count - 1, 1];
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (count < 5)
            {
                count++;
                this.textBlock.Text = count.ToString();
                this.conTitle.Text = sentences[count - 1, 0];
                this.text.Text = sentences[count - 1, 1];
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
