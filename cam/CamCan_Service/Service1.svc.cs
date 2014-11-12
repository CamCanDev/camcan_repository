using System;
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
                mD5Password = CalculateMD5Hash(pass);

                String sql = String.Format("SELECT * FROM dgn6la8u0_users WHERE user_login = \"{0}\" and user_pass = \"{1}\"", user, mD5Password);
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


        //Returns Scenario
        
        /* Older vesion using old DB
        [WebMethod]
        public Scenario returnScenario(Int32 id)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            List<Scenario> teamList = new List<Scenario>();

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();

                //Get Scenario Information
                String sql = String.Format("SELECT * FROM scenarios WHERE scenarioID ={0}", id);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "scenarios");

                //Get question Information
                String sqlQ = String.Format("SELECT question, ansA, ansB, ansC, ansD, correctAns FROM questions WHERE scenarioID ={0}", id);
                MySqlDataAdapter daQ = new MySqlDataAdapter(sql, cnn);
                DataSet dsQ = new DataSet();
                daQ.Fill(dsQ, "question");

                //Objects
                Scenario s = new Scenario();
                Question[] questArray = new Question[4];
                int i = 0;

                try
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        s.scenarioID = Convert.ToInt32(id);
                        s.videoLink = Convert.ToString(dr["videoLink"]);
                        s.scenarioInformation = Convert.ToString(dr["scenarioInformation"]);
                    }


                    foreach (DataRow dr in dsQ.Tables[0].Rows)
                    {
                        //
                        if (i >= 4)
                            break;

                        //Load data from data table
                        questArray[i].questionText = Convert.ToString(dr["question"]);
                        questArray[i].ansA = Convert.ToString(dr["ansA"]);
                        questArray[i].ansB = Convert.ToString(dr["ansB"]);
                        questArray[i].ansC = Convert.ToString(dr["ansC"]);
                        questArray[i].ansD = Convert.ToString(dr["ansD"]);
                        questArray[i].correctAns = Convert.ToString(dr["correctAns"]);

                        //Increment i
                        i++;
                    }

                    //add questions to scenario
                    s.questionArray = questArray;
                }

                catch (Exception ex)
                {
                    s.scenarioInformation = ex.ToString();
                }

                return s;
            }
        }

        */

       /* public Scenario returnScenario(int scenarioNum)
        {
            
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            Scenario s = new Scenario();
            s.scenarioID = scenarioNum;
            Question[] q = new Question[4];
            String bigString;

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
             
                cnn.Open();

                //Get html text from database
                String sql = String.Format("SELECT question FROM dgn6la8u0_frm_fields where id ={0}", scenarioNum);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "scenarios");

                //
                try
                {
                    //get html into the big string
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        bigString = Convert.ToString(dr["question"]);
                    }

                    //Video Link
                    s.videoLink  = getVideoLink(bigString);

                    //Text
                    s.scenarioInformation = getScenarionText(bigString);

                    //Question 1
                    q = getQuestion(scenarioNum);

                    //Add questions to scenario
                    s.questionArray = q;

                    //Return Scenario
                    return s;
                }
                catch(Exception ex)
                {
                    s.scenarioInformation = ex.ToString();
                }


                return s;

            }

        } */

        
        //gets user and password and returns the scenario completed
        [WebMethod]
        public Int32 returnComleted(String user, String pass)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            Int32 completed = 0;
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                //String sql = String.Format("select contact_ID from player_team where number =\"{0}\"", playerNum);

                //This takes input, selects name and password and returns the scenario completed.
                String sql = String.Format("SELECT scenario_completed FROM employees WHERE name =\"{0}\" AND password = \"{1}\"", user, pass);
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                //returns rows
                completed = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return completed;
        }



        [WebMethod]
        public string insertAnswer(String user, Int32 ScenID, Int32 QuestID, String resonse, String correct)
        {
            String sql = "";
            Int32 Empid = -1;
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(conString))
                {
                    cnn.Open();
                    sql = String.Format("SELECT employeeID FROM employees WHERE name =\"{0}\" ", user);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    //returns rows
                    Empid = Convert.ToInt32(cmd.ExecuteScalar());
                    //now we have the EmpID we can continue

                    sql = String.Format("Insert into results (employeeID, scenarioID, questionID, answers, correct) values ('{0}', '{1}','{2}', '{3}','{4}')", Empid, ScenID, QuestID, resonse, correct);
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

      /*  [WebMethod]
        public Results showResults(int scenarioID, int employeeID)
        {
            //Creating the connection string
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            //Accessing the database via the connection string
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                String sql = String.Format("SELECT scenarioID, questionID, answer, correct FROM results WHERE employeeID = {0} AND ScenarioID = {1}", scenarioID, employeeID);
                Results result = new Results();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                if (ds.Tables.Count == 0)
                {
                    return result;
                }
                else
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                    }
                }
            }
        } */


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

        //Get the scenario Tex
        //May Change depeneding on Database changes
        //Will get data from the pro quiz question table
        private String getScenarionText(String bigString)
        {
            
            // Start and End of the scenarion Text substring
            int start,end,length;
            String edit;


            //Check if bigString contains "Scenarion (scenario Num)"
            if(bigString.Contains("Background</strong>"))
            {
                //Find Start of substring
                start = bigString.IndexOf("Background</strong>") + 17;

                //Find end
                end = bigString.Length - 4;

                //Calculate length of scenarion text
                length = end - start;

                //Edit is the the scenaoio text with the html tags still in
                edit = bigString.Substring(start,length).Trim();

                edit.Replace("<p>","\n");
                edit.Replace("</p>","\n");
                edit.Replace("<strong>","");
                edit.Replace("</strong>","");

                return edit;


            } 
            // If no Scenario text can be found
            else
            {
                return "No Scenario Text Found";
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



            
    }


    }
