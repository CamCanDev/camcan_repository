using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class Question
    {
        private int questionID;
        private String question;
        private String ansA;
        private String ansB;
        private String ansC;
        private String ansD;
        private String correctAns;

        public int questionID { get;set;}
        public String question { get; set; }
        public String ansB { get; set; }
        public String ansA { get; set; }
        public String ansC { get; set; }
        public String ansD { get; set; }
        public String correctAns { get; set; }

    }


}