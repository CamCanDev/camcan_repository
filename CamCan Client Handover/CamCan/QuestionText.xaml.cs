﻿using System;
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
using CamCan.CamCanService;

namespace CamCan
{
    public partial class MainPage : PhoneApplicationPage
    {        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {            
            //WebService connection
            Service1Client camcanService = new Service1Client();
            
            camcanService.returnScenarioCompleted += new EventHandler<returnScenarioCompletedEventArgs>(camcanService_returnScenarioCompleted);
            camcanService.returnScenarioAsync(Scenarios.scen.sID);

            //Function to test the application without connection on the webservice(G.D)
            //Scenarios.scen.testScenario();
            //tbScenText.Text = Scenarios.scen.text;
            //tbScenario.Text = Scenarios.scen.sID.ToString();

        }

        //this is the event handler which is called when the event is triggered
        void camcanService_returnScenarioCompleted(object sender, returnScenarioCompletedEventArgs e)
            {
            //adds the information returned in the User class (R.A.)

            //MessageBox.Show(e.Result._text);
            Scenarios.scen.text = e.Result._text;
            Scenarios.scen.videoLink = e.Result._videoLink;
            try
                {

            //get questions
            for (int i = 0; i < 4; i++)
                {
                    Question q = new Question();
                    
                    q.id = Convert.ToString(e.Result._questions[i]._id);
                    q.questionText = e.Result._questions[i]._questionText.Replace("\t", " ");
                    q.correctAnswer = e.Result._questions[i]._correctAns;
                    q.answer[0] = e.Result._questions[i]._ansA;
                    q.answer[1] = e.Result._questions[i]._ansB;
                    q.answer[2] = e.Result._questions[i]._ansC;
                    q.answer[3] = e.Result._questions[i]._ansD;
                    //add to scenario obj
                    Scenarios.scen.questions.Add(q);
                }
               }
            catch (Exception ex)
                {
        MessageBox.Show(ex.ToString());
        }
            
            tbScenText.Text = Scenarios.scen.text.ToString();
            //svText.DataContext = Scenarios.scen.text.ToString();
            tbScenario.Text = Scenarios.scen.sID.ToString();
            }

        private void ApplicationBarIconButton_Back(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));
        }
        private void ApplicationBarIconButton_Forward(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionPage.xaml", UriKind.Relative));
        }
        private void ApplicationBarIconButton_Video(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionVideo.xaml", UriKind.Relative));
        }
        private void ApplicationBarIconButton_Help(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }
    }
}