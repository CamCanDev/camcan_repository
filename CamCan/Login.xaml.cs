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
    public partial class Login : PhoneApplicationPage
    {
        public String user = "1";
        public String pass = "1";


        public Login()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // if user name and password correct then enter the application
            if ((txtUser.Text == user) && (txtPass.Text == pass))
            {
                txtUser.Text = "";
                txtPass.Text = "";
                this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));

            }
            else
            {
                MessageBox.Show("Invalid Entry! ");
            }
        }

        private void txtUser_Tap(object sender, GestureEventArgs e)
        {
            txtUser.Text = "";
        }

        private void txtPass_Tap(object sender, GestureEventArgs e)
        {
            txtPass.Text = "";
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            UserProfile user1= new UserProfile();
            user1.setUsername = "1";
            user1.setPassword = "1";
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Information.xaml", UriKind.Relative));
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}