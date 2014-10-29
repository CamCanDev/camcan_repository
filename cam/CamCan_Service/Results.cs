using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class Results
    {
        private int scenarioID;
        private int questionID;
        private String answer;
        private bool correct;

        public int scenario { get; set; }
        public int question { get; set; }
        public String _answer { get; set; }
        public bool _correct { get; set; }
    }
}