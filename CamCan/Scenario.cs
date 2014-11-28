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

//these are the scenario getters and setters
namespace CamCan
{
    public class Scenario
    {
        
        public int sID { get; set; }
        public string text { get; set; }
        public string videoLink { get; set; }
        public List<Question> questions { get; set; }

        public Scenario()
        {
            questions = new List<Question>();
            
        }

        public void testScenario()
        {
            text = "Text scenario teste ";
            videoLink = "/Videos/ROUGH FOR APP TESTING_WEB - Cellular.mp4"; // this is the link to the video (KM)
            Question quest = new Question();
            quest.testQuestion();
            questions.Add(quest);
            questions.Add(quest);
            questions.Add(quest);
            questions.Add(quest);

        }

    }
}
