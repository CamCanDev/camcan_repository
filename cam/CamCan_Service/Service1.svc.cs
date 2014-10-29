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

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();

                String sql = String.Format("SELECT name,scenario_completed,password FROM employees WHERE name = \"{0}\" and password = \"{1}\"", user, pass);
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
                            u.name = Convert.ToString(dr["name"]);
                            u.completed = Convert.ToInt32(dr["scenario_completed"]);
                            u.password = Convert.ToString(dr["password"]);
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
                daQ.Fill(dsQ, "scenarios");

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

        [WebMethod]
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
                        result.setAnswer(dr.)
                    }
                }
            }
            
        }


    }
}
