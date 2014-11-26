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
using CamCan.CamCanService;

namespace CamCan
{
    public partial class Result : PhoneApplicationPage
    {
        BitmapImage imgCorrect = new BitmapImage(new Uri("Images/done.png", UriKind.Relative));

        String[] answers = new String[4]; //"s*q*a* - 1/0"

        public Result()
        {
                      
            InitializeComponent();
            tbScenarioID.Text = Scenarios.scen.sID.ToString();
            userID.Text = Login.user._username;
            textBlock.Text = Scenarios.scen.questions[0].questionText;
            textBlock1.Text = Scenarios.scen.questions[1].questionText;
            textBlock2.Text = Scenarios.scen.questions[2].questionText;
            textBlock3.Text = Scenarios.scen.questions[3].questionText;

            //code to check if selected answers match correct answers (R.A.)

            if (Scenarios.scen.questions[0].selectedAnswer.Equals(Scenarios.scen.questions[0].correctAnswer))
            {
                image1.Source = imgCorrect;
                //Formating the array with the answers for send back to the webservice
                answers[0] = "s" + Scenarios.scen._sID + "q1a" + Scenarios.scen.questions[0].optionSelected + " - 1";
            }
            else {
                answers[0] = "s" + Scenarios.scen._sID + "q1a" + Scenarios.scen.questions[0].optionSelected + " - 0";
            }

            if (Scenarios.scen.questions[1].selectedAnswer.Equals(Scenarios.scen.questions[1].correctAnswer))
            {
                image2.Source = imgCorrect;
                //Formating the array with the answers for send back to the webservice
                answers[1] = "s" + Scenarios.scen._sID + "q2a" + Scenarios.scen.questions[1].optionSelected + " - 1";
            }
            else
            {
                answers[1] = "s" + Scenarios.scen._sID + "q2a" + Scenarios.scen.questions[1].optionSelected + " - 0";
            }
            if (Scenarios.scen.questions[2].selectedAnswer.Equals(Scenarios.scen.questions[2].correctAnswer))
            {
                image3.Source = imgCorrect;
                //Formating the array with the answers for send back to the webservice
                answers[2] = "s" + Scenarios.scen._sID + "q3a" + Scenarios.scen.questions[2].optionSelected + " - 1";
            }
            else
            {
                answers[2] = "s" + Scenarios.scen._sID + "q3a" + Scenarios.scen.questions[2].optionSelected + " - 0";
            }
            if (Scenarios.scen.questions[3].selectedAnswer.Equals(Scenarios.scen.questions[3].correctAnswer))
            {
                image4.Source = imgCorrect;
                //Formating the array with the answers for send back to the webservice
                answers[3] = "s" + Scenarios.scen._sID + "q4a" + Scenarios.scen.questions[3].optionSelected + " - 1";
            }
            else
            {
                answers[3] = "s" + Scenarios.scen._sID + "q4a" + Scenarios.scen.questions[3].optionSelected + " - 0";
            }
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            //Send back to service and wait for 'true' string returned.
            //WebService connection
            Service1Client camcanService = new Service1Client();
            camcanService.insertAnswerCompleted += new EventHandler<insertAnswerCompletedEventArgs>(camcanService_insertAnswerCompleted);
            camcanService.insertAnswerAsync(Scenarios.scen._sID, answers.ToList(), Login.user._username);


        }

        void camcanService_insertAnswerCompleted(object sender, insertAnswerCompletedEventArgs e)
        {
            //Display msg to say that all uploaded
            MessageBox.Show("Results is: \n" + e.Result.ToString());
            this.NavigationService.Navigate(new Uri("/Finish.xaml", UriKind.Relative));
        }        
    }
}