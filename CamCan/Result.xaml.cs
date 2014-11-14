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

namespace CamCan
{
    public partial class Result : PhoneApplicationPage
    {
        public Result()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Feedback.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            textBlock.Text = MainPage.scen.questions[0].questionText;
            textBlock1.Text = MainPage.scen.questions[1].questionText;
            textBlock2.Text = MainPage.scen.questions[2].questionText;
            textBlock3.Text = MainPage.scen.questions[3].questionText;

            //code to check if selected answers match correct answers (R.A.)

            if (MainPage.scen.questions[0].selectedAnswer == MainPage.scen.questions[0].correctAnswer)
            {
                //Test for checking if answer is correct, to be replaced with code to change image from wrong.png to done.png (R.A.)
                MessageBox.Show("Correct");
            }
            if (MainPage.scen.questions[1].selectedAnswer == MainPage.scen.questions[1].correctAnswer)
            {

            }
            if (MainPage.scen.questions[2].selectedAnswer == MainPage.scen.questions[2].correctAnswer)
            {

            }
            if (MainPage.scen.questions[3].selectedAnswer == MainPage.scen.questions[3].correctAnswer)
            {

            }
        }
    }
}