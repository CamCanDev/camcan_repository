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
using CamCan.CamCanService;

namespace CamCan
{
    public partial class MainPage : PhoneApplicationPage
    {
        static public Scenario scen = new Scenario();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            int scenId = Convert.ToInt32(NavigationContext.QueryString["ScenId"]);
            //WebService connection
            Service1Client camcanService = new Service1Client();
            camcanService.returnScenarioCompleted += new EventHandler<returnScenarioCompletedEventArgs>(camcanService_returnScenarioCompleted);
            camcanService.returnScenarioAsync(scenId);
        }

        //this is the event handler which is called when the event is triggered
        void camcanService_returnScenarioCompleted(object sender, returnScenarioCompletedEventArgs e)
        {
            //adds the information returned in the User class (R.A.)

            scen.sID = e.Result._scenarioID;
            scen.text = e.Result._scenarioInformation;
            scen.videoLink = e.Result._videoLink;
            //scen.questions = e.Result.questionArray; This isn't working yet (R.A.)
            tbScenText.Text = scen.text;




        }

        private void ApplicationBarIconButton_Back(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
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