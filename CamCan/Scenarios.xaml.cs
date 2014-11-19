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
        static public Scenario scen = new Scenario();
        
        public Scenarios()
        {
            InitializeComponent();
        }

        //Click events for scenario selection. Navigates to question page and parses the id for the chosen scenario (R.A.)
        private void btnScn1_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 1;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml" , UriKind.Relative));
        }

        private void btnScn2_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 2;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn3_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 3;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn4_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 4;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn5_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 5;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn6_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 6;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn7_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 7;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn8_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 8;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn9_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 9;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }

        private void btnScn10_Click(object sender, RoutedEventArgs e)
        {
            scen.sID = 10;
            this.NavigationService.Navigate(new Uri("/QuestionText.xaml", UriKind.Relative));
        }


        //App bar click events. Navigates to info or help page (R.A.)
        private void ApplicationBarIconButton_Info_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Information.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Help_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }

        //On page load the buttons are set up depending on how many scenarios the user has completed (R.A.)
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Login.user.getCompleted())
            {
                case 0:
                    btnScn1.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn1.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn2.IsHitTestVisible = false;
                    btnScn2.Background = new SolidColorBrush(Colors.Gray);
                    btnScn3.IsHitTestVisible = false;
                    btnScn3.Background = new SolidColorBrush(Colors.Gray);
                    btnScn4.IsHitTestVisible = false;
                    btnScn4.Background = new SolidColorBrush(Colors.Gray);
                    btnScn5.IsHitTestVisible = false;
                    btnScn5.Background = new SolidColorBrush(Colors.Gray);
                    btnScn6.IsHitTestVisible = false;
                    btnScn6.Background = new SolidColorBrush(Colors.Gray);
                    btnScn7.IsHitTestVisible = false;
                    btnScn7.Background = new SolidColorBrush(Colors.Gray);
                    btnScn8.IsHitTestVisible = false;
                    btnScn8.Background = new SolidColorBrush(Colors.Gray);
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;

                case 1:
                    btnScn2.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn2.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn3.IsHitTestVisible = false;
                    btnScn3.Background = new SolidColorBrush(Colors.Gray);
                    btnScn4.IsHitTestVisible = false;
                    btnScn4.Background = new SolidColorBrush(Colors.Gray);
                    btnScn5.IsHitTestVisible = false;
                    btnScn5.Background = new SolidColorBrush(Colors.Gray);
                    btnScn6.IsHitTestVisible = false;
                    btnScn6.Background = new SolidColorBrush(Colors.Gray);
                    btnScn7.IsHitTestVisible = false;
                    btnScn7.Background = new SolidColorBrush(Colors.Gray);
                    btnScn8.IsHitTestVisible = false;
                    btnScn8.Background = new SolidColorBrush(Colors.Gray);
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;

                case 2:
                    btnScn3.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn3.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn4.IsHitTestVisible = false;
                    btnScn4.Background = new SolidColorBrush(Colors.Gray);
                    btnScn5.IsHitTestVisible = false;
                    btnScn5.Background = new SolidColorBrush(Colors.Gray);
                    btnScn6.IsHitTestVisible = false;
                    btnScn6.Background = new SolidColorBrush(Colors.Gray);
                    btnScn7.IsHitTestVisible = false;
                    btnScn7.Background = new SolidColorBrush(Colors.Gray);
                    btnScn8.IsHitTestVisible = false;
                    btnScn8.Background = new SolidColorBrush(Colors.Gray);
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    
                    break;

                case 3:
                    btnScn4.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn4.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn5.IsHitTestVisible = false;
                    btnScn5.Background = new SolidColorBrush(Colors.Gray);
                    btnScn6.IsHitTestVisible = false;
                    btnScn6.Background = new SolidColorBrush(Colors.Gray);
                    btnScn7.IsHitTestVisible = false;
                    btnScn7.Background = new SolidColorBrush(Colors.Gray);
                    btnScn8.IsHitTestVisible = false;
                    btnScn8.Background = new SolidColorBrush(Colors.Gray);
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;

                case 4:
                    btnScn5.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn5.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn6.IsHitTestVisible = false;
                    btnScn6.Background = new SolidColorBrush(Colors.Gray);
                    btnScn7.IsHitTestVisible = false;
                    btnScn7.Background = new SolidColorBrush(Colors.Gray);
                    btnScn8.IsHitTestVisible = false;
                    btnScn8.Background = new SolidColorBrush(Colors.Gray);
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;

                case 5:
                    btnScn6.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn6.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn7.IsHitTestVisible = false;
                    btnScn7.Background = new SolidColorBrush(Colors.Gray);
                    btnScn8.IsHitTestVisible = false;
                    btnScn8.Background = new SolidColorBrush(Colors.Gray);
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;

                case 6:
                    btnScn7.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn7.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn8.IsHitTestVisible = false;
                    btnScn8.Background = new SolidColorBrush(Colors.Gray);
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;
                    
                case 7:
                    btnScn8.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn8.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn9.IsHitTestVisible = false;
                    btnScn9.Background = new SolidColorBrush(Colors.Gray);
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;

                case 8:
                    btnScn9.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn9.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    btnScn10.IsHitTestVisible = false;
                    btnScn10.Background = new SolidColorBrush(Colors.Gray);
                    break;

                case 9:
                    btnScn10.SetValue(BorderThicknessProperty, new Thickness(7));
                    btnScn10.SetValue(BorderBrushProperty, new SolidColorBrush(Colors.Black));
                    break;

                case 10:
                    break;
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Information.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }
    }
}