using EnterpriseTaskManager.Common;
using EnterpriseTaskManager.WebAPI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EnterpriseTaskManager.Test
{
    class EventWebApiTests
    {
        /// <summary>
        /// Test the post Method in Event WEB API class
        /// </summary>
        [Test]
        public void PostMethodTest()
        {
            EventController eventControllerObject = new EventController();

            EventTransaction eventTransactionTestObject = new EventTransaction() { EventTypeDescription = "Procedure", IsResolved = "Yes", ObjectData = "{\"BillId\":\"1\",\"Amount\":\"230\",\"Status\":\"Paid\",\"PatientId\":\"61\"}", ResolvedBy = "Kunal" };
            JavaScriptSerializer js = new JavaScriptSerializer();
            String EventTransctionJSON = js.Serialize(eventTransactionTestObject).ToString();

            //Action
            var result = eventControllerObject.Post(EventTransctionJSON);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }



        /// <summary>
        /// Testing the POst Method of Event Web API 
        /// </summary>
        [Test]
        public void EventAPI_PostMethod_WIthNullData()
     {
            EventController eventControllerObject = new EventController();

            EventTransaction eventTransactionTestObject = new EventTransaction() { EventTypeDescription = "Procedure", IsResolved = "Yes" };
            JavaScriptSerializer js = new JavaScriptSerializer();
            String EventTransctionJSON = js.Serialize(eventTransactionTestObject).ToString();

            //Action
            var result = eventControllerObject.Post(EventTransctionJSON);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}
