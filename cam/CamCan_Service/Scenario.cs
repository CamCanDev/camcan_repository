using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class Scenario
    {

        public Int32 scenarioID;
        public String videoLink;
        public String scenarioInformation;
        public Question[] questionArray;

        public Int32 _scenarioID{get; set;}
        public String _videoLink { get; set; }
        public String _scenarioInformation { get; set; }
        public Question[] _questionArray { get; set; }


    }
}