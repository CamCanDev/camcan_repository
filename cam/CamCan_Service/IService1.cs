using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CamCan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // returns the scenID, Info and video Link
        [OperationContract]
        Scenario returnScenario(int scenarioNum);

        //returns users completed scenarios
        [OperationContract]
        Int32 returnComleted(String user, String pass);

        //Returns a user from database
        [OperationContract]
        UserProfile returnUser(String user, String pass);

        //inserts the correct answer into the results table
        [OperationContract]
        string insertAnswer(String Empid, Int32 ScenID, Int32 QuestID, String resonse, String correct);


        //needs another operation to GetQuestions
    }
}
