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
    public partial class Scenarios : PhoneApplicationPage
    {
        public Scenarios()
        {
            InitializeComponent();
        }

        private void btnScn1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionVideo.xaml", UriKind.Relative));
        }

        private void btnScn3_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn4_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn5_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn6_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn7_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn8_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn9_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn10_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }


    }
}