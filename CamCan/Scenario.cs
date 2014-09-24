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
using System.Collections.Generic;

namespace CamCan
{
    public class Scenario
    {
        
        public int sID { get; set; }
        public string text { get; set; }
        public string videoLink { get; set; }
        public List<Object> questions { get; set; }

    }
}
