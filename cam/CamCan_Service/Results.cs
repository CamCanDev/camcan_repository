using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class Results
    {
        public int scenarioID;
        public int questionID;
        public String answer;
        public bool correct;

        public int scenario { get; set; }
        public int question { get; set; }
        public String _answer { get; set; }
        public bool _correct { get; set; }
    }
}