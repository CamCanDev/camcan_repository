using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamCan_Service
{
    public class Scenario
    {

        public Int32 sID;
        public String videoLink;
        public String text;
        public List<Question> questions;

        public Int32 _sID { get; set; }
        public String _videoLink { get; set; }
        public String _text { get; set; }
        public List<Question> _questions { get; set; }

        public Scenario()
        {
            
        }
        //public Int32 sID;
        //public String videoLink;
        //public String text;
        //public List<Question> questions;

        //public Int32 _sID{
        //    get
        //    {
        //        return sID;
        //    }
        //    set
        //    {
        //        sID = value;
        //    }
        //}
        //public String _videoLink {
        //    get
        //    {
        //        return videoLink;
        //    }
        //    set
        //    {
        //        videoLink = value;
        //    } 
        //}
        //public String _text {
        //    get
        //    {
        //        return text;
        //    }
        //    set
        //    {
        //        text = value;
        //    } 
        //}
        //public List<Question> _questions {
        //    get
        //    {
        //        return questions;
        //    }
        //    set
        //    {
        //        questions = value;
        //    } 
        //}


    }
}