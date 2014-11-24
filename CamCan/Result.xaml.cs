using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;

namespace CamCan
{
    public partial class Result : PhoneApplicationPage
    {
        BitmapImage imgCorrect = new BitmapImage(new Uri("Images/done.png", UriKind.Relative));

        public Result()
        {
                      
            InitializeComponent();
            tbScenarioID.Text = Scenarios.scen.sID.ToString();
            userID.Text = Login.user.getUsername();
            textBlock.Text = Scenarios.scen.questions[0].questionText;
            textBlock1.Text = Scenarios.scen.questions[1].questionText;
            textBlock2.Text = Scenarios.scen.questions[2].questionText;
            textBlock3.Text = Scenarios.scen.questions[3].questionText;

            //code to check if selected answers match correct answers (R.A.)

            if (Scenarios.scen.questions[0].selectedAnswer.Equals(Scenarios.scen.questions[0].correctAnswer))
            {
                //Check if user has chosen the correct answer and if correct change image from wrong.png to done.png (R.A.)
                image1.Source = imgCorrect;
            }
            if (Scenarios.scen.questions[1].selectedAnswer.Equals(Scenarios.scen.questions[1].correctAnswer))
            {
                image2.Source = imgCorrect;
            }
            if (Scenarios.scen.questions[2].selectedAnswer.Equals(Scenarios.scen.questions[2].correctAnswer))
            {
                image3.Source = imgCorrect;
            }
            if (Scenarios.scen.questions[3].selectedAnswer.Equals(Scenarios.scen.questions[3].correctAnswer))
            {
                image4.Source = imgCorrect;
            }
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Finish.xaml", UriKind.Relative));
        }        
    }
}