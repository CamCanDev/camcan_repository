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
    public partial class finish : PhoneApplicationPage
    {
        public finish()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Service1Client camcanService = new Service1Client();
            camcanService.returnUserCompleted += new EventHandler<returnUserCompletedEventArgs>(camcanService_returnUserProfileCompleted);
            camcanService.returnUserAsync(Login.user._username, Login.user._username, Login.user._pass);
        }

        //Works NK 21/11
        //this is the event handler which is called when the event is triggered
        void camcanService_returnUserProfileCompleted(object sender, returnUserCompletedEventArgs e)
        {
            //user.setUsername(user._username);
            Login.user._completed = Convert.ToInt32(e.Result);        
            try
            {
                if (e.Result.Equals(-99))
                    {
                    MessageBox.Show("Username or/and Password is invalid, please try again");
                    }
                else if (e.Result.Equals(-100))
                        {
                        MessageBox.Show("Please check Internet connections");
                        }
                else
                    {
                    this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Database exception!");
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
            {
                tbScenText.Text = "Thank you for completing this Scenario. Your results will be sent to your coordinator.";
            }
    }
}