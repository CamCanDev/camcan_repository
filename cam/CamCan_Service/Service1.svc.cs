﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace CamCan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        
        // 
        [WebMethod]
        public UserProfile returnUser(String user, String pass)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            String mD5Password;

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {

                cnn.Open();

                // Convert password to MD5
                //mD5Password = CalculateMD5Hash(pass);

                String sql = String.Format("SELECT * FROM dgn6la8u0_users WHERE user_login = \"{0}\" and user_pass = \"{1}\"", user, pass);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "users");
                UserProfile u = new UserProfile();
                try
                {

                    //Returns empty strings if user does not exist
                    if (ds.Tables.Count == 0)
                    {
                        u.name = "";
                        u.password = "";
                    }

                    //If dataset contains elements
                    else
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            u.name = Convert.ToString(dr["user_login"]);
                            u.password = pass;
                        }
                    }
                }
                catch (Exception ex)
                {
                    u.name = ex.ToString();
                }

                return u;
            }
        }


        //--------------------------------------------------------------------
        //Returns a scenario
        public Scenario returnScenario(int scenarioNum)
        {

            //Creating the connection string
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            //Accessing the database via the connection string

            int idStart= 0;
            String scenString = "Scenario " + scenarioNum;
            Scenario s = new Scenario();
            int id=0;
            String vidLink;
            String[] answers = new String[4];

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                //Question Object to be returned by method
                Question[] retQuest = new Question[4];
                String scenText = "";

                cnn.Open();
                String sql = String.Format("SELECT id, description from dgn6la8u0_frm_fields where name = \"{0}\"",scenString);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                try{
                    
                    //Get Data from table
                    foreach(DataRow dr in ds.Tables[0].Rows)
                        {
                            id = Convert.ToInt32(dr["id"]);
                            idStart = id + 1;
                            scenText = Convert.ToString(dr["description"]);
                        }
                
                    //add to scenario
                    s.scenarioID = id;
                    s.scenarioInformation = getScenarionText(scenText);
                    vidLink = getVideoLink(scenText);
                    s.videoLink = vidLink;

                
                }
                catch(Exception ex)
                {
                    //Do something
                    s.scenarioInformation = ex.ToString();
                }

                sql = String.Format("SELECT name, options from dgn6la8u0_frm_fields where id in ({0},{1},{2},{3})",idStart ,idStart + 1,idStart + 2,idStart + 3);
                da = new MySqlDataAdapter(sql, cnn);
                ds = new DataSet();
                da.Fill(ds);
                int i = 0;
                try{
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        retQuest[i].questionText = Convert.ToString(dr["name"]);
                        answers = getAnswers(Convert.ToString(dr["options"]));
                        retQuest[i].ansA = answers[0];
                        retQuest[i].ansB = answers[1];
                        retQuest[i].ansC = answers[2];
                        retQuest[i].ansD = answers[3];
                        i++;
                    }
                
                    // Add questions to scenario
                    s.questionArray = retQuest;

                }
                catch(Exception ex)
                {
                    //Do Something
                    s.scenarioInformation = ex.ToString();
                }

                return s;
            }
        }

        
        //gets user and password and returns the scenario completed
        [WebMethod]
        public Int32 returnComleted(Int32 user)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            String record= "";
            int max=0, compare;

            //
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                // Returns user id and corresponding completion string
                String sql = String.Format("SELECT i.user_id, im.meta_value FROM `dgn6la8u0_frm_item_metas` im JOIN `dgn6la8u0_frm_items` i ON im.item_id=i.id WHERE user_id = {0}",user);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                // find max scenarion number
                foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //get scen number from dataset
                        compare = Convert.ToInt32(Convert.ToString(dr["meta_value"]).ToCharArray()[1]);
                        if(compare>max)
                        {
                            max= compare;
                        }
                    }
                 

            }
            return max;      
                                 
            }
            
            


        /// <summary>
        /// 
        /// </summary>
        /// <param name="results"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [WebMethod]
        public String insertAnswer(String results, String user)
        {
            String sql = "";
            Int32 Empid = -1;
            if (results.Length != 10) {
                return "The answer must be in the format s1q1a1 - 1";
            }
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();
                    sql = String.Format("SELECT i.user_id, im.meta_value FROM `dgn6la8u0_frm_item_metas` im JOIN `dgn6la8u0_frm_items` i ON im.item_id=i.id WHERE user_id = {0}",user);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    //returns rows
                    Empid = Convert.ToInt32(cmd.ExecuteScalar());
                    //now we have the EmpID we can continue

                    sql = String.Format("INSERT INTO `dgn6la8u0_frm_item_metas`(meta_value, item_id, created_at) VALUES('?', '?', CURDATE()");
                    //sql = String.Format("Insert into results (employeeID, scenarioID, questionID, answers, correct) values ('{0}')", results);
                    MySqlCommand cmd2 = new MySqlCommand(sql, cnn);
                    cmd2.ExecuteNonQuery();
                    return "Inserted";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }




        [WebMethod]
        public Results showResults(int scenarioNum, int userID)
        {
            //Creating the connection string
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            //Increments each found scenarion
            int incrementer = 0;
            //Accessing the database via the connection string
            Results result = new Results();

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                String sql = String.Format("SELECT i.user_id, im.meta_value FROM `dgn6la8u0_frm_item_metas` im JOIN `dgn6la8u0_frm_items` i ON im.item_id=i.id WHERE user_id = {0}",userID);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                //Find all match scenario numbers
                foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        //get scen number from dataset
                        if (scenarioNum == Convert.ToInt32(Convert.ToString(dr["meta_value"]).ToCharArray()[1]))
                        {
                            if (incrementer > 3) break;
                            result.answer[incrementer] = Convert.ToInt32(Convert.ToString(dr["meta_value"]).ToCharArray()[5]);
                            result.correct[incrementer] = Convert.ToInt32(Convert.ToString(dr["meta_value"]).ToCharArray()[9]);
                            incrementer++;
                        }

                    }

            }

            //Retunr the result
            return result;
        }




        private Boolean convertToResult(String boolString)
        {
            //Get the first Char of the parsed string
            Char result = boolString.ToUpper().ToCharArray()[0];

                
            // Return True if 'Y' false other wise
            return (result == 'Y');

        }

        //Convert a string to MD5
        private string CalculateMD5Hash(string input)
            {
                // step 1, calculate MD5 hash from input
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);
 
                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }


        // Returns the youtube video link.
        private String getVideoLink(String bigString)
        {
            
            String smallString;
            Boolean found = false;
            char[] seps = {'\"'};
            String[] values = bigString.Split(seps);
            int correctIndex = 0;

            //Find the String after src
            for(int i = 0; i<values.Length; i++)
            {
                if(values[i].Contains("src="))
                {
                    found = true;
                    correctIndex = i + 1;
                    break;
                }
            }

            //Returns the video link
            if(found)
            {
                smallString = values[correctIndex];
                return smallString;
            }
            else
                return "No Video Link Found";
        }

        //Get the scenario Text

        //May Change depeneding on Database changes
        //Will get data from the pro quiz question table
        private String getScenarionText(String bigString, int scenarioNum)
        {
            
            // Start and End of the scenarion Text substring
            int start,end,length;


            //Check if bigString contains "Scenarion (scenario Num)"
            if(bigString.ToUpper().Contains("SCENARIO " + scenarioNum))
            {
                //Find Start of substring
                start = bigString.ToUpper().IndexOf("SCENARIO " + scenarioNum);

                //Find end (Assume first question will start with "1.")
                end = bigString.IndexOf("1.");

                //Calculate length of scenarion text
                length = end - start;

                //Return the substring
                return bigString.Substring(start,length).Trim();

            } 
            // If no Scenario text can be found
            else
            {
                return "No Scenario Text Found";
            }
        }

        //Returns the nth question for a scenario
        private Question getQuestion(String bigString, String ans, int questionNum)
        {
            //Question Object to be returned by method
            Question retQuest = new Question();

            int start,end,length;

            String[] answers = new String[4];

            //Check if bigString contains the question number
            if(bigString.ToUpper().Contains(questionNum + "."))
            {
                
                //Get Question text----
                start = bigString.ToUpper().IndexOf(questionNum + ".");

                //Find end (Assume first answer will start with "a)")
                end = bigString.ToUpper().IndexOf("?");
                length = end - start +1;

                //Set the question text
                retQuest.questionText = bigString.Substring(start, length).Trim();
                
                /*
                //get answers a) - d)
                start = bigString.ToUpper().IndexOf("a)");

                //Till start of next question ("b)")
                end = bigString.ToUpper().IndexOf("b)");
                length = end - start;

                //Set as firt answer
                retQuest.ansA = bigString.Substring(start, length).Trim();

                //Repeat for next 3 answers ----

                //Question b
                start = bigString.ToUpper().IndexOf("b)");
                end = bigString.ToUpper().IndexOf("c)");
                length = end - start;
                retQuest.ansB = bigString.Substring(start, length).Trim();

                //question c
                start = bigString.ToUpper().IndexOf("c)");
                end = bigString.ToUpper().IndexOf("d)");
                length = end - start;
                retQuest.ansC = bigString.Substring(start, length).Trim();

                //question c
                start = bigString.ToUpper().IndexOf("d)");
                end = bigString.ToUpper().IndexOf("?");
                length = end - start;
                retQuest.ansC = bigString.Substring(start, length).Trim(); */

                //Get answers
                answers = getAnswers(ans);

                //store in question
                retQuest.ansA = answers[0];
                retQuest.ansB = answers[1];
                retQuest.ansC = answers[2];
                retQuest.ansD = answers[3];

                return retQuest;
            
            }
            //Return a question with no data
            else
            {
                retQuest.questionText = "Cannot Find Question";
                return retQuest;
            }
        }



        /// <summary>
        ///   Returns the answers to a question
        /// </summary>
        /// <param name="bigString"></param>
        /// <returns> String[] </returns>
        private String[] getAnswers(String bigString)
        {
            //New String
            String[] answers = new String[4];
            int start, end, length;

            //Asnwer A
            start = bigString.IndexOf("a)");
            end = bigString.IndexOf("\"",start);
            length = end - start;
            answers[0] = bigString.Substring(start, length);

            //Asnwer B
            start = bigString.IndexOf("b)");
            end = bigString.IndexOf("\"", start);
            length = end - start;
            answers[1] = bigString.Substring(start, length);


            //Asnwer C
            start = bigString.IndexOf("c)");
            end = bigString.IndexOf("\"", start);
            length = end - start;
            answers[2] = bigString.Substring(start, length);

            //Asnwer D
            start = bigString.IndexOf("d)");
            end = bigString.IndexOf("\"", start);
            length = end - start;
            answers[3] = bigString.Substring(start, length);

            //return
            return answers;

        }


        //Get the scenario Tex
        //May Change depeneding on Database changes
        //Will get data from the pro quiz question table
        private String getScenarionText(String bigString)
        {

            // Start and End of the scenarion Text substring
            int start, end, length;
            String edit;


            //Check if bigString contains "Scenarion (scenario Num)"
            if (bigString.Contains("Background</strong>"))
            {
                //Find Start of substring
                start = bigString.IndexOf("Background</strong>") + 17;

                //Find end
                end = bigString.Length - 4;

                //Calculate length of scenarion text
                length = end - start;

                //Edit is the the scenaoio text with the html tags still in
                edit = bigString.Substring(start, length).Trim();

                edit.Replace("<p>", "\n");
                edit.Replace("</p>", "\n");
                edit.Replace("<strong>", "");
                edit.Replace("</strong>", "");

                return edit;


            }
            // If no Scenario text can be found
            else
            {
                return "No Scenario Text Found";
            }
        }



            
    }


    
}
