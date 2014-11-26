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
    public partial class QuestionPage : PhoneApplicationPage
    {
        //Variables (R.A.)
        public int questionNum = 0;
        public String selected;

        public QuestionPage()
        {
            InitializeComponent();            
        }

        //If user clicks back, the context should be set to the previous question (R.A.)
        private void ApplicationBarIconButton_Back(object sender, EventArgs e)
        {
            if (questionNum.Equals(0))
            {
                this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
            } else{
                questionNum -= 1;
                this.NavigationService.GoBack();
                setContext();
            }            
        }

        //If user clicks forward, this sets the selected variable and executes the next() method, if no radio buttons are selected a messagebox is displayed telling the user to choose an answer (R.A.)
        private void ApplicationBarIconButton_Forward(object sender, EventArgs e)
        {
            if (radioButton1.IsChecked.Equals(true))
            {
                Scenarios.scen.questions[questionNum].selectedAnswer = textBlock1.Text;
                Scenarios.scen.questions[questionNum].optionSelected = 1;
                radioButton1.IsChecked = false;
                next();     
            }
            else if (radioButton2.IsChecked.Equals(true))
            {
                Scenarios.scen.questions[questionNum].selectedAnswer = textBlock2.Text;
                Scenarios.scen.questions[questionNum].optionSelected = 2;
                radioButton2.IsChecked = false;
                next();

            }
            else if (radioButton3.IsChecked.Equals(true))
            {
                Scenarios.scen.questions[questionNum].selectedAnswer = textBlock3.Text;
                Scenarios.scen.questions[questionNum].optionSelected = 3;
                radioButton3.IsChecked = false;
                next();
            }
            else if (radioButton4.IsChecked.Equals(true))
            {
                Scenarios.scen.questions[questionNum].selectedAnswer = textBlock4.Text;
                Scenarios.scen.questions[questionNum].optionSelected = 4;
                radioButton4.IsChecked = false;
                next();
            }
            else
            {
                MessageBox.Show("Please select an answer.");
            }
        }    
    
        private void ApplicationBarIconButton_Help(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }

        //This method sets the selected answer in the question object and moves to the next question, when all questions are complete it will navigate to the results page (R.A.)
        public void next()
        {
            if (questionNum < 3)
            {
                questionNum += 1;
                setContext();
            }
            else
            {
                this.NavigationService.Navigate(new Uri("/Result.xaml", UriKind.Relative));
            }
        }

        //Method to set the data context for the page (R.A.)
        private void setContext()
        {
        tbQuestionContent.Text = Scenarios.scen.questions[questionNum].questionText;
        textBlock1.Text = Scenarios.scen.questions[questionNum].answer[0].ToString();
        textBlock2.Text = Scenarios.scen.questions[questionNum].answer[1].ToString();
        textBlock3.Text = Scenarios.scen.questions[questionNum].answer[2].ToString();
        textBlock4.Text = Scenarios.scen.questions[questionNum].answer[3].ToString();


        //ContentPanel.DataContext = Scenarios.scen.questions[questionNum];
        }

        //Set data context on page load (R.A.)
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            setContext();
        }

    }
}