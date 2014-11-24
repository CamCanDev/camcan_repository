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
//WORKS NK 21/11
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
        //works NK 21/11
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            user.setUsername(txtUser.Text);
            password = txtPass.Text;

            //WebService connection
            Service1Client camcanService = new Service1Client();
            camcanService.returnUserCompleted += new EventHandler<returnUserCompletedEventArgs>(camcanService_returnUserProfileCompleted);
            camcanService.returnUserAsync(user.getUsername(), password);

            //Function to test the application without connection on the webservice(G.D)
            //user.testUser();
            //this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));
        }

        //Works NK 21/11
        //this is the event handler which is called when the event is triggered
        void camcanService_returnUserProfileCompleted(object sender, returnUserCompletedEventArgs e)
        {
            user.setUsername(user.getUsername());
            user.setCompleted(Convert.ToInt32(e.Result));        
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

    }
}