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
using System.ComponentModel;

/*
 *  Question Class
 *  
 *  Gustavo, James and James (and not so much Jordan)
 * 
 */ 
namespace CamCan
{
    public class Question : INotifyPropertyChanged
    {
        
        /*
         * Variables
         * 
         */
        
        public string id { get; set; }
        public string questionText { get; set; }
        public string[] answer { get; set; }
        public int _selectedAnswer;
        public int selectedAnswer
        {
            get { return _selectedAnswer; }
            set
            {
                _selectedAnswer = value;
                PropChanged("selectedAnswer");
            }
        }
        public int correctAnswer { get; set; }


        /*
         *  Constructor(s)
         */

        public Question()
        {
            answer = new string[4];
        }

        public Question(string id, string questionText, string[] answer, int correctAnswer)
        {
            this.id = id;
            this.questionText = questionText;
            this.answer = answer;
            this.correctAnswer = correctAnswer;
        }

        /*
         *  Methods
         */
        public event PropertyChangedEventHandler PropertyChanged;

        private void PropChanged(string propSelectAnswer)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propSelectAnswer));
            }
        }

        /*
         *  Test Questions
         */ 

        public void testQuestion() {

            id = "12345";
            questionText = "Question test !! ";
            answer[0] = "Answer 1";
            answer[1] = "Answer 2";
            answer[2] = "Answer 3";
            answer[3] = "Answer 4";
            correctAnswer = 3;

        }

    }
}
