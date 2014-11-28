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
    public partial class QuestionVideo : PhoneApplicationPage
    {
        public QuestionVideo()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Back(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));
        }
        private void ApplicationBarIconButton_Forward(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionPage.xaml", UriKind.Relative));
        }
        private void ApplicationBarIconButton_Text(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }
        private void ApplicationBarIconButton_Help(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            mediaElement1.Source = new Uri(Scenarios.scen.videoLink, UriKind.Relative);
            tbScenario.Text = Scenarios.scen.sID.ToString();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e) // This button click section allows the user to play the video (CH)
        {
            mediaElement1.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)// This button click section allows the user to pause the video (CH)
        {
            mediaElement1.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)// This button click section allows the user to stop the video (CH)
        {
            mediaElement1.Stop();
        }
    }
}