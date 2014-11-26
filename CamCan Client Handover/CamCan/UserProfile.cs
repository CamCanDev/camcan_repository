using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CamCan
{
    public class UserProfile
    {
        public String username;
        public int completed;
        public String pass;

        public String _username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public int _completed
        {
            get { return this.completed; }
            set { this.completed = value; }
        }

        public String _pass
        {
            get { return this.pass; }
            set { this.pass = value; }
        }
    
        public void testUser()
        {
            username = "Admin test";
            completed = 5;

        }
    }
}
