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
        private String username;
        private int completed;

         public String setUsername 
         {
             set { username = value; }
         }

        public String getUsername
        {
            get { return username; }
        }

        public int getCompleted
        {
            get { return completed; }
        }
    }
}
