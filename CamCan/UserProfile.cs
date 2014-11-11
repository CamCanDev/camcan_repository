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
        private String username { get; set; }
        private int completed { get; set; }

        public void setUsername(String username){
             this.username = username;
        }

        public String getUsername(){
            return username;
        }

        public void setCompleted(int completed){
             this.completed = completed;
        }

        public int getCompleted(){
            return completed;
        }
    }
}
