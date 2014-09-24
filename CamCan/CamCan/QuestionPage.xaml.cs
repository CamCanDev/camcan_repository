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
    public partial class QuestionPage : PhoneApplicationPage
    {

        public Question testQuestion;

        public QuestionPage()
        {
            InitializeComponent();
            testQuestion = new Question();

            // test data
            testQuestion.testQuestion();

            ContentPanel.DataContext = testQuestion;
        }


    }
}