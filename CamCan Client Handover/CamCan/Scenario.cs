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
        public Int32 sID;
        public String videoLink;
        public String text;
        public List<Question> questions;

        public Int32 _sID { 
            get { return this.sID; } 
            set{this.sID = value; } 
            }
        public string _text { 
            get { return this.text; } 
            set {this.text = value; } 
            }
        public string _videoLink { 
            get { return this.videoLink; } 
            set {this.videoLink = value; } 
            }
        public List<Question> _questions { 
            get { return this.questions; }
            set { this.questions = value; }
        }

        public Scenario()
        {
             questions = new List<Question>();
        }

        public void testScenario()
        {
            text = "Text scenario teste ";
            videoLink = "/Videos/ROUGH FOR APP TESTING_WEB - Cellular.mp4";
            Question quest = new Question();
            quest.testQuestion();
            questions.Add(quest);
            questions.Add(quest);
            questions.Add(quest);
            questions.Add(quest);
        }

    }
}
