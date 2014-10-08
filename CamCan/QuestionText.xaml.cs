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
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

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