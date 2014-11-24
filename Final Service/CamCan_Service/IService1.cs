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
        Scenario returnScenario(Int32 id);

        //returns users completed scenarios
        [OperationContract]
        Int32 returnComleted(Int32 user);

        //Returns a user from database
        [OperationContract]
        Int32 returnUser(String user, String pass);

        //inserts the correct answer into the results table
       // [OperationContract]
       // String insertAnswer(int scenNum, int questNum, int ans, int userID);


    }
}
