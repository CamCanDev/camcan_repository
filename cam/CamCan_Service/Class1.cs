using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class UserProfile
    {
        public String name;
        public String password;
        public int completed;

        public String _name{ get; set; }
        public String _password { get; set; }
        public int _completed{ get; set; }
    }
}