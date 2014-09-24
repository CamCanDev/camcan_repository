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
    public partial class MainPage : PhoneApplicationPage
    {
        //variables to hold hardcoded data
        public int id = 1;
        String text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci ta";




        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += PhoneApplicationPage_Loaded;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            Scenario s = new Scenario();
            s.sID = id;            
            s.text = text;
            PageTitle.Text = "Scenario " + s.sID;
            ContentPanel.DataContext = s;
            //
        }
    }
}