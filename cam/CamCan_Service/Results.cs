using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class Results
    {
        public int scenarioID;
        public int[] answer;
        public int[] correct;

        public Results()
        {
            answer = new int[4];
            correct = new int[4];
        }

        public int scenario { get; set; }
        public int[] _answer { get; set; }
        public int[] _correct { get; set; }
    }
}