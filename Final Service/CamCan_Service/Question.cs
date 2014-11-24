using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class Question
    {
            public int id;
            public String questionText;
            public String ansA;
            public String ansB;
            public String ansC;
            public String ansD;
            public String correctAns;

            public int _id { get; set; }
            public String _questionText { get; set; }
            public String _ansB { get; set; }
            public String _ansA { get; set; }
            public String _ansC { get; set; }
            public String _ansD { get; set; }
            public String _correctAns { get; set; }

    }
}