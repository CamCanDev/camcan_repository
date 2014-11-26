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

    public class Service1 : IService1
    {

        //WORKS NK 21.11
        [WebMethod]
        public Int32 returnUser(String user, String pass)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            Int32 userID = 0;
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                try
                {
                    cnn.Open();
                    String sql = String.Format("select u.id FROM dgn6la8u0_users u INNER JOIN dgn6la8u0_usermeta um ON um.user_id = u.id  AND um.meta_key = 'description' WHERE u.user_login = '{0}' AND um.meta_value = '{1}'", user, pass);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    //returns rows
                    userID = Convert.ToInt32(cmd.ExecuteScalar());

                    //Returns empty strings if user does not exist
                    if (userID <= 0)
                    {
                        return -99;
                    }
                    else
                    {//get completed Scenarios
                        return returnComleted(userID);
                    }
                }
                catch (Exception ex)
                {
                    return -100;
                }
                
            }
        }

        //WORKS NK 21.11
        //gets user and password and returns the scenario completed
        [WebMethod]
        public Int32 returnComleted(Int32 user)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            int max = 0, compare =0;

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                try     
                {
                    cnn.Open();
                // Returns user id and corresponding completion string
                String sql = String.Format("SELECT i.user_id, im.meta_value FROM wordpress_3.dgn6la8u0_frm_item_metas im JOIN wordpress_3.dgn6la8u0_frm_items i ON im.item_id=i.id WHERE user_id = {0}", user);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                // find max scenario number
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    String s = dr["meta_value"].ToString();
                    //if it holds scenario answers
                    if (s.Contains("s"))
                    {
                        //get scen number from dataset
                        compare = Convert.ToInt32(s.Substring(1,1));

                        if (compare > max)
                        {
                            max = compare;
                        }
                    }
                }
            }
             catch (Exception ex)
                { return compare; }
            }
            return max;
        }

        //WORKS NK 23.11
        //gets user and password and returns the scenario completed
        //Returns a scenario
        public Scenario returnScenario(int id)
        {
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            Scenario s = new Scenario();
            DataTable dt = new DataTable();
            //String test = ".....";
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                try
                {
                    cnn.Open();
                    String scen = "Scenario " + id;
                    //Get Scenario Information
                    String sql = String.Format("SELECT id,name,description, options FROM dgn6la8u0_frm_fields WHERE name = '{0}' UNION SELECT f.id, f.name, f.description, f.options FROM dgn6la8u0_frm_fields f WHERE f.id BETWEEN (SELECT f1.id FROM dgn6la8u0_frm_fields f1 WHERE f1.name = '{0}') + 1 AND (SELECT f1.id FROM dgn6la8u0_frm_fields f1 WHERE f1.name = '{0}') + 4 ORDER by id", scen);
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Scenarios");

                    dt = ds.Tables[0];

                    //treat the first row differently!
                    s._sID = Convert.ToInt32(id);
                    s._text = getScenarioText(dt.Rows[0][2].ToString());// description field
                    s._videoLink = getVideoLink(dt.Rows[0][2].ToString()); //descrption field
                    s._questions = new List<Question>();


                    //add the rest of the rows to the question list
                    //rows
                    for (int r = 1; r < 5; r++)
                    {
                        Question q = new Question();
                        q._id = Convert.ToInt32(dt.Rows[r][0].ToString()); //id field
                        q._questionText = dt.Rows[r][1].ToString(); //name field
                        //don't need description

                        //Correct Ans
                        String bigString = dt.Rows[r][3].ToString();
                        //find it
                        String str = dt.Rows[r][3].ToString();
                        String st1 = "";
                        String st = "";
                        int lengthC = 0;
                        if (str.Contains("1\";"))
                        {
                            //pulls just the full ans string
                            int start1 = str.IndexOf("- 1\";");
                            int endC = str.IndexOf("\";}", start1);
                            lengthC = endC - start1;
                            //get that string
                            st = str.Substring(start1, lengthC);
                            
                            int newstart = st.IndexOf(") ");
                            newstart = newstart - 1;
                            
                            st1 = st.Substring(newstart);
                            q._correctAns = st1;
                        }
                        else st1 = "Not Found";

                        //Answer A
                        int start = bigString.IndexOf("a)");
                        int end = bigString.IndexOf("\"", start);
                        int length = end - start;
                        q._ansA = bigString.Substring(start, length);

                        //Answer B
                        start = bigString.IndexOf("b)");
                        end = bigString.IndexOf("\"", start);
                        length = end - start;
                        q._ansB = bigString.Substring(start, length);

                        //Answer C
                        start = bigString.IndexOf("c)");
                        end = bigString.IndexOf("\"", start);
                        length = end - start;
                        q._ansC = bigString.Substring(start, length);

                        //Answer D
                        start = bigString.IndexOf("d)");
                        end = bigString.IndexOf("\"", start);
                        length = end - start;
                        q._ansD = bigString.Substring(start, length);

                        //add the list of questions
                        s._questions.Add(q);
                    }
                }
                catch (Exception ex)
                {
                    s.text = ex.ToString();
                }
                return s;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="results"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        //[WebMethod]
        //public String insertAnswer(int scenNum, int questNum, int ans, int userID)
        //{
        //    String sql = "";
        //    Int32 Empid = -1;

        //    //Id for dgn6la8u0_frm_item_metas table
        //    int itemID = -1;
        //    // the Meta value from the dgn6la8u0_frm_fields tbl, in options
        //    String meta_value = "";
        //    String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        //    try
        //    {
        //        using (MySqlConnection cnn = new MySqlConnection(conString))
        //        {
        //            cnn.Open();
        //            sql = String.Format("SELECT i.user_id, im.meta_value FROM `dgn6la8u0_frm_item_metas` im JOIN `dgn6la8u0_frm_items` i ON im.item_id=i.id WHERE user_id = {0}", user);
        //            MySqlCommand cmd = new MySqlCommand(sql, cnn);
        //            //returns rows
        //            Empid = Convert.ToInt32(cmd.ExecuteScalar());
        //            //now we have the EmpID we can continue

        //            sql = String.Format("INSERT INTO `dgn6la8u0_frm_item_metas`(meta_value, item_id, created_at) VALUES('?', '?', CURDATE()");
        //            //sql = String.Format("Insert into results (employeeID, scenarioID, questionID, answers, correct) values ('{0}')", results);
        //            MySqlCommand cmd2 = new MySqlCommand(sql, cnn);
        //            cmd2.ExecuteNonQuery();
        //            return "Inserted";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return ex.Message;
        //    }

        //    // get meta value for answer (from dgn6la8u0_frm_fields)
            
            
        //    // get item id from user user id
        //    sql = String.Format("SELECT id FROM dgn6la8u0_frm_items where user_id = {0}",userID);
        //    MySqlCommand cmd = new MySqlCommand(sql, cnn);
        //    itemID = Convert.ToInt32(cmd.ExecuteScalar());


        //    // Query DB to see if alrady in database (pulls data set with 0 or 1 rows)
        //    sql = String.Format("SELECT * FROM dgn6la8u0_frm_item_metas where item_id = {0} and meta_value = \"{1}\"", itemID, meta_value);
        //    MySqlDataAdapter da = new MySqlDataAdapter(sql, cnn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);


            
            
        //    // if not exist insert in to databases 
        //    if (ds.Tables[0].Rows.Count == 0)
        //    {
        //        // Insert in to table
        //        sql = String.Format("INSERT INTO `dgn6la8u0_frm_item_metas`(meta_value, item_id, created_at) VALUES({0}, {1}, CURDATE())",meta_value,itemID);
        //        //sql = String.Format("Insert into results (employeeID, scenarioID, questionID, answers, correct) values ('{0}')", results);
        //        MySqlCommand cmd2 = new MySqlCommand(sql, cnn);
        //        cmd2.ExecuteNonQuery();
        //        return "Inserted";
        //    }

        //    // else update data base
        //    else
        //    { 
        //        //Update Table
        //        sql = String.Format("INSERT INTO `dgn6la8u0_frm_item_metas`(meta_value, item_id, created_at) VALUES({0}, {1}, CURDATE())", meta_value, itemID);
        //        //sql = String.Format("Insert into results (employeeID, scenarioID, questionID, answers, correct) values ('{0}')", results);
        //        MySqlCommand cmd2 = new MySqlCommand(sql, cnn);
        //        cmd2.ExecuteNonQuery();
        //        return "Inserted";

        //    }

        //}




        /// <summary>
        ///     Saves a users answers for a  scenario to the wordpress_3 database
        /// </summary>
        /// <param name="scenNum"> The Scenario Number being saved</param>
        /// <param name="ans"> Array of Ints for each of the 4 asnwers to the scenario being saved</param>
        /// <param name="userID"> The id of the user</param>
        /// <returns></returns>
        [WebMethod]
        public String insertAnswer(int scenNum, String[] metaValue, String userName)
        {
            String sql = "";
            int[] field_id = new int[4];
            String scenStr = "Scenario " + scenNum;
            int scenID;
            int i = 0;//incrementer
            String conString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            //Id for dgn6la8u0_frm_item_metas table
            int itemID = -1;
            int userId = -1;

            using (MySqlConnection cnn = new MySqlConnection(conString))
            {

                cnn.Open();
                //get user id
                try
                {
                    String sql01 = String.Format("select id FROM dgn6la8u0_users WHERE user_login = '{0}'", userName);
                    MySqlCommand cmd = new MySqlCommand(sql01, cnn);
                    //returns rows
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
                catch(Exception ex)
                {
                    return ("0 try Catch, message: " + ex.ToString());
                }


                //------------------
                try
                {
                    //get field id for the scenario
                    sql = String.Format("SELECT id FROM dgn6la8u0_frm_fields where name = '{0}'", scenStr);
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    scenID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    return ("1 try Catch, message: " + ex.ToString());
                }


                //Load next 4 field id to array
                field_id[0] = scenID + 1;
                field_id[1] = scenID + 2;
                field_id[2] = scenID + 3;
                field_id[3] = scenID + 4;

                try
                {
                    //Get the users corresponing item id given their user id
                    sql = String.Format("SELECT id FROM dgn6la8u0_frm_items where user_id = {0}", userId);
                    MySqlCommand cmd01 = new MySqlCommand(sql, cnn);
                    itemID = Convert.ToInt32(cmd01.ExecuteScalar());  //Should only ever pull one element
                }
                catch (Exception ex)
                {
                    return ("3 try catch, message: " + ex.ToString());
                }


                try
                {
                    // Pulls rows only if data already exists in database
                    sql = String.Format("SELECT id FROM dgn6la8u0_frm_item_metas where item_id = {0} and field_id in ({1},{2},{3},{4})", itemID, field_id[0], field_id[1], field_id[2], field_id[3]);
                    MySqlDataAdapter da2 = new MySqlDataAdapter(sql, cnn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    // if not exist insert in to databases ( - No data in data adapter)
                    if (ds2.Tables[0].Rows.Count == 0)
                    {
                        /// Runs four times, once for each answer
                        // Insert in to table
                        for (i = 0; i < 4; i++)
                        {
                            sql = String.Format("INSERT INTO `dgn6la8u0_frm_item_metas`(meta_value, field_id, item_id, created_at) VALUES('{0}', {1}, {2}, CURDATE())", metaValue[i], field_id[i], itemID); 
                            MySqlCommand cmd2 = new MySqlCommand(sql, cnn);
                            cmd2.ExecuteNonQuery();
                        }

                        return "Inserted";

                    }
                    // else update data base
                    else
                    {

                        for (i = 0; i < 4; i++)
                        {
                            //Update Table
                            sql = String.Format("UPDATE `dgn6la8u0_frm_item_metas` SET meta_value='{0}', created_at=CURDATE() WHERE item_id={1} AND field_id={2}", metaValue[i], itemID, field_id[i]);
                            //sql = String.Format("Insert into results (employeeID, scenarioID, questionID, answers, correct) values ('{0}')", results);
                            MySqlCommand cmd2 = new MySqlCommand(sql, cnn);
                            cmd2.ExecuteNonQuery();
                        }

                        return "Updated";

                    }

                }
                catch (Exception ex)
                {
                    return ("4 try catch, message: " + ex.ToString());
                }
            }
        }


        //Returns the meta_value for a asnwer with the string stored in options dgn6la8u0_frm_fields
        private String getMetaValue(String bigString, int ansNum)
        {
            char[] seperates = { '\"' };
            String[] values = bigString.Split(seperates);
            String[] metas = new String[4];
            int increment = 0;

            //Finding the sequence s_q_a_ - _  (s1q1a1 - 1 correct / s1q1a2 - 0 incorrect) - Always follows ";s:10:"
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Contains(";s:10:"))
                {
                    metas[increment] = values[i + 1];
                    increment++;
                }
            }

            return metas[ansNum - 1];

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

            //Return the result
            return result;
        }

        private Boolean convertToResult(String boolString)
        {
            //Get the first Char of the parsed string
            Char result = boolString.ToUpper().ToCharArray()[0];

                
            // Return True if 'Y' false other wise
            return (result == 'Y');

        }

        //Convert a string to MD5 - not used
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

        //WORKS NK 22.11
        // Returns the youtube video link.
        public String getVideoLink(String bigString)
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

     
        //WORKS NK 22.11
        /// <summary>
        ///   Returns the answers to a question
        /// </summary>
        /// <param name="bigString"></param>
        /// <returns> String[] </returns>
        
        //WORKS NK 22.11
        //Get the scenario Text
        //May Change depeneding on Database changes
        //Will get data from the pro quiz question table
        public String getScenarioText(String bigString)
        {
            // Start and End of the scenarion Text substring
            int start, end, length;
            String edit;

            //Check if bigString contains "Scenarion (scenario Num)"
            if (bigString.Contains("<br>"))
            {
                //Find Start of substring
                start = bigString.IndexOf("<br>") + 4;

                //Find end
                end = bigString.Length - 4;

                //Calculate length of scenarion text
                length = end - start;

                //Edit is the the scenaoio text with the html tags still in
                edit = bigString.Substring(start, length).Trim();
                StringBuilder builder = new StringBuilder(edit);
                builder.Replace("<p>", "\n");
                builder.Replace("</p>", "\n");
                builder.Replace("<strong>", "");
                builder.Replace("</strong>", "");

                edit = builder.ToString();

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
