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
using Microsoft.Phone.Shell;

namespace CamCan
{
    public partial class Login : PhoneApplicationPage
    {
        static public UserProfile user = new UserProfile();
        String password;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            user.setUsername(txtUser.Text);
            password = txtPass.Text;

            //WebService connection
            //Service1Client camcanService = new Service1Client();
            //camcanService.returnUserCompleted += new EventHandler<returnUserCompletedEventArgs>(camcanService_returnUserProfileCompleted);
            //camcanService.returnUserAsync(user.getUsername(), password);

            //Function to test the application without connection on the webservice(G.D)
            user.testUser();
            this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));
        }

        //this is the event handler which is called when the event is triggered
        void camcanService_returnUserProfileCompleted(object sender, returnUserCompletedEventArgs e)
        {
            //adds the information returned in the User class
            user.setUsername(e.Result.name);
            user.setCompleted(e.Result.completed);
            try
            {
                if (user.getUsername().Equals("Empty"))
                {

                    MessageBox.Show("Username or/and Password is invalid!");

                }
                else
                {
                    this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Username or/and Password is invalid!");
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}