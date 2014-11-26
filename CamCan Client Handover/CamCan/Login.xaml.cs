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
//Using for loading page
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Threading;
//WORKS NK 21/11
namespace CamCan
{
    public partial class Login : PhoneApplicationPage
    {
        static public UserProfile user = new UserProfile();
        private Popup popup;
        private BackgroundWorker backroungWorker;
        // Constructor

        public Login()
        {
            InitializeComponent();           
        }
        private void ShowSplash()
        {
            this.popup = new Popup();
            this.popup.Child = new LoadingPage();
            this.popup.IsOpen = true;
            StartLoadingData();
            
        }

        private void StartLoadingData()
        {
        
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;

            }
            );
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //here we can load data
            Thread.Sleep(2000);
        }
        //works NK 21/11
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            user._username = txtUser.Text;
            user._pass = txtPass.Text;
            ShowSplash();
            //WebService connection
            Service1Client camcanService = new Service1Client();
            camcanService.returnUserCompleted += new EventHandler<returnUserCompletedEventArgs>(camcanService_returnUserProfileCompleted);
            camcanService.returnUserAsync(user._username, user._username, user._pass);
           
            //Function to test the application without connection on the webservice(G.D)
            //user.testUser();
            //this.NavigationService.Navigate(new Uri("/Scenarios.xaml", UriKind.Relative));
        }

        //Works NK 21/11
        //this is the event handler which is called when the event is triggered
        void camcanService_returnUserProfileCompleted(object sender, returnUserCompletedEventArgs e)
        {
            //user.setUsername(user._username);
            user._completed = Convert.ToInt32(e.Result);        
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